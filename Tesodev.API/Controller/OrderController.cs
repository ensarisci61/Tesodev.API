using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesodev.Shared.Data;
using Tesodev.Shared.Data.Dto;
using Tesodev.Shared.Data.Service.OrderService;

namespace Tesodev.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly ILogger<OrderController> _logger;
		private readonly IOrderService _orderService;

		public OrderController(ILogger<OrderController> logger, IOrderService orderService)
		{
			_logger = logger;
			_orderService = orderService;
		}

		[HttpPost]
		[ProducesResponseType(500)]
		public async Task<ActionResult<Order>> AddOrder([FromBody] OrderAddDto request, string customerName,string productName)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _orderService.AddOrder(request, customerName,productName);
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
		public async Task<ActionResult<OrderDto>> DeleteOrder([FromBody] string request)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _orderService.DeleteOrder(request);
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
		public async Task<ActionResult<OrderDto>> GetOrderList()
		{
			var trackingId = Guid.NewGuid().ToString(); 
			try
			{
				var result = await _orderService.GetOrder();
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
		public async Task<ActionResult<OrderDto>> GetOrder(string id)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _orderService.GetOrderById(id);
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