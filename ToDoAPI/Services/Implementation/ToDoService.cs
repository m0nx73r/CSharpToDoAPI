using System.Threading.Tasks;
using ToDoAPI.DAL.DbContexts;
using ToDoAPI.DAL.Entities;
using ToDoAPI.DAL.Repositories.Implementation;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.Services.Interface;
using AutoMapper;
using ToDoAPI.Models.ResponseModels;
using ToDoAPI.Models.RequestModels;
using ToDoAPI.Models.Exceptions;


#nullable enable

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

        public async Task<int> CreateAsync(ToDoRequest requestItem)
        {
            ToDoItem item = _mapper.Map<ToDoItem>(requestItem);
            int result = await _toDoRepository.CreateAsync(item);
            return result;
        }

        public async Task<ToDoResponse> DeleteAsync(int id)
        {
            ToDoItem? result = await _toDoRepository.DeleteAsync(id);
            if(result == null)
            {
                throw new ItemNotFoundException($"No items found with the id {id}.");
            }
            ToDoResponse response = _mapper.Map<ToDoResponse>(result);
            return response;
        }

        public async Task<ToDoResponse> GetToDoAsync(int id)
        {
            ToDoItem? result = await _toDoRepository.GetToDoAsync(id);
            if(result == null)
            {
                throw new ItemNotFoundException($"No items found with the id {id}.");
            }
            ToDoResponse response = _mapper.Map<ToDoResponse>(result);
            return response;
        }

        public async Task<IEnumerable<ToDoResponse>> GetToDoListAsync()
        {
            IEnumerable<ToDoItem>? result = await _toDoRepository.GetToDoListAsync();
            if(result == null)
            {
                throw new ItemNotFoundException("No items found in the Database.");
            }
            IEnumerable<ToDoResponse> response = _mapper.Map<IEnumerable<ToDoResponse>>(result);
            return response;
        }

        public async Task<ToDoResponse> UpdateAsync(ToDoRequest requestItem)
        {
            //converting ToDoRequest to ToDoItem (entity) 
            ToDoItem item = _mapper.Map<ToDoItem>(requestItem);
            ToDoItem? result = await _toDoRepository.UpdateAsync(item);
            //converting ToDoItem (entity) to ToDoResponse
            ToDoResponse response = _mapper.Map<ToDoResponse>(result);
            return response;
;        }
    }
}
