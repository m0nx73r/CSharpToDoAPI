using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DAL.Entities;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.DAL.Repositories.Interface
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoEntity>> GetToDoListAsync();
        Task<ToDoEntity> GetToDoAsync(int id);
        Task<int> CreateAsync(ToDoEntity item);
        Task<ToDoEntity> DeleteAsync(int id);
        Task<ToDoEntity> UpdateAsync(ToDoEntity item);
    }
}
