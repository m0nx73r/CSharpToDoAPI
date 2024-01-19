using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ToDoAPI.Models.ResponseModels
{
    public class ApiResponse
    {
        public string Code { get; set; } = "200";

        public string Message { get; set; } = "Success";
        public object Body { get; set; }
        public object Errors { get; set; } = null;
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString();
        public string CorrelationID { get; set; } = Guid.NewGuid().ToString();


    }
}
