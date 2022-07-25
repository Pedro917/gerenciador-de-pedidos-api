using GerenciadorDePedidos.Application.DTOs;
using GerenciadorDePedidos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDePedidos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<OrderDTO>>> GetAll()
        {
            var Orders = await _OrderService.GetAll();
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var Order = await _OrderService.GetById(id);
            if (Order is not null)
            {
                return Ok(Order);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Add([FromBody] OrderDTO OrderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Order = await _OrderService.Add(OrderDTO);
            if (Order is not null)
            {
                return Ok(Order);
            }
            else
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> Update(int id, [FromBody] OrderDTO OrderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != OrderDTO.Id)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }

            var Order = await _OrderService.Update(OrderDTO);
            if (Order is not null)
            {
                return Ok(Order);
            }
            else
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Order = await _OrderService.GetById(id);
            if (Order is null)
            {
                return NotFound();
            }

            await _OrderService.Remove(id);
            return Ok();
        }
    }
}
