using Voyage.Common.RequestModels;

namespace Voyage.Tests.Transport.TestData
{
    public static class TestTransportRequests
    {
        public static CreateTransportRequest Create =>
            new CreateTransportRequest
            {
                Number = "number",
                Color = Common.Enums.Color.White,
                SeatsCount = 1,
            };
    }
}
