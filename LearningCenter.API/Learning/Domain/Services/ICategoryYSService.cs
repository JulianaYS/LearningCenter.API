using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface ICategoryYSService
{
    Task<IEnumerable<CategoryYS>> ListAsync();
    Task<CategoryYSResponse> SaveAsync(CategoryYS categoryYs);
    Task<CategoryYSResponse> UpdateAsync(int id, CategoryYS categoryYs);
    Task<CategoryYSResponse> DeleteAsync(int id);

}