using CleanArchitecherWithCQRSANDMEDIATR.Application.Products.Commands;
using CleanArchitecherWithCQRSANDMEDIATR.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecherWithCQRSANDMEDIATR.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
        [HttpGet]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = Id });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand cmd)
        {
            return Ok(await _mediator.Send(cmd));
        }
    }
}
