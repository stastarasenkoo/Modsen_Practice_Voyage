using FluentAssertions;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Business.Services;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Repositories.Interfaces;
using Voyage.Tests.TestData.Account;

namespace Voyage.Tests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        [Test]
        public async Task RegisterAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnAppUser()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestAccountRequests.Register;

            mocker.Setup<IAccountRepository, Task<AppUser>>(x => x.RegisterAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(It.IsAny<AppUser>()));

            var service = mocker.CreateInstance<AccountService>();

            // Act
            var result = await service.RegisterAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IAccountRepository>(x => x.RegisterAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(It.IsAny<AppUser>());
        }
    }
}
