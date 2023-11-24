using SimpleAuthServer.Data.Repositories;
using SimpleAuthServer.Data;
using SimpleAuthServer.Data.Entities;
using Moq;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Query;

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
                _redirectUri = "https://client-uri.com/callback";
            }

            [Fact]
            public async Task GetClientAsync_Should_Return_Client_If_ClientId_Exists()
            {
                var clients = new List<Client>
                {
                    Client.Create(_clientId, _redirectUri)
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

            private static DbSet<Client> SetUpClientDbSet(List<Client> clients)
            {
                var mockSet = new Mock<DbSet<Client>>();

                var clientsAsQueryable = clients.AsQueryable();
                //look at: https://github.com/MichalJankowskii/Moq.EntityFrameworkCore/blob/master/src/Moq.EntityFrameworkCore/MoqExtensions.cs
                mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(clients.AsQueryable().Provider);
                mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(clients.AsQueryable().Expression);
                mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(clients.AsQueryable().ElementType);
                mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(clients.AsQueryable().GetEnumerator());

                return mockSet.Object;
            }
        }
    }
}