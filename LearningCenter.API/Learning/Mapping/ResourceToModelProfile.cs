using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Resources;

namespace LearningCenter.API.Learning.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCategoryYSResource, CategoryYS>();
        CreateMap<SaveTutorialYSResource, TutorialYS>();
    }
    
}