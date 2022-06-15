using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Models;
using Voyage.Business.Services.Interfaces;
using Voyage.DataAccess.Entities;

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

        [HttpGet("{id}", Name = "GetById")]
        public async Task<TransportType?> GetTransportTypeByIdAsync(int id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost(Name = "Create")]
        public async Task CreateAsync(TransportType transport)
        {
            await service.CreateAsync(transport);
        }

        [HttpPut(Name = "Update")]
        public async Task UpdateAsync(TransportType transport)
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
