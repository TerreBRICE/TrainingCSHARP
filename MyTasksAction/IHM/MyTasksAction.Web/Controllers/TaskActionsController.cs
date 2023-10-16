using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyTasksAction.Core.Entities;
using MyTasksAction.Infrastructure.Data;

namespace MyTasksAction.Web.Controllers
{
    public class TaskActionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskActionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskActions
        public async Task<IActionResult> Index()
        {
              return _context.TaskAction != null ? 
                          View(await _context.TaskAction.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TaskAction'  is null.");
        }

        // GET: TaskActions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TaskAction == null)
            {
                return NotFound();
            }

            var taskAction = await _context.TaskAction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskAction == null)
            {
                return NotFound();
            }

            return View(taskAction);
        }

        // GET: TaskActions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,Priority,AssignBy,AssignTo,Status")] TaskAction taskAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskAction);
        }

        // GET: TaskActions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TaskAction == null)
            {
                return NotFound();
            }

            var taskAction = await _context.TaskAction.FindAsync(id);
            if (taskAction == null)
            {
                return NotFound();
            }
            return View(taskAction);
        }

        // POST: TaskActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Description,DueDate,Priority,AssignBy,AssignTo,Status")] TaskAction taskAction)
        {
            if (id != taskAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskActionExists(taskAction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskAction);
        }

        // GET: TaskActions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TaskAction == null)
            {
                return NotFound();
            }

            var taskAction = await _context.TaskAction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskAction == null)
            {
                return NotFound();
            }

            return View(taskAction);
        }

        // POST: TaskActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TaskAction == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaskAction'  is null.");
            }
            var taskAction = await _context.TaskAction.FindAsync(id);
            if (taskAction != null)
            {
                _context.TaskAction.Remove(taskAction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskActionExists(string id)
        {
          return (_context.TaskAction?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
