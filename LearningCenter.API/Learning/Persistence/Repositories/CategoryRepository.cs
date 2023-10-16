using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class CategoryRepository : BaseRepository, ICategoryYSRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<CategoryYS>> ListAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task AddAsync(CategoryYS categoryYs)
    {
        await _context.Categories.AddAsync(categoryYs);
    }
    public async Task<CategoryYS> FindByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public void Update(CategoryYS categoryYs)
    {
        _context.Categories.Update(categoryYs);
    }

    public void Remove(CategoryYS categoryYs)
    {
        _context.Categories.Remove(categoryYs);
    }
}