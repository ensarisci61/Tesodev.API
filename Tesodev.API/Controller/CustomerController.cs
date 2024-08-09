using Microsoft.AspNetCore.Mvc;
using Tesodev.Shared.Data.Dto;
using Tesodev.Shared.Data.Service.CustomerService;
using Tesodev.Shared.Data.Service.OrderService;

namespace Tesodev.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly ILogger<CustomerController> _logger;
		private readonly ICustomerService _customerService;

		public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
		{
			_logger = logger;
			_customerService = customerService;
		}

		[HttpPost]
		[ProducesResponseType(500)]
		public async Task<ActionResult<CustomerDto>> AddCustomer([FromBody] CustomerDto request)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _customerService.AddCustomer(request);
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
		public async Task<ActionResult<CustomerDto>> DeleteCustomer([FromBody] string request)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _customerService.DeleteCustomer(request);
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
		public async Task<ActionResult<CustomerDto>> GetCustomerList()
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _customerService.GetCustomerList();
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
		public async Task<ActionResult<CustomerDto>> GetCustomer(string id)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _customerService.GetCustomer(id);
				return Ok(result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		[HttpPut("id")]
		[ProducesResponseType(500)]
		public async Task<ActionResult<CustomerDto>> UpdateCustomer(string id, UpdateCustomerDto dto)
		{
			var trackingId = Guid.NewGuid().ToString();
			try
			{
				var result = await _customerService.UpdateCustomer(id,dto);
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