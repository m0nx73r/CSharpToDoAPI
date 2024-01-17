using ToDoAPI.DAL.Entities;
using ToDoAPI.Models.RequestModels;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.Services.Interface
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoResponse>> GetToDoListAsync();
        Task<ToDoResponse> GetToDoAsync(int id);
        Task<ToDoResponse> CreateAsync(ToDoRequest item);
        Task<ToDoResponse> UpdateAsync(ToDoRequest item);
        Task<ToDoResponse> DeleteAsync(int id);
    }
}
