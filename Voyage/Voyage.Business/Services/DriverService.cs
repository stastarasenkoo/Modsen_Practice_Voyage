using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    internal class DriverService : IDriverService
    {
        private readonly IDriverRepository repository;

        public DriverService(IDriverRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DriverDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            var driver = await repository.FindAsync(id, cancellationToken);

            return driver;
        }

        public async Task<IEnumerable<DriverDetailsResponse>> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await repository.FindByNameAsync(name, cancellationToken);
        }

        public async Task<IEnumerable<DriverShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(page, cancellationToken);
        }

        public async Task<DriverDetailsResponse> CreateAsync(CreateDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = await repository.CreateAsync(request, cancellationToken);

            return driver;
        }

        public async Task<DriverDetailsResponse?> UpdateAsync(UpdateDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = await repository.UpdateAsync(request, cancellationToken);

            return driver;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(id, cancellationToken);
        }
    }
}
