using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface ICategoryYSRepository
{
    Task<IEnumerable<CategoryYS>> ListAsync();
    Task AddAsync(CategoryYS categoryYs);
    Task<CategoryYS> FindByIdAsync(int id);
    void Update(CategoryYS categoryYs);
    void Remove(CategoryYS categoryYs);
}