namespace CalculoCDB.Server.Services
{
	public class FixedCdiFeesService : ICdiFeesService
	{
		private const double CdiFee = 0.009;

		public double GetCdiFee()
		{
			return CdiFee;
		}
	}
}