using CalculoCDB.Server.Services;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CalculoCDB.Test
{
	[ExcludeFromCodeCoverage]
	public class CalculateServiceTest
	{
		private readonly CalculateService service;
		public CalculateServiceTest()
		{
			service = new CalculateService();
		}

		[Theory]
		[InlineData([950, 5, 997.07631141717832, 986.48414134831319, 0.225])]
		[InlineData([1000, 10, 1101.563624143253, 1081.2508993146025, 0.2])]
		[InlineData([1700, 14, 1946.5355604144136, 1903.3918373418912, 0.175])]
		[InlineData([2500, 26, 3214.8812281098294, 3107.6490438933552, 0.15])]
		public void GetCalculate_ReturnValue_NetIncome_GrossIncome_Fee(double initialValue, int months, double grossIncome, double netIncome, double fee)
		{
			// Act
			var calculateResponse = service.Calculate(initialValue, months);

			// Assert
			Assert.NotNull(calculateResponse);
			Assert.Equal(grossIncome, calculateResponse.GrossIncome);
			Assert.Equal(netIncome, calculateResponse.NetIncome);
			Assert.Equal(fee, calculateResponse.Fee);
		}

		[Fact]
		public void GetCalculate_ThrowsExceptionForZeroValue()
		{
			// Act
			Action act = () =>
			{
				service.Calculate(1000, 0);
			};

			// Assert
			Assert.Throws<ArgumentException>(act);
		}

		[Fact]
		public void GetCalculate_ThrowsExceptionForNegativeValue()
		{
			// Act
			Action act = () =>
			{
				service.Calculate(-100, 10);
			};

			// Assert
			Assert.Throws<ArgumentException>(act);
		}
	}
}
