using System;
using DataLib;
using DataLib.Repos;
using GraphLib;
using GraphLib.Interfaces;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        private IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IDependencyResolver, GraphDependencyResolver>()
                .AddSingleton<IMasterDb, MasterDb>()
                .AddSingleton<IUserRepo, UserRepo>()
                .AddSingleton<IRootMutation, RootMutation>()
                .AddSingleton<IRootQuery, RootQuery>()
                .AddSingleton<IMasterSchema, MasterSchema>();

            services
                .AddGraphQL(config =>
                {
                    config.EnableMetrics = true;
                    config.ExposeExceptions = true;
                    config.ComplexityConfiguration = new ComplexityConfiguration
                    {
                        MaxDepth = 30
                    };
                });

            services
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseGraphQL<IMasterSchema>()
                .UseGraphQLPlayground(new GraphQLPlaygroundOptions())
                .UseGraphQLVoyager(new GraphQLVoyagerOptions());

            app.UseMvc();
        }
    }

    public class GraphDependencyResolver : IDependencyResolver
    {
        public GraphDependencyResolver(IServiceProvider provider)
        {
            Provider = provider;
        }

        private IServiceProvider Provider { get; }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return Provider.GetService(type);
        }
    }
}