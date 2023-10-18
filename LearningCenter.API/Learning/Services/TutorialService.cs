using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class TutorialService : ITutorialYSService
{
    private readonly ITutorialYSRepository _tutorialYsRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryYSRepository _categoryYsRepository;

    public TutorialService(ITutorialYSRepository tutorialYsRepository, IUnitOfWork unitOfWork, ICategoryYSRepository categoryYsRepository)
    {
        _tutorialYsRepository = tutorialYsRepository;
        _unitOfWork = unitOfWork;
        _categoryYsRepository = categoryYsRepository;
    }

    public async Task<IEnumerable<TutorialYS>> ListAsync()
    {
        return await _tutorialYsRepository.ListAsync();
    }

    public async Task<IEnumerable<TutorialYS>> ListByCategoryIdAsync(int categoryId)
    {
        return await _tutorialYsRepository.FindByCategoryIdAsync(categoryId);
    }

    public async Task<TutorialYSResponse> SaveAsync(TutorialYS tutorialYs)
    {
        // Validate CategoryId
        var existingCategory = await _categoryYsRepository.FindByIdAsync(tutorialYs.CategoryId);
        if (existingCategory == null)
            return new TutorialYSResponse("Invalid Category");
        
        // Validate Title
        var existingTutorialWithTitle = await _tutorialYsRepository.FindByTitleAsync(tutorialYs.Title);
        if (existingTutorialWithTitle != null)
            return new TutorialYSResponse("Tutorial title already exists.");
        
        try
        {
            // Add Tutorial
            await _tutorialYsRepository.AddAsync(tutorialYs);
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            // Return response
            return new TutorialYSResponse(tutorialYs);
        }
        catch (Exception e)
        {
            // Error Handling
            return new TutorialYSResponse($"An error occurred while saving the tutorial: {e.Message}");
        }
    }

    public async Task<TutorialYSResponse> UpdateAsync(int tutorialId, TutorialYS tutorialYs)
    {
        var existingTutorial = await 
            _tutorialYsRepository.FindByIdAsync(tutorialId);
 
        // Validate Tutorial
        if (existingTutorial == null)
            return new TutorialYSResponse("Tutorial not found.");
        // Validate CategoryId
        var existingCategory = await 
            _categoryYsRepository.FindByIdAsync(tutorialYs.CategoryId);
        if (existingCategory == null)
            return new TutorialYSResponse("Invalid Category");
        // Validate Title
        var existingTutorialWithTitle = await 
            _tutorialYsRepository.FindByTitleAsync(tutorialYs.Title);
        if (existingTutorialWithTitle != null && 
            existingTutorialWithTitle.Id != existingTutorial.Id)
            return new TutorialYSResponse("Tutorial title already exists.");
 
        // Modify Fields
        existingTutorial.Title = tutorialYs.Title;
        existingTutorial.Description = tutorialYs.Description;
        try
        {
           _tutorialYsRepository.Update(existingTutorial);
            await _unitOfWork.CompleteAsync();
            return new TutorialYSResponse(existingTutorial);
        }
        catch (Exception e)
        {
            // Error Handling
            return new TutorialYSResponse($"An error occurred while updating the tutorial: {e.Message}");
        }
    }

    public async Task<TutorialYSResponse> DeleteAsync(int tutorialId)
    {
        var existingTutorial = await 
            _tutorialYsRepository.FindByIdAsync(tutorialId);
 
        // Validate Tutorial
        if (existingTutorial == null)
            return new TutorialYSResponse("Tutorial not found.");
 
        try
        {
           _tutorialYsRepository.Remove(existingTutorial);
            await _unitOfWork.CompleteAsync();
            return new TutorialYSResponse(existingTutorial);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new TutorialYSResponse($"An error occurred while deleting the tutorial: {e.Message}");
        }
    }
}