using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GerenciadorDePedidos.Application.Interfaces;
using GerenciadorDePedidos.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<SupplierDTO>>> GetAll()
        {
            var suppliers = await _supplierService.GetAll();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetById(int id)
        {
            var supplier = await _supplierService.GetById(id);
            if (supplier is not null)
            {
                return Ok(supplier);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> Add([FromBody] SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = await _supplierService.Add(supplierDTO);
            if (supplier is not null)
            {
                return Ok(supplier);
            }
            else
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierDTO>> Update(int id, [FromBody] SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != supplierDTO.Id)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }

            var supplier = await _supplierService.Update(supplierDTO);
            if (supplier is not null)
            {
                return Ok(supplier);
            }
            else
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var supplier = await _supplierService.GetById(id);
            if (supplier is null)
            {
                return NotFound();
            }

            await _supplierService.Remove(id);
            return Ok();
        }

    }
}
