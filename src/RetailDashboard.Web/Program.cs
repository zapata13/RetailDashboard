var builder = WebApplication.CreateBuilder(args);

// Cloud Native 12-factor: Logs to stdout in JSON format
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure HttpClient for calling the API (12-factor: externalized configuration)
builder.Services.AddHttpClient("RetailApi", client =>
{
    var apiUrl = builder.Configuration["ApiUrl"] ?? "http://localhost:5000";
    client.BaseAddress = new Uri(apiUrl);
});

// Health checks for orchestration
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHealthChecks("/health");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
