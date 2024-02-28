using Core.DataProviders;
using Core.DomainObjects.Entities;
using Core.Services.Generators.RoundsGenerator;
using Core.Services;
using Core.Utils;

namespace Core
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Startup));
			services.AddControllers();

			services.AddSingleton<IRandomGenerator, RandomGenerator>();
			services.AddSingleton<ITeamsDataProvider<SimpleTeamEntity>, SQLTeamsDataProvider>();
			services.AddSingleton<ISimulationService, SimulationService>();
			services.AddSingleton<IRoundsGenerator, RoundsGenerator>();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Configure the HTTP request pipeline.
			if(env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
