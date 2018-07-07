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
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            app.MapSignalR();          
            //GlobalHost.HubPipeline.RequireAuthentication();
        }
    }
}
