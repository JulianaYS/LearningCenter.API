using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class TutorialYSResponse: BaseResponse<TutorialYS>
{
    public TutorialYSResponse(string message) : base(message)
    {
    }

    public TutorialYSResponse(TutorialYS resource) : base(resource)
    {
    }
}