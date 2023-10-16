﻿namespace LearningCenter.API.Learning.Domain.Models;

public class CategoryYS
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<TutorialYS> TutorialsYs { get; set; } = new List<TutorialYS>();
}