using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        public readonly HttpClient httpClient;
        public TokenService(
            IOptions<IdentityServerSettings> identityServerSettings
            )
        {
            this.identityServerSettings = identityServerSettings;
            this.httpClient = new HttpClient();
            this.discoveryDocument = httpClient.GetDiscoveryDocumentAsync(this.identityServerSettings.Value.DiscoverUrl).Result;
            if (discoveryDocument.IsError)
            {
                throw new Exception("Unable to find the discovery document", discoveryDocument.Exception);
            }

        }
        public async Task<TokenResponse> GetToken(string scope)
        {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(
                    new ClientCredentialsTokenRequest
                    {
                        Address = discoveryDocument.TokenEndpoint,
                        ClientId = identityServerSettings.Value.ClientName,
                        ClientSecret = identityServerSettings.Value.ClientPasswrod,
                        Scope = scope
                    }
                );

            if (tokenResponse.IsError)
            {
                throw new Exception("Unable to get the token", tokenResponse.Exception);
            }

            return tokenResponse;
        }
    }
}
