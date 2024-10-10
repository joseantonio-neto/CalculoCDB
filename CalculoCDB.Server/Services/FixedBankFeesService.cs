namespace CalculoCDB.Server.Services
{
	public class FixedBankFeesService : IBankFeesService
	{
		private const double BankFee = 1.08;

		public double GetBankFee()
		{
			return BankFee;
		}
	}
}