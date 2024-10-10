using CalculoCDB.Server.Services;

namespace CalculoCDB.Server
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1118:Utility classes should not have public constructors", Justification = "Require a public Program class to implement the WebApplicationFactory in the integration tests.")]
	public class Program
	{
		private static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Dependency injection
			builder.Services.AddScoped<ICdiFeesService, FixedCdiFeesService>();
			builder.Services.AddScoped<IBankFeesService, FixedBankFeesService>();
			builder.Services.AddScoped<IImpostTaxesService, FixedImpostTaxesService>();
			builder.Services.AddScoped<ICalculateService, CalculateService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}	