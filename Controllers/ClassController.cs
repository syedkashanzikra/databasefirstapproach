using DBFirstApproach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApproach.Controllers
{
	public class ClassController : Controller
	{
		private readonly ILogger<ClassController> _logger;
		private readonly SchoolContext _context;

		public ClassController(ILogger<ClassController> logger,SchoolContext context)
		{
			_logger = logger;
			_context = context;
		}
		// GET: ClassController
		[Route("/Class")]
		[Route("/ViewClasses")]
		public ActionResult Classes()
		{

			var data = _context.Classes.ToList();
			return View(data);
		}

		// GET: ClassController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ClassController/Create
		public ActionResult CreateClasses()
		{
			return View();
		}

		// POST: ClassController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateClasses(Class classes)
		{
			if (ModelState.IsValid)
			{
                _context.Classes.Add(classes);
                _context.SaveChanges();
                return RedirectToAction("Classes");


            }
			return View(classes);
		}

        // GET: ClassController/Edit/5
        public ActionResult EditClass(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var classes = _context.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();

            }
            return View(classes);

        }

        // POST: ClassController/Edit/5
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditClass(Class classes)
		{
            if (ModelState.IsValid)
            {
                _context.Classes.Update(classes);
                _context.SaveChanges();
                return RedirectToAction("Classes");
            }

            return View(classes);
        }

        // GET: ClassController/Delete/5
        public ActionResult DeleteClasses(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var classes = _context.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();

            }
            return View(classes);
        }


        // POST: ClassController/Delete/5
        [HttpPost, ActionName("DeleteClasses")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClassesData(int id)
        {
            var classes = _context.Classes.Find(id);
            if (classes == null)
            {
                return BadRequest();
            }
            _context.Classes.Remove(classes);
            _context.SaveChanges();

            return RedirectToAction("Classes");

        }
    }
}
