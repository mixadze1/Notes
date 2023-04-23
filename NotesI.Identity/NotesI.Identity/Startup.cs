using IdentityServer4.Models;
using NotesI.Identity;

namespace Notes.Identity
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; }
        public Startup(IConfiguration configuration) =>
            AppConfiguration = configuration;


        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = AppConfiguration.GetValue<string>("DbConnection");
            services.AddIdentityServer().
                AddInMemoryApiResources(Configuration.ApiResources).
                AddInMemoryIdentityResources(Configuration.IdentityResource).
                AddInMemoryApiScopes(Configuration.ApiScopes).
                AddInMemoryClients(Configuration.Clients).
                AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endPoints =>
            {
                endPoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("HelloWorld");
                });
            });      
        }
    }
}