using Web.Services;

string ApiUrl = "http://soccersimulator-core/api/simulation";
//string ApiUrl = "http://localhost:32776/api/simulation";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IWebService, WebService>();
builder.Services.AddSingleton<ILogger, Logger<WebService>>();
builder.Services.AddHttpClient("CoreHttpClient", client =>
{
	client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("CORE_API_URL"));
});

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
	pattern: "{controller=Web}/{action=Index}/{id?}");

app.Run();
