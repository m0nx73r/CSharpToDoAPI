using AutoMapper;
using ToDoAPI.DAL.Entities;
using ToDoAPI.Models.RequestModels;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.MappingProfiles
{
    public class ToDoRequestMappingProfile : Profile
    {
        public ToDoRequestMappingProfile()
        {
            CreateMap<ToDoRequest, ToDoItem>();
        }
    }
}
