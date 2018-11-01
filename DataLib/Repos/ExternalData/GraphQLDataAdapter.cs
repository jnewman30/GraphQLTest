using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLib.Model;
using GraphQL.Client;
using GraphQL.Common.Request;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace DataLib.Repos.ExternalData
{
    public class GraphQLDataAdapter : IDataAdapterStrategy
    {
        public async Task<DataAdapterResult> Read(IDataAdapter dataAdapter, dynamic parameters)
        {
            var adapterMetadata = JsonConvert
               .DeserializeObject<GraphQLDataAdapterMetadata>(
                    dataAdapter.Metadata);

            var authToken = await GetAuthenticationTokenAsync(adapterMetadata);

            var graphClient = new GraphQLClient(dataAdapter.Endpoint);
            graphClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            graphClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            var request = new GraphQLRequest
                          {
                              Query = adapterMetadata.Query,
                              Variables = adapterMetadata.Variables
                          };

            var response = await graphClient.PostAsync(request);
            var result = new DataAdapterResult();

            return result;
        }

        internal async Task<string> GetAuthenticationTokenAsync(GraphQLDataAdapterMetadata adapterMetadata)
        {
            var tokenEndpoint = await GetTokenEndpointAsync(adapterMetadata);

            var client = adapterMetadata.Credentials.ClientId;
            var secret = adapterMetadata.Credentials.ClientSecret;
            var scope = adapterMetadata.Credentials.Scopes;
            var tokenClient = new TokenClient(tokenEndpoint, client, secret);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(scope);

            if (tokenResponse.IsError)
            {
                // TODO: Log this... and throw exception...
                return null;
            }

            return tokenResponse.AccessToken;
        }

        internal async Task<string> GetTokenEndpointAsync(GraphQLDataAdapterMetadata adapterMetadata)
        {
            var discoveryResponse = await DiscoveryClient.GetAsync(adapterMetadata.Credentials.Issuer);

            if (discoveryResponse.IsError)
            {
                throw new Exception("Auth discovery failure.");
            }

            return discoveryResponse.TokenEndpoint;
        }
    }

    public class GraphQLDataAdapterMetadata
    {
        public string Query { get; set; }

        public OpenIDCredentials Credentials { get; set; }

        public dynamic Variables { get; set; }
    }

    public class OpenIDCredentials
    {
        public string Issuer { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Scopes { get; set; }
    }
}
