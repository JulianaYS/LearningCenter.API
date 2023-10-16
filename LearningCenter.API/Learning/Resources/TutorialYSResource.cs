using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Resources;

public class TutorialYSResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CategoryYSResource CategoryYs { get; set; }
}