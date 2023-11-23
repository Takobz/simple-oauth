using SimpleAuthServer.Data.Repositories;
using SimpleAuthServer.Data;
using SimpleAuthServer.Data.Entities;
using Moq;
using AutoFixture;
using Microsoft.EntityFrameworkCore;

namespace SimpleAuth.AuthServer.Tests.RepoTests 
{
    namespace SimpleAuth.AuthServer.Tests.RepoTests
    {
        public class ClientRepoTests
        {
            private readonly Mock<IAuthServerContext> _mockAuthServerContext;            private readonly Fixture _fixture;  
            private readonly ClientRepo _sut;


            private readonly Guid _clientId;
            private readonly string _redirectUri;

            public ClientRepoTests()
            {
                _fixture = new Fixture();   
                _mockAuthServerContext = new Mock<IAuthServerContext>();
                _sut = new ClientRepo(_mockAuthServerContext.Object);

                _clientId = Guid.NewGuid();
                _redirectUri = $"https://localhost:5001/signin-oidc";
            }

            [Fact]
            public async Task GetClientAsync_Should_Return_Client_If_ClientId_Exists()
            {
                // var clientInDatabase = _fixture
                //     .Build<Client>()
                //     .With(c => c.Id, Guid.Parse(_clientId))
                //     .Create();

                // var mockClientDbSet = new Mock<DbSet<Client>>();
                // mockClientDbSet.Setup(c => c.FirstOrDefaultAsync(x => x.Id == _clientId))
                // .ReturnsAsync(clientInDatabase);

                // var clientInDatabase = _fixture
                //     .Build<Client>()
                //     .With(c => c.Id, Guid.Parse(_clientId))
                //     .Create();

                // _mockAuthServerContext.Setup(msc => msc.Clients)
                //     .Returns(new DbSet<Client>());
            }
        }
    }
}