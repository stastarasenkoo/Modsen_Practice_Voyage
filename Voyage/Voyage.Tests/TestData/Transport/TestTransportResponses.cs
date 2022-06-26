using Voyage.Common.ResponseModels;

namespace Voyage.Tests.TestData.Transport
{
    public static class TestTransportResponses
    {
        public static TransportDetailsResponse Details =>
            new TransportDetailsResponse
            {
                Id = 1,
                Number = "number",
                Color = Common.Enums.Color.White,
                SeatsCount = 1,
            };
    }
}
