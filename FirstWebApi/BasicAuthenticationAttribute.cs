using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FirstWebApi
{
    public class BasicAuthenticationAttribute:AuthorizationFilterAttribute
    {
      
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //if the user doesnot send the authorization in the headers
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string EncodedAuthenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string DecodedAuthenticationToken= 
                    Encoding.UTF8.GetString(Convert.FromBase64String(EncodedAuthenticationToken));
                //username:password 
                string[] UsernamePassword = DecodedAuthenticationToken.Split(':');
                string username = UsernamePassword[0];
                string password = UsernamePassword[1];

                if(TestSecurity.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username),null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }

            }
        }


    }
}