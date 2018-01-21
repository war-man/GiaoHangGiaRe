using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using Swashbuckle.AspNetCore.Swagger;
[assembly: OwinStartupAttribute(typeof(GiaoHangGiaRe.Startup))]
namespace GiaoHangGiaRe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            app.MapSignalR();          
            GlobalHost.HubPipeline.RequireAuthentication();
        }
        //public void Configure(IApplicationBuilder app)
        //{
        //    // Enable middleware to serve generated Swagger as a JSON endpoint.
        //    app.UseSwagger();

        //    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
        //    app.UseSwaggerUI(c =>
        //    {
        //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        //    });

        //    app.UseMvc();
        //}
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
        //    //services.AddMvc();

        //    // Register the Swagger generator, defining one or more Swagger documents
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new Info { Title = "Giao hang gia re", Version = "v1" });
        //    });
        //}
    }
}
