using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.ResponseModels;
using Voyage.Tests.TestData.Tickets;
using Voyage.WebAPI.Controllers;

namespace Voyage.Tests.Controllers
{
    [TestFixture]
    public class TicketControllerTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnTicketDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.Create;
            var response = TestTicketResponses.Details;

            mocker.Setup<ITicketService, Task<TicketDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TicketController>();

            // Act
            var result = await controller.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITicketService>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallService()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.Delete;
            var id = 1;
            var isDeleted = true;

            mocker.Setup<ITicketService, Task<bool>>(x => x.DeleteAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var controller = mocker.CreateInstance<TicketController>();

            // Act
            var result = await controller.DeleteAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITicketService>(x => x.DeleteAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task GetAsync_ShouldCallServiceAndReturnTicketShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.Get;
            var response = TestTicketResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<ITicketService, Task<IEnumerable<TicketShortInfoResponse>>>(x => x.GetAsync(page, request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TicketController>();

            // Act
            var result = await controller.GetAsync(page, request, CancellationToken.None);

            // Assert
            mocker.Verify<ITicketService>(x => x.GetAsync(page, request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetTicketDetailsAsync_ShouldCallService()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.GetDetails;
            var response = TestTicketResponses.Details;

            mocker.Setup<ITicketService, Task<TicketDetailsResponse>>(x => x.GetTicketDetailsAsync(request))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TicketController>();

            // Act
            var result = await controller.GetTicketDetailsAsync(request);

            // Assert
            mocker.Verify<ITicketService>(x => x.GetTicketDetailsAsync(request), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
