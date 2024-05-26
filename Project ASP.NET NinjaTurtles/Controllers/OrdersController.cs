using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_ASP.NET_NinjaTurtles.Data;
using Project_ASP.NET_NinjaTurtles.Models;
using Project_ASP.NET_NinjaTurtles.Services;

namespace Project_ASP.NET_NinjaTurtles.Controllers
{
    public class OrdersController : Controller
    {
        private readonly APIService _service;

        public OrdersController(APIService service)
        {
            _service = service;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _service.GetOrdersAsync();

            if (orders == null)
            {
                return View(new List<Order>());
            }
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _service.FindOrderAsync(id);
            
            var getCustomer = await _service.GetCutomersAsync();
            List<Customer> customer = getCustomer.Where(x => x.CustomerId == order.FKCustomerId).ToList();

            var getProduct = await _service.GetProductsAsync();
            List<Product> products = getProduct.Where(x => x.ProductId == order.FKProductId).ToList();
            decimal price = products.Select(x => x.ProductPrice).Sum();
            decimal quantity = order.OrderQuantity;
            ViewBag.Product = products;
            ViewBag.Customer = customer;
            ViewBag.Total = price * quantity;
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        { 

            var customerListItems = _service.GetCutomersAsync().Result;
            ViewData["FKCustomerId"] = new SelectList(customerListItems, "CustomerId", "CustomerName");

            var productListItems = _service.GetProductsAsync().Result;

            ViewData["FKProductId"] = new SelectList(productListItems, "ProductId", "ProductName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,FKCustomerId,OrderDate,OrderQuantity,FKProductId")] Order order)
        {
            OrderProduct orderProduct = new OrderProduct();
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                order.OrderId = Guid.NewGuid();
                orderProduct.OrderProductId = Guid.NewGuid();
                await _service.AddOrdersAsync(order);
                orderProduct.FKProductId = order.FKProductId;
                orderProduct.FKOrderId = order.OrderId;
                await _service.AddOrderProductsAsync(orderProduct);
                return RedirectToAction(nameof(Index));
            }
            var customerListItems = await _service.GetCutomersAsync();
            ViewData["FKCustomerId"] = new SelectList(customerListItems, "CustomerId", "CustomerName");
            var productListItems = await _service.GetProductsAsync();
            ViewData["FKProductId"] = new SelectList(productListItems, "ProductId", "ProductName");
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _service.FindOrderAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var customerListItems = await _service.GetCutomersAsync();
            ViewData["FKCustomerId"] = new SelectList(customerListItems, "CustomerId", "CustomerName");
            var productListItems = await _service.GetProductsAsync();
            ViewData["FKProductId"] = new SelectList(productListItems, "ProductId", "ProductName");
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrderId,FKCustomerId,OrderDate")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateOrderAsync(id, order);
                }
                catch (Exception)
                {

                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            var customerListItems = await _service.GetCutomersAsync();
            ViewData["FKCustomerId"] = new SelectList(customerListItems, "CustomerId", "CustomerName");
            var productListItems = await _service.GetProductsAsync();
            ViewData["FKProductId"] = new SelectList(productListItems, "ProductId", "ProductName");
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _service.FindOrderAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var order = await _service.FindOrderAsync(id);
            if (order != null)
            {
                await _service.DeleteOrderAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
