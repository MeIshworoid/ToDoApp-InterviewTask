using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.DataAccess.Layer;
using ToDo.DataAccess.Layer.Models;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _context.ToDoItems.ToListAsync();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoItem toDoItem)
        {
            if (toDoItem != null && ModelState.IsValid==true)
            {
                _context.Add(toDoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItem);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int toDoId)
        {
            var result = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == toDoId);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToDoItem toDoItem)
        {
            if(toDoItem != null && ModelState.IsValid == true)
            {
                _context.Update(toDoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItem);
        }
    }
}
