using FluentAssertions;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Voyage.Business.Services;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;
using Voyage.Tests.TestData.Transport;
using Voyage.Tests.Transport.TestData;

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

            mocker.Setup<ITransportRepository, Task<TransportDetailsResponse>>(x => x.CreateAsync(request))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.CreateAsync(request);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.CreateAsync(request), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<ITransportRepository, Task<bool>>(x => x.DeleteAsync(id))
                .Returns(Task.FromResult(isDeleted));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.DeleteAsync(id);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.DeleteAsync(id), Times.Once);
        }

        [Test]
        public async Task FindAsync_WhenIdIsProvided_ShouldCallRepositoryAndReturnTransportDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportRepository, Task<TransportDetailsResponse?>>(x => x.FindAsync(id))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.FindAsync(id);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.FindAsync(id), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetAsync_ShouldCallRepositoryAndReturnTransportShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestTransportResponses.ShortInfoList;

            mocker.Setup<ITransportRepository, Task<IEnumerable<TransportShortInfoResponse>>>(x => x.GetAsync())
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.GetAsync();

            // Assert
            mocker.Verify<ITransportRepository>(x => x.GetAsync(), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnTransportDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTransportRequests.Update;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportRepository, Task<TransportDetailsResponse?>>(x => x.UpdateAsync(request))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TransportService>();

            // Act
            var result = await service.UpdateAsync(request);

            // Assert
            mocker.Verify<ITransportRepository>(x => x.UpdateAsync(request), Times.Once);
            result.Should().BeEquivalentTo(response);
        }
    }
}
