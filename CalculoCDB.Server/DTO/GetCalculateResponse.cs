namespace CalculoCDB.Server.DTO
{
	public class GetCalculateResponse
	{
		public decimal InitialValue { get; set; }
		public int Months { get; set; }
		public decimal GrossIncome { get; set; }
		public decimal NetIncome { get; set; }
		public decimal ImpostValue { get; set; }
		public decimal Fee { get; internal set; }
	}
}