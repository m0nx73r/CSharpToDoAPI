using AutoMapper;
using ToDoAPI.DAL.Entities;
using ToDoAPI.Models.RequestModels;
using ToDoAPI.Models.ResponseModels;

namespace ToDoAPI.MappingProfiles
{
    public class ToDoResponseMappingProfile : Profile
    {
        public ToDoResponseMappingProfile() {
            CreateMap<ToDoResponse, ToDoItem>();
            CreateMap<ToDoItem, ToDoResponse>();
            //CreateMap<Tsource, TDestinationn>;
        }
    }
}
