using FluentAssertions;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
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
        public async Task CreateAsync_WhenCreateTransportRequestIsValid_ShouldReturnCreatedTransportDetails()
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
            result.Should().BeEquivalentTo(response);
        }
    }
}
