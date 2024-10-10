using System.ComponentModel.DataAnnotations;

namespace CalculoCDB.Server.Models
{
    public class GetCalculateRequest
    {
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double InitialValue { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Months { get; set; }
    }
}