namespace Api.Megaman.Application.Mapping
{
    using Api.Megaman.Application.DTO;
    using Api.Megaman.Domain.Models;
    using AutoMapper;
    using System;
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        { 
            CreateMap<Robot, RobotReadDTO>().ReverseMap();
            CreateMap<Robot, RobotCreateDTO>().ReverseMap();
        }
    }
}
