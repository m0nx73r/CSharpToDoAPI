using System.Threading.Tasks;
using ToDoAPI.DAL.DbContexts;
using ToDoAPI.DAL.Entities;
using ToDoAPI.DAL.Repositories.Implementation;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.Services.Interface;
using AutoMapper;
using ToDoAPI.Models.ResponseModels;
using ToDoAPI.Models.RequestModels;
using ToDoAPI.Exceptions;


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
            ToDoEntity item = _mapper.Map<ToDoEntity>(requestItem);
            int result = await _toDoRepository.CreateAsync(item);
            return result;
        }

        public async Task<ToDoResponse> DeleteAsync(int id)
        {
            ToDoEntity? result = await _toDoRepository.DeleteAsync(id);
            if(result == null)
            {
                throw new NotFoundException($"No items found with the id {id}.");
            }
            ToDoResponse response = _mapper.Map<ToDoResponse>(result);
            return response;
        }

        public async Task<ToDoResponse> GetToDoAsync(int id)
        {
            ToDoEntity? result = await _toDoRepository.GetToDoAsync(id);
            if(result == null)
            {
                throw new NotFoundException($"No items found with the id {id}.");
            }
            ToDoResponse response = _mapper.Map<ToDoResponse>(result);
            return response;
        }

        public async Task<IEnumerable<ToDoResponse>> GetToDoListAsync()
        {
            IEnumerable<ToDoEntity>? result = await _toDoRepository.GetToDoListAsync();
            if(result == null)
            {
                throw new NotFoundException("No items found in the Database.");
            }
            IEnumerable<ToDoResponse> response = _mapper.Map<IEnumerable<ToDoResponse>>(result);
            return response;
        }

        public async Task<ToDoResponse> UpdateAsync(ToDoRequest requestItem)
        {
            //converting ToDoRequest to ToDoItem (entity) 
            ToDoEntity item = _mapper.Map<ToDoEntity>(requestItem);
            ToDoEntity? result = await _toDoRepository.UpdateAsync(item);
            //converting ToDoItem (entity) to ToDoResponse
            ToDoResponse response = _mapper.Map<ToDoResponse>(result);
            return response;
;        }
    }
}
