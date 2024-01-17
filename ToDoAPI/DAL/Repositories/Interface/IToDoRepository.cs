using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DAL.Entities;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.DAL.Repositories.Interface
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoItem>> GetToDoListAsync();
        Task<ToDoItem> GetToDoAsync(int id);
        Task<int> CreateAsync(ToDoItem item);
        Task<ToDoItem> DeleteAsync(int id);
        Task<ToDoItem> UpdateAsync(ToDoItem item);
    }
}
