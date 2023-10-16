using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Repositories;

public interface ITutorialYSRepository
{
    Task<IEnumerable<TutorialYS>> ListAsync();
    Task AddAsync(TutorialYS tutorialYs);
    Task<TutorialYS> FindByIdAsync(int tutorialId);
    Task<TutorialYS> FindByTitleAsync(string title);
    Task<IEnumerable<TutorialYS>> FindByCategoryIdAsync(int categoryId);
    void Update(TutorialYS tutorialYs);
    void Remove(TutorialYS tutorialYs);
}