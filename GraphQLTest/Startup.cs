using DataLib;
using DataLib.Repos;
using GraphLib;
using GraphLib.Model.User;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
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
                .AddSingleton<IMasterDb, MasterDb>()
                .AddSingleton<IUserRepo, UserRepo>()
                .AddSingleton<IRootQuery, RootQuery>()
                .AddSingleton<IRootMutation, RootMutation>()
                .AddSingleton<IMasterSchema, MasterSchema>();

            services
                .AddGraphQL();

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
}