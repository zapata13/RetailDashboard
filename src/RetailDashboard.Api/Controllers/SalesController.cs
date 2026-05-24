using Microsoft.AspNetCore.Mvc;
using RetailDashboard.Core.Models;

namespace RetailDashboard.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;

    public SalesController(ILogger<SalesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SalesData>> Get()
    {
        _logger.LogInformation("Fetching mock sales data");

        // Mock data logic (future: replace with EF Core context)
        var mockData = new List<SalesData>
        {
            new SalesData { Id = 1, StoreName = "Downtown Hub", Date = DateTime.UtcNow.AddDays(-1), TotalSales = 12500.50m, TotalTransactions = 320 },
            new SalesData { Id = 2, StoreName = "Uptown Mall", Date = DateTime.UtcNow.AddDays(-1), TotalSales = 8900.00m, TotalTransactions = 210 },
            new SalesData { Id = 3, StoreName = "Suburban Square", Date = DateTime.UtcNow.AddDays(-1), TotalSales = 15400.75m, TotalTransactions = 405 },
            new SalesData { Id = 4, StoreName = "Airport Express", Date = DateTime.UtcNow.AddDays(-1), TotalSales = 5600.25m, TotalTransactions = 150 },
            new SalesData { Id = 5, StoreName = "Downtown Hub", Date = DateTime.UtcNow, TotalSales = 13200.00m, TotalTransactions = 335 },
            new SalesData { Id = 6, StoreName = "Downtown Hub", Date = DateTime.UtcNow, TotalSales = 15000.00m, TotalTransactions = 554 },
            new SalesData { Id = 7, StoreName = "Uptown Mall", Date = DateTime.UtcNow, TotalSales = 9100.50m, TotalTransactions = 225 }
        };

        return Ok(mockData);
    }
}
