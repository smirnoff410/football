using FootBall.Infrastructure.Config;
using Microsoft.Extensions.Configuration;

namespace FootBall.Web.Config
{
    public class ConnectionString : IConnectionString
    {
        public string ConnectionName { get; set; }

        public ConnectionString(IConfiguration configuration)
        {
            ConnectionName = configuration.GetSection("ConnectionString").GetSection("ConnectionName").Value;
        }
    }
}