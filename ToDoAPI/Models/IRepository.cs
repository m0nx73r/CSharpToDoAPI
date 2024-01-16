using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Entities;

namespace ToDoAPI.Repositories
{
    public interface IRepository
    {
        Task<ActionResult<IEnumerable<ToDoItem>>> GetToDosAsync();
        Task<ActionResult<ToDoItem>> GetToDoAsync(int id);
        Task<ActionResult<ToDoItem>> CreateToDoAsync(string task, DateTime startDate, DateTime endDate, string createdUserId = "system");
        Task<ActionResult<ToDoItem>> DeleteToDoAsync(int id);
        Task<ActionResult<ToDoItem>> UpdateToDoAsync(int id, string task, DateTime startDate, DateTime endDate, string createdUserId = "system");
    }
}
