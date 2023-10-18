using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class TutorialRepository : BaseRepository, ITutorialYSRepository
{
    public TutorialRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TutorialYS>> ListAsync()
    {
        return await _context.Tutorials
            .Include(p => p.CategoryYs)
            .ToListAsync();
    }

    public async Task AddAsync(TutorialYS tutorialYs)
    {
        await _context.Tutorials.AddAsync(tutorialYs);
    }

    public async Task<TutorialYS> FindByIdAsync(int tutorialId)
    {
        return await _context.Tutorials
            .Include(p => p.CategoryYs)
            .FirstOrDefaultAsync(p => p.Id == tutorialId);

    }

    public async Task<TutorialYS> FindByTitleAsync(string title)
    {
        return await _context.Tutorials
            .Include(p => p.CategoryYs)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<TutorialYS>> FindByCategoryIdAsync(int categoryId)
    {
        return await _context.Tutorials
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.CategoryYs)
            .ToListAsync();
    }

    public void Update(TutorialYS tutorialYs)
    {
        _context.Tutorials.Update(tutorialYs);
    }

    public void Remove(TutorialYS tutorialYs)
    {
        _context.Tutorials.Remove(tutorialYs);
    }
}