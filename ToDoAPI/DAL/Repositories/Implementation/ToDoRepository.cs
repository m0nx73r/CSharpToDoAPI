using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.DAL.Entities;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.DAL.DbContexts;

namespace ToDoAPI.DAL.Repositories.Implementation
{
    public class ToDoRepository : IToDoRepository
    {

        private ApplicationDbContext _dbContext;

        public ToDoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(ToDoItem item)
        {
            DateTime dt = DateTime.Now;
            item.CreatedDateTime = dt;
            item.ModifiedDateTime = dt;
            item.ModifiedUserId = "system";
            item.IsDeleted = false;

            _dbContext.Add(item);
            await _dbContext.SaveChangesAsync();
            return item.Id;
        }

        public async Task<ToDoItem> DeleteAsync(int id)
        {
            ToDoItem todoItem = await _dbContext.TodoItems.FindAsync(id);

            todoItem.IsDeleted = true;
            todoItem.ModifiedDateTime = DateTime.Now;
            todoItem.ModifiedUserId = "system";

            await _dbContext.SaveChangesAsync();

            return todoItem;
        }

        public async Task<ToDoItem> GetToDoAsync(int id)
        {

            ToDoItem result = await _dbContext.TodoItems.FindAsync(id);
            return result;
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoListAsync()
        {
            IEnumerable<ToDoItem> result = await _dbContext.TodoItems.Where(item => item.IsDeleted == false).ToListAsync();
            return result;
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem item)
        {
            ToDoItem fieldToBeUpdated = await _dbContext.TodoItems.FindAsync(item.Id);

            DateTime dt = DateTime.Now;
            fieldToBeUpdated.Task = item.Task;
            fieldToBeUpdated.StartDate = item.StartDate;
            fieldToBeUpdated.EndDate = item.EndDate;
            fieldToBeUpdated.ModifiedDateTime = dt;
            fieldToBeUpdated.ModifiedUserId = item.ModifiedUserId;
            await _dbContext.SaveChangesAsync();
            return fieldToBeUpdated;
        }
    }
}
