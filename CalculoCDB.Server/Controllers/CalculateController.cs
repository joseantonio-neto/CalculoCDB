using CalculoCDB.Server.Models;
using CalculoCDB.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.Server.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class CalculateController : ControllerBase
	{
		private readonly ICalculateService _calculateService;

		public CalculateController(ICalculateService calculateService)
		{
			_calculateService = calculateService;
		}

		[HttpGet(Name = "GetCalculate")]
		[ProducesResponseType(typeof(GetCalculateResponse), 200)]
		public IActionResult Get([FromQuery] GetCalculateRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var response = _calculateService.Calculate(request.InitialValue, request.Months);
			return Ok(response);
		}
	}
}
