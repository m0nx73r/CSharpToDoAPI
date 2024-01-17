﻿using Microsoft.AspNetCore.Mvc;
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
        public ToDoController(IToDoService service)
        {
            this._toDoService = service;   
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ToDoResponse>>> GetToDoListAsync()
        {
            var result = await _toDoService.GetToDoListAsync();

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ToDoResponse>> GetToDoAsync(int id)
        {
            var result = await _toDoService.GetToDoAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<ToDoResponse>> CreateAsync(ToDoRequest requestItem)
        {
            var result = await _toDoService.CreateAsync(requestItem);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<ToDoResponse>> DeleteAsync(int id)
        {
            var result = await _toDoService.DeleteAsync(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }


        [HttpPut("[action]/{id}")]

        public async Task<ActionResult<ToDoResponse>> UpdateAsync(ToDoRequest requestItem)
        {
            var result = await _toDoService.UpdateAsync(requestItem);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
