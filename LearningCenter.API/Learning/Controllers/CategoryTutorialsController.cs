using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/categories/{categoryId}/tutorials")]
public class CategoryTutorialsController : ControllerBase
{
    private readonly ITutorialYSService _tutorialService;
    private readonly IMapper _mapper;
    
    public CategoryTutorialsController(ITutorialYSService tutorialService, IMapper mapper)
    {
        _tutorialService = tutorialService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TutorialYSResource>> GetAllByCategoryIdAsync(int categoryId)
    {
        var tutorials = await _tutorialService.ListByCategoryIdAsync(categoryId);

        var resources = _mapper.Map<IEnumerable<TutorialYS>, IEnumerable<TutorialYSResource>>(tutorials);

        return resources;
    }

}