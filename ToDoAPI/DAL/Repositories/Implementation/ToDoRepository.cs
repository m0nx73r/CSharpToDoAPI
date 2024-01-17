using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.DAL.Entities;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.DAL.DbContexts;

namespace ToDoAPI.DAL.Repositories.Implementation
{
    public class ToDoRepository : IToDoRepository
    {

        private ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ToDoItem> CreateAsync(ToDoItem item)
        {
            DateTime dt = DateTime.Now;
            ToDoItem new_item = new ToDoItem
            {
                Task = item.Task,
                StartDate = item.StartDate,
                EndDate = item.EndDate,
                CreatedUserId = item.CreatedUserId,
                CreatedDateTime = dt,
                ModifiedDateTime = dt,
                ModifiedUserId = "system",
                IsDeleted = false,
            };

            _context.Add(item);
            await _context.SaveChangesAsync();
            return new_item;
        }

        public async Task<ToDoItem> DeleteAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            todoItem.IsDeleted = true;
            todoItem.ModifiedDateTime = DateTime.Now;
            todoItem.ModifiedUserId = "system";

            await _context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<ToDoItem> GetToDoAsync(int id)
        {

            var result = await _context.TodoItems.FindAsync(id);

            if (result is null)
            {
                return null;
            }

            return result;
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoListAsync()
        {
            var result = await _context.TodoItems.Where(item => item.IsDeleted == false).ToListAsync();
            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem item)
        {
            ToDoItem fieldToBeUpdated = await _context.TodoItems.FindAsync(item.Id);

            if (fieldToBeUpdated == null)
            {
                return null;
            }
            DateTime dt = DateTime.Now;
            fieldToBeUpdated.Task = item.Task;
            fieldToBeUpdated.StartDate = item.StartDate;
            fieldToBeUpdated.EndDate = item.EndDate;
            fieldToBeUpdated.ModifiedDateTime = dt;
            fieldToBeUpdated.ModifiedUserId = item.ModifiedUserId;
            await _context.SaveChangesAsync();
            return fieldToBeUpdated;
        }
    }
}
