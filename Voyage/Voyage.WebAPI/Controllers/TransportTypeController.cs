using Mapster;
using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.DTO;
using Voyage.Common.RequestModels;

namespace Voyage.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportTypeController : ControllerBase
    {
        private readonly ITransportTypeService service;

        public TransportTypeController(ITransportTypeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TransportTypeDto>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<TransportTypeDto?> GetByIdAsync(int id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task CreateAsync(CreateTransportTypeRequest transport)
        {
            var tranportModel = transport.Adapt<TransportTypeDto>();
            await service.CreateAsync(tranportModel);
        }

        [HttpPut]
        public async Task UpdateAsync(TransportTypeDto transport)
        {
            await service.UpdateAsync(transport);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
