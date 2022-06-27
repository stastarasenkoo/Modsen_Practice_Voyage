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
using Voyage.Tests.TestData.Transport;

namespace Voyage.Tests.Services
{
    [TestFixture]
    public class TransportServiceTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnTransportDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTransportRequests.Create;
            var response = TestTransportResponses.Details;

            mocker.Setup<ITransportRepository, Task<TransportDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<ITransportRepository, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task FindAsync_WhenIdIsProvided_ShouldCallRepositoryAndReturnTransportDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportRepository, Task<TransportDetailsResponse?>>(x => x.FindAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.FindAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.FindAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetAsync_ShouldCallRepositoryAndReturnTransportShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestTransportResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<ITransportRepository, Task<IEnumerable<TransportShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnTransportDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTransportRequests.Update;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportRepository, Task<TransportDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }
    }
}
