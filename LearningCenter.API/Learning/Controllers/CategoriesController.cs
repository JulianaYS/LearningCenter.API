using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using LearningCenter.API.Shared.Extensions;
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
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCategoryYSResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessage());

        var category = _mapper.Map<SaveCategoryYSResource, CategoryYS>(resource);

        var result = await _categoryYsService.SaveAsync(category);

        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<CategoryYS, CategoryYSResource>(result.Resource);

        return Ok(categoryResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryYSResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessage());
        
        var category = _mapper.Map<SaveCategoryYSResource, CategoryYS>(resource);
        var result = await _categoryYsService.UpdateAsync(id, category);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<CategoryYS, CategoryYSResource>(result.Resource);

        return Ok(categoryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _categoryYsService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var categoryResource = _mapper.Map<CategoryYS, CategoryYSResource>(result.Resource);

        return Ok(categoryResource);
    }
}