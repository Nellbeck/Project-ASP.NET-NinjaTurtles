using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_ASP.NET_NinjaTurtles.Models;
using Project_ASP.NET_NinjaTurtles.Services;

namespace Project_ASP.NET_NinjaTurtles.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly APIService _service;

        public DashboardsController(APIService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _service.GetDashboardAsync();//hämtrar ordrar från apiet
            var products = await _service.GetProductsAsync();//hämtar produkter från apiet

            var groupedOrdersDate = orders
                .GroupBy(o => o.OrderDate.Date)
                .OrderBy(g => g.Key)
                .ToList();

            //behöver felsöka denna för den sista datumet får alla ordrars totala priser
            var ordersAndSekPerDay = orders
                .GroupBy(o => o.OrderDate.Date)
                .Select(group => new OrderSummaryViewModel
                {
                    OrderDate = group.Key,
                    TotalAmount = group.Sum(p => p.Product.ProductPrice)
                }).ToList();


            var ordersPerMonth = orders.ToList();

            var allProducts = products.ToList();

            //grupperar produktnamn i ordrarna som gjorts i maj
            var mostPurchased = orders.Where(o => o.OrderDate.Month == 5).GroupBy(p => p.Product.ProductName).ToList();

            var model = new DashboardViewModel
            {
                GroupedOrders = groupedOrdersDate,
                Orders = ordersPerMonth,
                Products = allProducts,
                OrderSummaryViewModels = ordersAndSekPerDay,
                MostPurchased = mostPurchased
            };

            return View(model);
        }
    }
    
}
