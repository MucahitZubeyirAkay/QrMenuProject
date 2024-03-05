using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QrMenu.Data;
using QrMenu.Models;

namespace QrMenu.Controllers
{
	public class FoodsController : Controller
	{
		private readonly ApplicationDBContext _context;

		public FoodsController(ApplicationDBContext context)
		{
			_context = context;
		}

        // GET: Foods
        public ViewResult Index()
        {
			return View(_context.Foods!.Where(f=> f.StateId==1).ToList());
        }

		public ActionResult Details(int? id)
		{
			Food? food = _context.Foods!.Where(f => f.Id == id).Include(f => f.State).FirstOrDefault();

			if(id==null || _context.Foods==null)
			{
				return NotFound();
			}

			return View(food);
		}
		public ViewResult Create()
		{
			ViewData["StateId"]= new SelectList(_context.Set<State>(), "Id", "Name");
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind("Id,Name,Price,Description")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name", food.StateId);
            return View(food);
        }

        public  ActionResult Edit(int? id)
        {
            Food? food = _context.Foods!.Find(id);


            if (food==null)
            {
                return NotFound();
            }

        
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name", food.StateId);
            return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,Price,Description,StateId")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Update(food);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.Set<State>(), "Id", "Name", food.StateId);
            return View(food);
        }

        public  ActionResult Delete(int? id)
        {
            Food? food = _context.Foods!.Where(f => f.Id==id).Include(f => f.State).FirstOrDefault(f => f.Id == id);

            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            return View(food);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = _context.Foods!.Find(id)!;

            food.StateId = 0;

            _context.Foods.Update(food);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

