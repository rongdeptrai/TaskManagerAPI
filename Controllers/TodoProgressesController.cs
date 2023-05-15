using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.Domain;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoProgressesController : ControllerBase
    {
        private readonly TaskManagementDbContext _context;

        public TodoProgressesController(TaskManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoProgresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoProgress>>> GetTodoProgress()
        {
          if (_context.TodoProgress == null)
          {
              return NotFound();
          }
            return await _context.TodoProgress.ToListAsync();
        }

        // GET: api/TodoProgresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoProgress>> GetTodoProgress(Guid id)
        {
          if (_context.TodoProgress == null)
          {
              return NotFound();
          }
            var todoProgress = await _context.TodoProgress.FindAsync(id);

            if (todoProgress == null)
            {
                return NotFound();
            }

            return todoProgress;
        }

        // PUT: api/TodoProgresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoProgress(Guid id, TodoProgress todoProgress)
        {
            if (id != todoProgress.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoProgressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoProgresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoProgress>> PostTodoProgress(TodoProgress todoProgress)
        {
          if (_context.TodoProgress == null)
          {
              return Problem("Entity set 'TaskManagementDbContext.TodoProgress'  is null.");
          }
            _context.TodoProgress.Add(todoProgress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoProgress", new { id = todoProgress.Id }, todoProgress);
        }

        // DELETE: api/TodoProgresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoProgress(Guid id)
        {
            if (_context.TodoProgress == null)
            {
                return NotFound();
            }
            var todoProgress = await _context.TodoProgress.FindAsync(id);
            if (todoProgress == null)
            {
                return NotFound();
            }

            _context.TodoProgress.Remove(todoProgress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoProgressExists(Guid id)
        {
            return (_context.TodoProgress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
