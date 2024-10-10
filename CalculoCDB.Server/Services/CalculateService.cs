using CalculoCDB.Server.Models;

namespace CalculoCDB.Server.Services
{
    public class CalculateService : ICalculateService
	{
		public CalculateService() { }

		public GetCalculateResponse Calculate(double initialValue, int months)
		{
			if (initialValue <= 0 || months <= 0)
			{
				throw new ArgumentException("The initialValue and months parameters must be greater than Zero.");
			}

			var cdi = FeesService.GetCdiTax();
			var tb = FeesService.GetTbTax();
			var fee = FeesService.GetFeeIncome(months);

			// Cálculo de Juros Compostos
			// Valor final = Montante * (1 + Taxa) ^ Período )
			var profit = initialValue * Math.Pow(1 + cdi * tb, months) - initialValue;

			var finalValue = initialValue + profit;

			var netProfit = profit * (1 - fee);
			var netFinalValue = initialValue + netProfit;

			return new GetCalculateResponse
			{
				InitialValue = initialValue,
				Months = months,
				GrossIncome = finalValue,
				NetIncome = netFinalValue,
				ImpostValue = finalValue - netFinalValue,
				Fee = fee,
			};
		}
	}
}