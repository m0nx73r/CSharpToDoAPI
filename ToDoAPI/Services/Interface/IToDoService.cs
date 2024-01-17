using ToDoAPI.DAL.Entities;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.Services.Interface
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoResponse>> GetToDoListAsync();
        Task<ToDoResponse> GetToDoAsync(int id);
        Task<ToDoResponse> CreateAsync(ToDoItem item);
        Task<ToDoResponse> UpdateAsync(ToDoItem item);
        Task<ToDoResponse> DeleteAsync(int id);
    }
}
