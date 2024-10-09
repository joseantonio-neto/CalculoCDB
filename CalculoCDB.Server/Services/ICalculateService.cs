using CalculoCDB.Server.DTO;

namespace CalculoCDB.Server.Services
{
	public interface ICalculateService
	{
		GetCalculateResponse Calculate(decimal initialValue, int months);
	}
}