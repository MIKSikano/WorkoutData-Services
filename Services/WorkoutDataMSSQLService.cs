namespace  WorkoutApplicationServices.Services;

using System.Collections.Generic;
using WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Models;
using Microsoft.EntityFrameworkCore;
using WorkoutApplicationServices.Data;
using WorkoutApplicationServices.Commands;
public class WorkoutDataMSSQLService : IWorkoutDataService
{

    private readonly DataContext _dataContext;
    private readonly IExerciseTypeService _exerciseTypeService;
    //inject yung data context
    public WorkoutDataMSSQLService(DataContext dataContext, IExerciseTypeService exerciseTypeService)
    {
        _dataContext = dataContext;
        _exerciseTypeService = exerciseTypeService;
    }
    public void Delete(int Id)
    {
        ExerciseData exercise = _dataContext.ExerciseDatas.SingleOrDefault(o => o.Id == Id);
        _dataContext.ExerciseDatas.Remove(exercise);
        _dataContext.SaveChanges();
        
    }

    //para makita yung exerciseType dun kay workoutData
    public List<ExerciseData> GetAll()
    {
        // List<ExerciseData> exerciseData = _dataContext.ExerciseDatas.ToList<ExerciseData>();
        // foreach (ExerciseData item in exerciseData)
        // {
        //     item.ExerciseType = _exerciseTypeService.GetById(item.ExerciseTypeId);
        // } 
        // return exerciseData;
         return _dataContext.ExerciseDatas.ToList<ExerciseData>();
    }

    public ExerciseData GetById(int Id)
    {
        return _dataContext.ExerciseDatas.SingleOrDefault(o => o.Id == Id);
    }


    //this includes update
    public void Save(ExerciseData hash)
    {
       //add to the dataset
       //lambda function
       //return intance of WorkoutDatas
        if (hash.Id == null || hash.Id == 0){
            _dataContext.ExerciseDatas.Add(hash);
        } else {
            ExerciseData temp = this.GetById(hash.Id);
            // temp.exerciseType = hash.exerciseType;
            temp.date = hash.date;
            temp.startTimeResult = hash.startTimeResult;
            temp.endTimeResult = hash.endTimeResult;
            temp.caloriesBurnedResult = hash.caloriesBurnedResult;
            temp.caloriesBurnedGoalResult = hash.caloriesBurnedGoalResult;
        }
        _dataContext.SaveChanges();
    }

    
}