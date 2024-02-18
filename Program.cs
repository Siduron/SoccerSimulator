using SoccerSimulator.DataProviders;
using SoccerSimulator.Services;
using SoccerSimulator.Services.Generators.RoundsGenerator;
using SoccerSimulator.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRandomGenerator, RandomGenerator>();
builder.Services.AddSingleton<ITeamsDataProvider, SQLTeamsDataProvider>();
builder.Services.AddSingleton<ISimulationService, SimulationService>();
builder.Services.AddSingleton<IRoundsGenerator, RoundsGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Simulation/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Simulation}/{action=Index}/{id?}");

app.Run();
