using AutoMapper;
using ToDoAPI.DAL.Entities;
using ToDoAPI.Models.RequestModels;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoRequest, ToDoItem>();
            CreateMap<ToDoResponse, ToDoItem>().ReverseMap();
        }
    }
}
