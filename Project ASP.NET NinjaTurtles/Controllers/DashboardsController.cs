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
        public async Task <IActionResult> Index()
        {
            var orders = await _service.GetDashboardAsync();//hämtrar ordrar från apiet
            var products = await _service.GetProductsAsync();//hämtar produkter från apiet

            var groupedOrdersDate = orders
                .GroupBy(o => o.OrderDate.Date)
                .ToList();

            //MÅSTE FÅ DENNA ATT FUNKA

            //var groupedAmount = orders
            //    .GroupBy(o => o.Product.Sum(p => p.ProductPrice))
            //    .ToList();

            var ordersPerMonth = orders.ToList();

            var allProducts = products.ToList();

            var model = new DashboardViewModel
            {
                GroupedOrders = groupedOrdersDate,
                Orders = ordersPerMonth,
                Products = allProducts,
                //GroupedAmount = groupedAmount
            };

            return View(model);
        }
    }
}
