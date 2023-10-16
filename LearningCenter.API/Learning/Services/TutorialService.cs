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

    public Task<IEnumerable<TutorialYS>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TutorialYS>> ListByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<TutorialYSResponse> SaveAsync(TutorialYS tutorialYs)
    {
        throw new NotImplementedException();
    }

    public Task<TutorialYSResponse> UpdateAsync(int tutorialId, TutorialYS tutorialYs)
    {
        throw new NotImplementedException();
    }

    public Task<TutorialYSResponse> DeleteAsync(int tutorialId)
    {
        throw new NotImplementedException();
    }
}