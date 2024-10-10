using CalculoCDB.Server.Services;
using System.Diagnostics.CodeAnalysis;

namespace CalculoCDB.Test
{
	[ExcludeFromCodeCoverage]
	public class CalculateServiceTest
	{
		public class ZeroImpostTaxesServiceMock : IImpostTaxesService
		{
			public double GetImpostTax(int months)
			{
				return 0;
			}
		}
		public class ImpostTaxesServiceMock : IImpostTaxesService
		{
			public double GetImpostTax(int months)
			{
				if (months <= 5)
					return 0.1;
				else if (months <= 10)
					return 0.2;
				else if (months <= 20)
					return 0.3;
				else
					return 0.4;
			}
		}
		public class BankFeesServiceMock : IBankFeesService
		{
			public double GetBankFee()
			{
				return 1;
			}
		}
		public class CdiFeesServiceMock : ICdiFeesService
		{
			public double GetCdiFee()
			{
				return 0.05;
			}
		}

		private readonly ICalculateService service;
		public CalculateServiceTest()
		{
			service = new CalculateService(new CdiFeesServiceMock(), new BankFeesServiceMock(), new ImpostTaxesServiceMock());
		}

		[Theory]
		[InlineData([950, 5, 1212.4674843750004, 1186.2207359375004, 0.1])]
		[InlineData([1000, 10, 1628.894626777442, 1503.1157014219536, 0.2])]
		[InlineData([1700, 14, 3365.8837190469776, 2866.118603332884, 0.3])]
		[InlineData([2500, 26, 8889.1817198608951, 6333.5090319165374, 0.4])]
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
		public void GetCalculate_ImpostTaxZero_NetIncome_Equal_GrossIncome()
		{
			var zeroImpostTaxCalculateService = new CalculateService(new CdiFeesServiceMock(), new BankFeesServiceMock(), new ZeroImpostTaxesServiceMock());

			// Act
			var calculateResponse = zeroImpostTaxCalculateService.Calculate(1000, 10);

			// Assert
			Assert.NotNull(calculateResponse);
			Assert.Equal(calculateResponse.NetIncome, calculateResponse.GrossIncome);
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
