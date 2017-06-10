using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;
using System.Net.Http;

namespace IassetTechnicalTest.Api.Security
{
    public class DynamicPolicyProviderFactory : ICorsPolicyProviderFactory
    {
        public ICorsPolicyProvider GetCorsPolicyProvider(
          HttpRequestMessage request)
        {
            var route = request.GetRouteData();
            //var controller = (string)route.Values["controller"];
            var corsRequestContext = request.GetCorsRequestContext();
          //  var originRequested = corsRequestContext.Origin;
            var policy = GetPolicyForControllerAndOrigin();
            return new CustomPolicyProvider(policy);
        }
        private CorsPolicy GetPolicyForControllerAndOrigin()
        {
            var policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                AllowAnyOrigin = true,
                SupportsCredentials = true
            };


            return policy;
        }
    }
}