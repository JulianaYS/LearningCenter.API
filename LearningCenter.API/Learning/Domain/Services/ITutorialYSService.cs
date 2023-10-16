using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface ITutorialYSService
{
   
    Task<IEnumerable<TutorialYS>> ListAsync();
    Task<IEnumerable<TutorialYS>> ListByCategoryIdAsync(int categoryId);
    Task<TutorialYSResponse> SaveAsync(TutorialYS tutorialYs);
    Task<TutorialYSResponse> UpdateAsync(int tutorialId, TutorialYS tutorialYs);
    Task<TutorialYSResponse> DeleteAsync(int tutorialId);
    
}