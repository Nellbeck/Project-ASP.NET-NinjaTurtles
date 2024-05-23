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
    public class ProductsController : Controller
    {
        private readonly APIService _APIService;

        public ProductsController(APIService APIService)
        {
            _APIService = APIService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _APIService.GetProductsAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _APIService.FindProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductPrice,ProductDescription,ProductQuantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = Guid.NewGuid();
                await _APIService.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _APIService.FindProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductId,ProductName,ProductPrice,ProductDescription,ProductQuantity")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _APIService.UpdateProductAsync(id, product);
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _APIService.FindProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _APIService.FindProductAsync(id);
            if (product != null)
            {
                await _APIService.DeleteProductAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
