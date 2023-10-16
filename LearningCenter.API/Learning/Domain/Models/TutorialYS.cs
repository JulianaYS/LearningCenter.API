﻿namespace LearningCenter.API.Learning.Domain.Models;

public class TutorialYS
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public int CategoryId { get; set; }
    public CategoryYS CategoryYs { get; set; }
}