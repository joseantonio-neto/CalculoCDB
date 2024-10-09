using CalculoCDB.Server.DTO;

namespace CalculoCDB.Server.Services
{
	public class CalculateService : ICalculateService
	{
		public CalculateService() { }

		public GetCalculateResponse Calculate(decimal initialValue, int months)
		{
			var cdi = FeesService.GetCdiTax();
			var tb = FeesService.GetTbTax();
			var fee = FeesService.GetFeeIncome(months);

			// Cálculo de Juros Compostos
			// Valor final = Montante * (1 + Taxa) ^ Período )
			var profit = initialValue * (decimal)Math.Pow((double)(1 + cdi * tb), months) - initialValue;

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