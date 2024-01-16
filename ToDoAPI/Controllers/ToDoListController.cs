using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToDoListController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDosAsync()
        {
            var result = await _context.TodoItems.Where(item => item.IsDeleted == false).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoAsync(int id)
        {
            var result = await _context.TodoItems.FindAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ToDoItem>> CreateToDo(string task, DateTime startDate, DateTime endDate, string createdUserId="system")
        {
            DateTime dt = DateTime.Now;
            ToDoItem item = new ToDoItem {
                Task = task,
                StartDate = startDate,
                EndDate = endDate,
                CreatedUserId = createdUserId,
                CreatedDateTime = dt,
                ModifiedDateTime = dt,
                ModifiedUserId = "system",
                IsDeleted = false,
            };

            _context.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> DeleteToDo(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.IsDeleted = true;
            todoItem.ModifiedDateTime = DateTime.Now;
            todoItem.ModifiedUserId = "system";

            await _context.SaveChangesAsync();

            return Ok(todoItem);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult<ToDoItem>> UpdateToDo(int id, string task, DateTime startDate, DateTime endDate, string createdUserId = "system")
        {
            ToDoItem? fieldToBeUpdated = await _context.TodoItems.FindAsync(id);

            if (fieldToBeUpdated == null)
            {
                return NotFound();
            }
            DateTime dt = DateTime.Now; 
            fieldToBeUpdated.Task = task;
            fieldToBeUpdated.StartDate = startDate;
            fieldToBeUpdated.EndDate = endDate;
            fieldToBeUpdated.CreatedUserId = createdUserId;
            fieldToBeUpdated.ModifiedDateTime = dt;
            await _context.SaveChangesAsync();
            return Ok(fieldToBeUpdated); 
        }

    }
}
