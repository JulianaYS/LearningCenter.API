using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TutorialsController : ControllerBase
{
    private readonly ITutorialYSService _tutorialService;
    private readonly IMapper _mapper;

    public TutorialsController(ITutorialYSService tutorialService, IMapper mapper)
    {
        _tutorialService = tutorialService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TutorialYSResource>> GetAllAsync()
    {
        var tutorials = await _tutorialService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TutorialYS>, 
            IEnumerable<TutorialYSResource>>(tutorials);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveTutorialYSResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessage());
        var tutorial = _mapper.Map<SaveTutorialYSResource, 
            TutorialYS>(resource);
        var result = await _tutorialService.SaveAsync(tutorial);
        if (!result.Success)
            return BadRequest(result.Message);
        var tutorialResource = _mapper.Map<TutorialYS, 
            TutorialYSResource>(result.Resource);
        return Ok(tutorialResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveTutorialYSResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessage());
        var tutorial = _mapper.Map<SaveTutorialYSResource, 
            TutorialYS>(resource);
        var result = await _tutorialService.UpdateAsync(id, tutorial);
        if (!result.Success)
            return BadRequest(result.Message);
        var tutorialResource = _mapper.Map<TutorialYS, 
            TutorialYSResource>(result.Resource);
        return Ok(tutorialResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tutorialService.DeleteAsync(id);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var tutorialResource = _mapper.Map<TutorialYS, 
            TutorialYSResource>(result.Resource);
        return Ok(tutorialResource);
    }

}