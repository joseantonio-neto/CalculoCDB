using CalculoCDB.Server.Models;
using System.Runtime.InteropServices;

namespace CalculoCDB.Server.Services
{
    public class CalculateService : ICalculateService
	{
		private readonly ICdiFeesService _cdiFeesService;
		private readonly IBankFeesService _bankFeesService;
		private readonly IImpostTaxesService _impostTaxesService;
		public CalculateService(ICdiFeesService cdiFeesService, IBankFeesService bankFeesService, IImpostTaxesService impostTaxesService) {
			_cdiFeesService = cdiFeesService;
			_bankFeesService = bankFeesService;
			_impostTaxesService = impostTaxesService;
		}

		public GetCalculateResponse Calculate(double initialValue, int months)
		{
			if (initialValue <= 0 || months <= 0)
			{
				throw new ArgumentException("The initialValue and months parameters must be greater than Zero.");
			}

			var cdiFee = _cdiFeesService.GetCdiFee();
			var bankFee = _bankFeesService.GetBankFee();
			var impostTax = _impostTaxesService.GetImpostTax(months);

			// Cálculo de Juros Compostos
			// Valor final = Montante * (1 + Taxa) ^ Período )
			var finalValue = initialValue * Math.Pow(1 + cdiFee * bankFee, months);

			var profit = finalValue - initialValue;

			var netProfit = profit * (1 - impostTax);
			var netFinalValue = initialValue + netProfit;

			return new GetCalculateResponse
			{
				InitialValue = initialValue,
				Months = months,
				GrossIncome = finalValue,
				NetIncome = netFinalValue,
				ImpostValue = finalValue - netFinalValue,
				Fee = impostTax,
			};
		}
	}
}