using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;
using ToDoAPI.Repositories;

namespace ToDoAPI.Models
{
    public class ToDoRepository : IRepository
    {

        private ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context) {
            this._context = context;
        }
        public async Task<ActionResult<ToDoItem>> CreateToDoAsync(string task, DateTime startDate, DateTime endDate, string createdUserId = "system")
        {
            DateTime dt = DateTime.Now;
            ToDoItem item = new ToDoItem
            {
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
            return item;
        }

        public async Task<ActionResult<ToDoItem>> DeleteToDoAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if(todoItem == null)
            {
                return null;
            }

            todoItem.IsDeleted = true;
            todoItem.ModifiedDateTime = DateTime.Now;
            todoItem.ModifiedUserId = "system";

            await _context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<ActionResult<ToDoItem>> GetToDoAsync(int id)
        {

            var result = await _context.TodoItems.FindAsync(id);

            if (result is null)
            {
                return null;
            }

            return result;
        }

        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDosAsync()
        {
            var result = await _context.TodoItems.Where(item => item.IsDeleted == false).ToListAsync();
            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<ActionResult<ToDoItem>> UpdateToDoAsync(int id, string task, DateTime startDate, DateTime endDate, string createdUserId = "system")
        {
            ToDoItem? fieldToBeUpdated = await _context.TodoItems.FindAsync(id);

            if (fieldToBeUpdated == null)
            {
                return null;
            }
            DateTime dt = DateTime.Now;
            fieldToBeUpdated.Task = task;
            fieldToBeUpdated.StartDate = startDate;
            fieldToBeUpdated.EndDate = endDate;
            fieldToBeUpdated.CreatedUserId = createdUserId;
            fieldToBeUpdated.ModifiedDateTime = dt;
            await _context.SaveChangesAsync();
            return fieldToBeUpdated;
        }
    }
}
