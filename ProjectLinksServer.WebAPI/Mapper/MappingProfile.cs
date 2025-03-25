using AutoMapper;
using ProjectLinksServer.WebAPI.DTOs.Category;
using ProjectLinksServer.WebAPI.DTOs.Link;
using ProjectLinksServer.WebAPI.DTOs.Project;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Mapper;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<CreateProjectDto,  Project>().ForMember(dest => dest.Links, opt => opt.MapFrom(src => src.Links));
        CreateMap<UpdateProjectDto, Project>();

        CreateMap<CreateLinkDto, Link>();
    }
}
