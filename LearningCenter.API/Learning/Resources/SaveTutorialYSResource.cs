using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Learning.Resources;

public class SaveTutorialYSResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [MaxLength(120)]
    public string Description { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}