namespace CalculoCDB.Server.Services
{
	public static class FeesService
	{
		private const double CDI = 0.009;
		private const double TB = 1.08;
		private static List<Tax> Taxes = new List<Tax>
		{
			new() {Low =1, High = 6, Fee = 0.225},
			new() {Low= 7, High = 12, Fee = 0.2 },
			new() {Low= 13, High = 24, Fee = 0.175 },
			new() {Low= 24, High = int.MaxValue, Fee = 0.15 }
		};

		public static double GetCdiTax()
		{
			return CDI + 1 - 1;
		}

		public static double GetTbTax()
		{
			return TB;
		}

		public static double GetFeeIncome(int month)
		{
			return Taxes.Find(t => month >= t.Low && month <= t.High)?.Fee ?? 0;
		}
	}

	class Tax
	{
		public int Low { get; set; }
		public int High { get; set; }
		public double Fee { get; set; }
	}
}