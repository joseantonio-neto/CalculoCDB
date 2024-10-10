namespace CalculoCDB.Server.Services
{
	public class FixedImpostTaxesService : IImpostTaxesService
	{
		private readonly List<Tax> ImpostTaxes =
		[
			new() { Low = 1, High = 6, Fee = 0.225 },
			new() { Low = 7, High = 12, Fee = 0.2 },
			new() { Low = 13, High = 24, Fee = 0.175 },
			new() { Low = 25, High = int.MaxValue, Fee = 0.15 }
		];

		public double GetImpostTax(int months)
		{
			return ImpostTaxes.Find(t => months >= t.Low && months <= t.High)?.Fee ?? ImpostTaxes[0].Fee;
		}
	}

	class Tax
	{
		public int Low { get; set; }
		public int High { get; set; }
		public double Fee { get; set; }
	}
}