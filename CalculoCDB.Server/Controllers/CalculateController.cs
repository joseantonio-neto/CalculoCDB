using CalculoCDB.Server.DTO;
using CalculoCDB.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalculateController : ControllerBase
	{
		private readonly ICalculateService _calculateService;
		private readonly ILogger<CalculateController> _logger;

		public CalculateController(ICalculateService calculateService, ILogger<CalculateController> logger)
		{
			_calculateService = calculateService;
			_logger = logger;
		}

		[HttpGet(Name = "GetCalculate")]
		[ProducesResponseType(typeof(GetCalculateResponse), 200)]
		public IActionResult Get(decimal initialValue, int months)
		{
			_logger.LogTrace("GetCalculate Params:", [initialValue, months]);
			
			if (ModelState.IsValid)
			{
				var response = _calculateService.Calculate(initialValue, months);
				return Ok(response);
			}

			return BadRequest();
		}
	}
}
