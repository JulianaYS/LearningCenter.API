using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryYSService _categoryYsService;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryYSService categoryYsService, IMapper mapper)
    {
        _categoryYsService = categoryYsService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<CategoryYSResource>> GetAllAsync()
    {
        var categories = await _categoryYsService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CategoryYS>, IEnumerable<CategoryYSResource>>(categories);

        return resources;
    }
}