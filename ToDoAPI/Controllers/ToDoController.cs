using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.DAL.Entities;
using ToDoAPI.DAL.Repositories.Interface;
using ToDoAPI.Models.RequestModels;
using ToDoAPI.Models.ResponseModels;
using ToDoAPI.Services.Implementation;
using ToDoAPI.Services.Interface;

namespace ToDoAPI.Controllers
{
    [ApiController]
   
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {

        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            this._toDoService = toDoService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetToDoListAsync()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                IEnumerable<ToDoResponse> result = await _toDoService.GetToDoListAsync();
                response.Body = result;

                return Ok(response);
            }
            catch(Exception ex) {

                {
                    response.Code = "500";
                    response.Errors = ex.ToString();
                    response.Message = ex.Message;
                    
                };
                return Ok(response);
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetToDoAsync(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                ToDoResponse result = await _toDoService.GetToDoAsync(id);
                response.Body = result;
                return Ok(response);
            }
            catch(Exception ex)
            {
                response.Code = "500";
                response.Errors = ex.ToString();
                response.Message = ex.Message;
                return Ok(response);
            }

        }


        [HttpPost("[action]")]
        public async Task<ActionResult<ToDoResponse>> CreateAsync(ToDoRequest requestItem)
        {
            ApiResponse response = new ApiResponse();


            try
            {
                int result = await _toDoService.CreateAsync(requestItem);
                response.Body = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Code = "500";
                response.Errors = ex.ToString();
                response.Message = ex.Message;
                return Ok(response);
            }
        }


        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<ToDoResponse>> DeleteAsync(int id)
        {

            ApiResponse response = new ApiResponse();

            try
            {
                ToDoResponse result = await _toDoService.DeleteAsync(id);

                response.Body = result;
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Code = "500";
                response.Errors = ex.ToString();
                response.Message = ex.Message;
                return Ok(response);
            }
        }


        [HttpPut("[action]/{id}")]

        public async Task<ActionResult<ToDoResponse>> UpdateAsync(ToDoRequest requestItem)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                ToDoResponse result = await _toDoService.UpdateAsync(requestItem);
                response.Body = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Code = "500";
                response.Errors = ex.ToString();
                response.Message = ex.Message;
                return Ok(response);
            }
        }
    }
}
