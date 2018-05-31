using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(MVCImplicitFlow.Startup))]
namespace MVCImplicitFlow
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = Constants.ClientId,
                Authority = Constants.SitefinitySTSUrl,
                RedirectUri = Constants.SiteUrl,
                ResponseType = "id_token token",
                Scope = "openid",

                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        var id = n.AuthenticationTicket.Identity;
                        id.AddClaim(new System.Security.Claims.Claim("access_token", n.ProtocolMessage.AccessToken));
                        n.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(id, n.AuthenticationTicket.Properties);
                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}