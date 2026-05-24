using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RetailDashboard.Core.Models;
using RetailDashboard.Web.Models;

namespace RetailDashboard.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Loading dashboard index page");

        var client = _httpClientFactory.CreateClient("RetailApi");
        var salesData = new List<SalesData>();

        try
        {
            var response = await client.GetAsync("/api/sales");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                salesData = JsonSerializer.Deserialize<List<SalesData>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<SalesData>();
            }
            else
            {
                _logger.LogWarning("Failed to retrieve sales data from API. Status Code: {StatusCode}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching data from API");
        }

        return View(salesData);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
