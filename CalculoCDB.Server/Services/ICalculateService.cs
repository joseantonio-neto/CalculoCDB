using CalculoCDB.Server.Models;

namespace CalculoCDB.Server.Services
{
    public interface ICalculateService
	{
		GetCalculateResponse Calculate(double initialValue, int months);
	}
}