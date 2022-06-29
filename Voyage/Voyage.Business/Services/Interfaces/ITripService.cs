using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITripService
    {
        Task<TripDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<TripShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken);

        Task<TripDetailsResponse> CreateAsync(CreateTripRequest request, CancellationToken cancellationToken);

        Task<TripDetailsResponse?> UpdateAsync(UpdateTripRequest request, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
