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
    public class CustomersController : Controller
    {
        private readonly APIService _APIService;

        public CustomersController(APIService aPIService)
        {
            _APIService = aPIService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _APIService.GetCutomersAsync()); ;
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _APIService.FindCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,CustomerEmail,CustomerPhone,CustomerBirthDate,CustomerAddress,CustomerZipCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = Guid.NewGuid();
                await _APIService.AddCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _APIService.FindCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustomerId,CustomerName,CustomerEmail,CustomerPhone,CustomerBirthDate,CustomerAddress,CustomerZipCode")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _APIService.UpdateCustomerAsync(id, customer);

                }
                catch (Exception)
                {
                    
                    
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _APIService.FindCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = await _APIService.FindCustomerAsync(id);
            if (customer != null)
            {
                await _APIService.DeleteCustomerAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
