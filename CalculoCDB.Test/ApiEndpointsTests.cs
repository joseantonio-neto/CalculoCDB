using CalculoCDB.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Diagnostics.CodeAnalysis;

namespace CalculoCDB.Test
{
	[ExcludeFromCodeCoverage]
	public class ApiEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly WebApplicationFactory<Program> _factory;

		public ApiEndpointsTests(WebApplicationFactory<Program> factory)
		{
			_factory = factory;
		}

		[Theory]
		[InlineData("/calculate?initialValue=1000.0&months=10")]
		public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
		{
			// Arrange
			var client = _factory.CreateClient();

			// Act
			var response = await client.GetAsync(url);

			// Assert
			response.EnsureSuccessStatusCode(); // Status Code 200-299
			Assert.Equal("application/json; charset=utf-8", response.Content?.Headers?.ContentType?.ToString());
		}

		[Theory]
		[InlineData("/calculate?initialValue=teste&months=teste")]
		[InlineData("/calculate?initialValue=0&months=10")]
		[InlineData("/calculate?initialValue=1000&months=-100")]
		public async Task Get_EndpointsReturnBadRequest(string url)
		{
			// Arrange
			var client = _factory.CreateClient();

			// Act
			var response = await client.GetAsync(url);

			// Assert
			Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode); // Status Code 400
		}
	}
}