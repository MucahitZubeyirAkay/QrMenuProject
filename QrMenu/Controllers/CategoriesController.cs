using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QrMenu.Data;
using QrMenu.Models;

namespace QrMenu.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CategoriesController(ApplicationDBContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View(_context.Categories!.Where(c=> c.StateId==1).ToList());
        }

        public ViewResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name", category.StateId);
            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            Category? category = _context.Categories!.Find(id);


            if (category == null)
            {
                return NotFound();
            }


            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name", category.StateId);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,StateId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name", category.StateId);
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            Category? category = _context.Categories!.Where(f => f.Id == id).Include(f => f.State).FirstOrDefault(f => f.Id == id);

            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _context.Categories!.Find(id)!;

            category.StateId = 0;

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
