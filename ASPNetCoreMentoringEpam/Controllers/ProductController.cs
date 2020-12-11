using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMentoringEpam.Infrastructure;
using ASPNetCoreMentoringEpam.ViewModels;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASPNetCoreMentoringEpam.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsService _service;

        public ProductController(NorthwindContext context, IConfiguration configuration)
        {
            _service = new ProductsService(context, configuration);
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data.ToView());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public async Task<ActionResult> Create()
        {
            ViewData["Categories"] = new SelectList(await _service.GetCategoryNames());
            ViewData["Suppliers"] = new SelectList(await _service.GetSupplierNames());

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(product.ToBLL());

                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = new SelectList(await _service.GetCategoryNames());
            ViewData["Suppliers"] = new SelectList(await _service.GetSupplierNames());

            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _service.GetAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            ViewData["Categories"] = new SelectList(await _service.GetCategoryNames());
            ViewData["Suppliers"] = new SelectList(await _service.GetSupplierNames());

            return View(product.ToView());
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, product.ToBLL());
                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = new SelectList(await _service.GetCategoryNames());
            ViewData["Suppliers"] = new SelectList(await _service.GetSupplierNames());

            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}