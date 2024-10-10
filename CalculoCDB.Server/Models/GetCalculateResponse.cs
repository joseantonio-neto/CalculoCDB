namespace CalculoCDB.Server.Models
{
    public class GetCalculateResponse
    {
        public double InitialValue { get; set; }
        public int Months { get; set; }
        public double GrossIncome { get; set; }
        public double NetIncome { get; set; }
        public double ImpostValue { get; set; }
        public double Fee { get; internal set; }
    }
}