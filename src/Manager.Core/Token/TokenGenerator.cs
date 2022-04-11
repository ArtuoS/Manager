using Microsoft.Extensions.Configuration;

namespace Manager.Core.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken()
        {
            throw new NotImplementedException();
        }
    }
}