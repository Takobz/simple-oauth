using SimpleAuthServer.Data.Repositories;
using SimpleAuthServer.Data;
using SimpleAuthServer.Data.Entities;
using Moq;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using SimpleAuth.AuthServer.Tests.Helper;

namespace SimpleAuth.AuthServer.Tests.RepoTests 
{
    namespace SimpleAuth.AuthServer.Tests.RepoTests
    {
        public class ClientRepoTests
        {
            private readonly Mock<IAuthServerContext> _mockAuthServerContext;            
            private readonly Fixture _fixture;  
            private readonly ClientRepo _sut;

            private readonly Guid _clientId;
            private readonly string _redirectUri;
            private readonly string _clientName;

            public ClientRepoTests()
            {
                _fixture = new Fixture();   
                _mockAuthServerContext = new Mock<IAuthServerContext>();
                _sut = new ClientRepo(_mockAuthServerContext.Object);

                _clientId = Guid.NewGuid();
                _redirectUri = "https://client-uri.com/callback";
                _clientName = "test-client-name";
            }

            [Fact]
            public async Task GetClientAsync_Should_Return_Client_If_ClientId_Exists()
            {
                var clients = new List<Client>
                {
                    Client.Create(_clientId, _redirectUri, _clientName)
                };

                var clientsDbSet = SetUpClientDbSet(clients);
                _mockAuthServerContext.Setup(msc => msc.Clients).Returns(clientsDbSet);

                var result = await _sut.GetClientAsync(_clientId);
                result.Should().NotBeNull();
                result.IsSuccess.Should().BeTrue();
                result.IsEmptyResult.Should().BeFalse();
                result.Result.Should().NotBeNull();
                result.Result.Id.Should().Be(_clientId);
            }

            /// <summary>
            /// Referenced: https://github.com/MichalJankowskii/Moq.EntityFrameworkCore/blob/master/src/Moq.EntityFrameworkCore
            /// </summary>
            private static DbSet<Client> SetUpClientDbSet(List<Client> clients)
            {
                var mockSet = new Mock<DbSet<Client>>();
                var clientsAsQueryable = clients.AsQueryable();

                mockSet.As<IAsyncEnumerable<Client>>()
                    .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                    .Returns(new InMemoryDbAsyncEnumerator<Client>(clientsAsQueryable.GetEnumerator()));

                mockSet.As<IQueryable<Client>>()
                    .Setup(m => m.Provider)
                    .Returns(new InMemoryAsyncQueryProvider<Client>(clientsAsQueryable.Provider));

                mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(clientsAsQueryable.Expression);
                mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(clientsAsQueryable.ElementType);                

                return mockSet.Object;
            }
        }
    }
}