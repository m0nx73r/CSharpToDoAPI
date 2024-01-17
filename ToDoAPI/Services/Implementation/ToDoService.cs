using System.Threading.Tasks;
using ToDoAPI.DAL.DbContexts;
using ToDoAPI.DAL.Entities;
using ToDoAPI.DAL.Repositories.Implementation;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.Services.Interface;
using AutoMapper;
using ToDoAPI.Models.ResponseModels;
using ToDoAPI.Models.RequestModels;

namespace ToDoAPI.Services.Implementation
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._toDoRepository = repository;
        }

        public async Task<ToDoResponse> CreateAsync(ToDoRequest requestItem)
        {
            var item = _mapper.Map<ToDoItem>(requestItem);

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

        public async Task<ToDoResponse> UpdateAsync(ToDoRequest requestItem)
        {
            //converting ToDoRequest to ToDoItem (entity) 
            var item = _mapper.Map<ToDoItem>(requestItem);
            var result = await _toDoRepository.UpdateAsync(item);
            //converting ToDoItem (entity) to ToDoResponse
            var response = _mapper.Map<ToDoResponse>(result);
            return response;
;        }
    }
}
