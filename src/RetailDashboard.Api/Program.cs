using Microsoft.EntityFrameworkCore;
// using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Cloud Native 12-factor: Logs to stdout in JSON format
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Health checks for orchestration
builder.Services.AddHealthChecks();

// DB Context setup (Commented out as requested for future use)
/*
builder.Services.AddDbContext<RetailDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();

/*
public class RetailDbContext : DbContext
{
    public RetailDbContext(DbContextOptions<RetailDbContext> options) : base(options) { }
    
    public DbSet<RetailDashboard.Core.Models.SalesData> Sales { get; set; }
}
*/
