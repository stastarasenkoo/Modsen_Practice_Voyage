using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Business.Services.Interfaces;
using Voyage.DataAccess.Entities;
using Voyage.Tests.TestData.Account;
using Voyage.WebAPI.Controllers;

namespace Voyage.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        public async Task RegisterAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnAppUser()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestAccountRequests.Register;

            mocker.Setup<IAccountService, Task<AppUser>>(x => x.RegisterAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(It.IsAny<AppUser>()));

            var controller = mocker.CreateInstance<AccountController>();

            // Act
            var result = await controller.RegisterAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IAccountService>(x => x.RegisterAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
