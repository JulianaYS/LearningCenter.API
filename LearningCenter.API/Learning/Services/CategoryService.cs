using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class CategoryService : ICategoryYSService
{
    private readonly ICategoryYSRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CategoryService(ICategoryYSRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<CategoryYS>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }
    public async Task<CategoryYSResponse> SaveAsync(CategoryYS category)
    {
        try
        {
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync();
            return new CategoryYSResponse(category);
        }
        catch (Exception e)
        {
            return new CategoryYSResponse($"An error occurred while saving the category: {e.Message}");
        }
    }
    public async Task<CategoryYSResponse> UpdateAsync(int id, CategoryYS category)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);
        if (existingCategory == null)
            return new CategoryYSResponse("Category not found.");
        existingCategory.Name = category.Name;
        try
        {
            _categoryRepository.Update(existingCategory);
            await _unitOfWork.CompleteAsync();
            return new CategoryYSResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryYSResponse($"An error occurred while updating the category: {e.Message}");
        }
    }
    public async Task<CategoryYSResponse> DeleteAsync(int id)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);
        if (existingCategory == null)
            return new CategoryYSResponse("Category not found.");
        try
        {
            _categoryRepository.Remove(existingCategory);
            await _unitOfWork.CompleteAsync();
            return new CategoryYSResponse(existingCategory);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CategoryYSResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
    
}