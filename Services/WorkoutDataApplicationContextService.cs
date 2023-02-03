namespace WorkoutApplicationServices.Services;
using System.Collections.Generic;
using WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Configuration;
using WorkoutApplicationServices.Models;

public class WorkoutDataApplicationContextService : IWorkoutDataService
{
    public List<ExerciseData> GetAll()
    {
        return ApplicationContext.Instance.exerciseData;
    }

    public void Save(ExerciseData hash)
    {
        ApplicationContext.Instance.exerciseData.Add(hash);
    }

    public ExerciseData GetById(int id)
    {
        ExerciseData exercise = ApplicationContext.Instance.exerciseData.FirstOrDefault(i => i.Id == id);
        return exercise;
    }

    public void Delete(int id)
    {
        ExerciseData exercise = ApplicationContext.Instance.exerciseData.FirstOrDefault(i => i.Id == id);
        ApplicationContext.Instance.exerciseData.Remove(exercise);
    }
}