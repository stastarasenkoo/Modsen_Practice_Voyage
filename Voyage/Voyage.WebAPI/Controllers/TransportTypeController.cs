using Mapster;
using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Models;
using Voyage.Business.Services.Interfaces;
using Voyage.WebAPI.Models;

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

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<TransportTypeDto>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<TransportTypeDto?> GetTransportTypeByIdAsync(int id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost(Name = "Create")]
        public async Task CreateAsync(CreateTransportTypeRequest transport)
        {
            var tranportModel = transport.Adapt<TransportTypeDto>();
            await service.CreateAsync(tranportModel);
        }

        [HttpPut(Name = "Update")]
        public async Task UpdateAsync(TransportTypeDto transport)
        {
            await service.UpdateAsync(transport);
        }

        [HttpDelete("{id}", Name = "Delete")]
        public async Task DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
