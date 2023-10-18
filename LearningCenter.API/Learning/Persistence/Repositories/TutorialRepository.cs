using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Shared.Persistence.Contexts;
using LearningCenter.API.Shared.Persistence.Repositories;

namespace LearningCenter.API.Learning.Persistence.Repositories;

public class TutorialRepository : BaseRepository, ITutorialYSRepository
{
    public TutorialRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<TutorialYS>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TutorialYS tutorialYs)
    {
        throw new NotImplementedException();
    }

    public Task<TutorialYS> FindByIdAsync(int tutorialId)
    {
        throw new NotImplementedException();
    }

    public Task<TutorialYS> FindByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TutorialYS>> FindByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public void Update(TutorialYS tutorialYs)
    {
        throw new NotImplementedException();
    }

    public void Remove(TutorialYS tutorialYs)
    {
        throw new NotImplementedException();
    }
}