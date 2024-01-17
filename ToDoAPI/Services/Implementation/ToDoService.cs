using System.Threading.Tasks;
using ToDoAPI.DAL.DbContexts;
using ToDoAPI.DAL.Entities;
using ToDoAPI.DAL.Repositories.Implementation;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.Services.Interface;
using AutoMapper;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.Services.Implementation
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository repository)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ToDoItem, ToDoResponse>());
            this._mapper = config.CreateMapper();
            this._toDoRepository = repository;
        }

        public async Task<ToDoResponse> CreateAsync(ToDoItem item)
        {
            var result = await _toDoRepository.CreateAsync(item);
            var response = _mapper.Map<ToDoResponse>(result);
            return response;
        }

        public async Task<ToDoResponse> DeleteAsync(int id)
        {
            var result = await _toDoRepository.DeleteAsync(id);
            var response = _mapper.Map<ToDoResponse>(result);
            return response;
        }

        public async Task<ToDoResponse> GetToDoAsync(int id)
        {
            var result = await _toDoRepository.GetToDoAsync(id);
            var response = _mapper.Map<ToDoResponse>(result);
            return response;
        }

        public async Task<IEnumerable<ToDoResponse>> GetToDoListAsync()
        {
            var result = await _toDoRepository.GetToDoListAsync();
            var response = _mapper.Map<IEnumerable<ToDoResponse>>(result);
            return response;
        }

        public async Task<ToDoResponse> UpdateAsync(ToDoItem item)
        {
            var result = await _toDoRepository.UpdateAsync(item);
            var response = _mapper.Map<ToDoResponse>(result);
            return response;
;        }
    }
}
