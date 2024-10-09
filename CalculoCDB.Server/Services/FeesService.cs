namespace CalculoCDB.Server.Services
{
	public static class FeesService
	{
		private const decimal CDI = 0.009M;
		private const decimal TB = 1.08M;
		private static List<Tax> Taxes = new List<Tax>
		{
			new() {Low =1, High = 6, Fee = 0.225M},
			new() {Low= 7, High = 12, Fee = 0.2M },
			new() {Low= 13, High = 24, Fee = 0.175M },
			new() {Low= 24, High = int.MaxValue, Fee = 0.15M }
		};

		public static decimal GetCdiTax()
		{
			return CDI + 1 - 1;
		}

		public static decimal GetTbTax()
		{
			return TB;
		}

		public static decimal GetFeeIncome(int month)
		{
			return Taxes.Find(t => month >= t.Low && month <= t.High)?.Fee ?? 0M;
		}
	}

	class Tax
	{
		public int Low { get; set; }
		public int High { get; set; }
		public decimal Fee { get; set; }
	}
}