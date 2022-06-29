using FluentAssertions;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Business.Services;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;
using Voyage.Tests.TestData.Tickets;

namespace Voyage.Tests.Services
{
    [TestFixture]
    public class TicketServiceTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnTicketDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.Create;
            var response = TestTicketResponses.Details;

            mocker.Setup<ITicketRepository, Task<TicketDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TicketService>();

            // Act
            var result = await service.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITicketRepository>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.Delete;
            var id = 1;
            var isDeleted = true;

            mocker.Setup<ITicketRepository, Task<bool>>(x => x.DeleteAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var service = mocker.CreateInstance<TicketService>();

            // Act
            var result = await service.DeleteAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITicketRepository>(x => x.DeleteAsync(request, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task GetAsync_ShouldCallRepositoryAndReturnTicketShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.Get;
            var response = TestTicketResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<ITicketRepository, Task<IEnumerable<TicketShortInfoResponse>>>(x => x.GetAsync(page, request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TicketService>();

            // Act
            var result = await service.GetAsync(page, request, CancellationToken.None);

            // Assert
            mocker.Verify<ITicketRepository>(x => x.GetAsync(page, request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetTicketDetailsAsync_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTicketRequests.GetDetails;
            var response = TestTicketResponses.Details;

            mocker.Setup<ITicketRepository, Task<TicketDetailsResponse>>(x => x.GetTicketDetailsAsync(request))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TicketService>();

            // Act
            var result = await service.GetTicketDetailsAsync(request);

            // Assert
            mocker.Verify<ITicketRepository>(x => x.GetTicketDetailsAsync(request), Times.Once);
            result.Should().BeEquivalentTo(response);
        }
    }
}
