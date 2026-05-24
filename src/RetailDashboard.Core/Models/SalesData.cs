namespace RetailDashboard.Core.Models;

public class SalesData
{
    public int Id { get; set; }
    public string StoreName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal TotalSales { get; set; }
    public int TotalTransactions { get; set; }
}
