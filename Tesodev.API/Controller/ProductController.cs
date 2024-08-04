using Microsoft.AspNetCore.Mvc;
using Tesodev.Shared.Data.Dto;
using Tesodev.Shared.Data.Service.CustomerService;
using Tesodev.Shared.Data.Service.ProductService;

namespace Tesodev.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly ILogger<ProductController> _logger;
		private readonly IProductService _productService;

		public ProductController(ILogger<ProductController> logger, IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		[HttpPost]
		[ProducesResponseType(500)]
		public async Task<ActionResult<ProductDto>> AddProduct([FromBody] ProductDto request)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _productService.AddProduct(request);
				return Ok(result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpDelete]
		[ProducesResponseType(500)]
		public async Task<ActionResult<ProductDto>> DeleteProduct([FromBody] string request)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _productService.DeleteProduct(request);
				return Ok(result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpGet]
		[ProducesResponseType(500)]
		public async Task<ActionResult<ProductDto>> GetProductList()
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _productService.GetProductList();
				return Ok(result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpGet("id")]
		[ProducesResponseType(500)]
		public async Task<ActionResult<ProductDto>> GetProduct(string id)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _productService.GetProductById(id);
				return Ok(result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
