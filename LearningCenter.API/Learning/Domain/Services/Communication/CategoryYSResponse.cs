using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class CategoryYSResponse : BaseResponse<CategoryYS>
{
    public CategoryYSResponse(string message) : base(message)
    {
    }

    public CategoryYSResponse(CategoryYS resource) : base(resource)
    {
    }
}