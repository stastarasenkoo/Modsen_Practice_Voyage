using System.Collections.Generic;
using Voyage.Common.Types;
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
                Color = Color.White,
                SeatsCount = 1,
            };

        public static TransportDetailsResponse? NullableDetails => Details;

        public static TransportShortInfoResponse ShortInfo =>
            new TransportShortInfoResponse
            {
                Id = 1,
                SeatsCount = 1,
                Mark = "mark",
                Type = TransportType.Minibus,
            };

        public static IEnumerable<TransportShortInfoResponse> ShortInfoList =>
            new List<TransportShortInfoResponse>
            {
                ShortInfo,
            };
    }
}
