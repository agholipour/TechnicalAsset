using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IassetTechnicalTest.Api.Security
{
    public class CustomPolicyProvider : ICorsPolicyProvider
    {
        CorsPolicy policy;
        public CustomPolicyProvider(CorsPolicy policy)
        {
            this.policy = policy;
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(
          HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.policy);
        }
    }
}