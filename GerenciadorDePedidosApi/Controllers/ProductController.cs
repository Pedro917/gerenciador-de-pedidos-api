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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProductDTO>>> GetAll()
        {
            var Products = await _ProductService.GetAll();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var Product = await _ProductService.GetById(id);
            if (Product is not null)
            {
                return Ok(Product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Add([FromBody] ProductDTO ProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Product = await _ProductService.Add(ProductDTO);
            if (Product is not null)
            {
                return Ok(Product);
            }
            else
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> Update(int id, [FromBody] ProductDTO ProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != ProductDTO.Id)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }

            var Product = await _ProductService.Update(ProductDTO);
            if (Product is not null)
            {
                return Ok(Product);
            }
            else
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Product = await _ProductService.GetById(id);
            if (Product is null)
            {
                return NotFound();
            }

            await _ProductService.Remove(id);
            return Ok();
        }
    }
}
