using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNetCoreMentoringEpam.Infrastructure;
using ASPNetCoreMentoringEpam.ViewModels;

namespace ASPNetCoreMentoringEpam.Controllers
{
    public class CategoryController : Controller
    {
        readonly CategoriesService _service;

        public CategoryController(NorthwindContext context)
        {
            _service = new CategoriesService(context);
        }

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data.ToView());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(/*[Bind("CategoryName,Description,Picture")]*/ CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            
            await _service.CreateAsync(category.ToBLL());

            return RedirectToAction(nameof(Index));
        }

        // GET: Category/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var category = await _service.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            return View(category.ToView());
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, category.ToBLL());
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
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