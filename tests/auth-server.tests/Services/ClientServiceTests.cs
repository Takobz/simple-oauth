using FluentAssertions;
using SimpleAuthServer.Models.ClientService;
using SimpleAuthServer.Services;

namespace SimpleAuth.AuthServer.Tests.Services 
{
    public class ClientServiceTests 
    {
        private readonly ClientService _sut;
        private readonly string _clientId;
        private readonly string _redirectUri;

        public ClientServiceTests() 
        {
            _sut = new ClientService();
            _clientId = $"{Guid.NewGuid()}";
            _redirectUri = $"https://localhost:5001/signin-oidc";
        }

        [Fact]
        public async Task GetAndValifdateClientAsync_Returns_Client_If_ClientId_And_RedirectUri_Exists()
        {    
            var request = new GetAndValidateClientRequest(_clientId, _redirectUri);

            var response = await _sut.GetAndValidateClientAsync(request);

            response.Should().NotBeNull();
            response.Client.ClientId.Should().Be(_clientId);
            response.Client.RedirectUri.Should().Be(_redirectUri);
        }
    }
}