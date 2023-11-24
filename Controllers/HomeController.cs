using LinkApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Links.ToListAsync());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Link? link = await db.Links.FirstOrDefaultAsync(p => p.Id == id);
                if (link != null) return View(link);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> TransistionToShortUrl(int? id)
        {
            var shortUrl = TransistionMethod.ToShortUrl(id, db);
            if (shortUrl != null)
            {
                return Redirect(shortUrl);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Link link)
        {
            if (ModelState.IsValid)
            {
                await Crud.Edit(link, db);
                return RedirectToAction("Index");
            } 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Link link)
        {
            if (ModelState.IsValid)
            {
                await Crud.Create(link, db);
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                await Crud.Delete(id, db);
            }
            return RedirectToAction("Index");
        }
    }
}