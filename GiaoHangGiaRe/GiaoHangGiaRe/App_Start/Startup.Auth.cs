using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using GiaoHangGiaRe.Models;
using Microsoft.Owin.Security.OAuth;
using GiaoHangGiaRe.Providers;
using System.Web.Http.Cors;

namespace GiaoHangGiaRe
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.UseOAuthBearerTokens(OAuthOptions);
            ///Install-Package Microsoft.Owin.Cors -Version 2.1.0
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);


            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/taikhoan/relogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            app.UseFacebookAuthentication(
               appId: "162501304303106",
               appSecret: "b13937a2fe72ede4e9113bb2bbbf945f");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }

        //public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        //public static string PublicClientId { get; private set; }

        //// For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        //public void ConfigureAuth(IAppBuilder app)
        //{
        //    // Configure the db context and user manager to use a single instance per request
        //    app.CreatePerOwinContext(ApplicationDbContext.Create);
        //    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

        //    // Enable the application to use a cookie to store information for the signed in user
        //    // and to use a cookie to temporarily store information about a user logging in with a third party login provider
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions());
        //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        //    // Configure the application for OAuth based flow
        //    PublicClientId = "self";
        //    OAuthOptions = new OAuthAuthorizationServerOptions
        //    {
        //        TokenEndpointPath = new PathString("/Token"),
        //        Provider = new ApplicationOAuthProvider(PublicClientId),
        //        AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
        //        // In production mode set AllowInsecureHttp = false
        //        AllowInsecureHttp = true
        //    };

        //    // Enable the application to use bearer tokens to authenticate users
        //    app.UseOAuthBearerTokens(OAuthOptions);

        //    // Uncomment the following lines to enable logging in with third party login providers
        //    //app.UseMicrosoftAccountAuthentication(
        //    //    clientId: "",
        //    //    clientSecret: "");

        //    //app.UseTwitterAuthentication(
        //    //    consumerKey: "",
        //    //    consumerSecret: "");

        //    //app.UseFacebookAuthentication(
        //    //    appId: "",
        //    //    appSecret: "");

        //    //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
        //    //{
        //    //    ClientId = "",
        //    //    ClientSecret = ""
        //    //});
        //}
    }
}