using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        Task<DriverDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<DriverDetailsResponse>> FindByNameAsync(string name, CancellationToken cancellationToken);

        Task<IEnumerable<DriverShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken);

        Task<DriverDetailsResponse> CreateAsync(CreateDriverRequest request, CancellationToken cancellationToken);

        Task<DriverDetailsResponse?> UpdateAsync(UpdateDriverRequest request, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
