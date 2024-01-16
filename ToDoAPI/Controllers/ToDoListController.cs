using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Entities;
using ToDoAPI.Repositories;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ToDoListController : ControllerBase
    {

        private readonly IRepository _repository;
        public ToDoListController(IRepository repository)
        {
            this._repository = repository;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDosAsync()
        {
            var result = await _repository.GetToDosAsync();

            if(result == null)
            {
                return null;
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoAsync(int id)
        {
            var result = await _repository.GetToDoAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ToDoItem>> CreateToDo(string task, DateTime startDate, DateTime endDate, string createdUserId="system")
        {
            var result = await _repository.CreateToDoAsync(
                task,
                startDate,
                endDate,
                createdUserId
                );

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> DeleteToDo(int id)
        {
            var result = await _repository.DeleteToDoAsync(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }


        [HttpPut("{id}")]

        public async Task<ActionResult<ToDoItem>> UpdateToDo(int id, string task, DateTime startDate, DateTime endDate, string createdUserId = "system")
        {
            var result = await _repository.UpdateToDoAsync(id, task, startDate, endDate, createdUserId);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
