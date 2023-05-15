using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.Domain;
using TaskManagerAPI.Repositories.TaskList;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListsController : ControllerBase
    {
        private readonly TaskManagementDbContext _context;
        private readonly ITaskListRepository taskListRepository;


        public TaskListsController(TaskManagementDbContext context, ITaskListRepository taskListRepository)
        {
            _context = context;
            this.taskListRepository = taskListRepository;
        }

        [HttpGet]
        [Route("GetAllListTask")]
        public ActionResult GetAllListTask()
        {
            var rs = taskListRepository.GetAllListTask();
            if (rs == null)
            {
                return NotFound();
            }
            return Ok(rs);
        }
        // GET: api/TaskLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> GetTaskLists()
        {
          if (_context.TaskLists == null)
          {
              return NotFound();
          }
            return await _context.TaskLists.ToListAsync();
        }

        // GET: api/TaskLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetTaskList(Guid id)
        {
          if (_context.TaskLists == null)
          {
              return NotFound();
          }
            var taskList = await _context.TaskLists.FindAsync(id);

            if (taskList == null)
            {
                return NotFound();
            }

            return taskList;
        }

        // PUT: api/TaskLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskList(Guid id, TaskList taskList)
        {
            if (id != taskList.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskListExists(id))
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

        // POST: api/TaskLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskList>> PostTaskList(TaskList taskList)
        {
          if (_context.TaskLists == null)
          {
              return Problem("Entity set 'TaskManagementDbContext.TaskLists'  is null.");
          }
            _context.TaskLists.Add(taskList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskList", new { id = taskList.Id }, taskList);
        }

        // DELETE: api/TaskLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskList(Guid id)
        {
            if (_context.TaskLists == null)
            {
                return NotFound();
            }
            var taskList = await _context.TaskLists.FindAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            _context.TaskLists.Remove(taskList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskListExists(Guid id)
        {
            return (_context.TaskLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
