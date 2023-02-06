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
    //inject yung data context
    public WorkoutDataMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public void Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public List<ExerciseData> GetAll()
    {
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
            temp.exerciseType = hash.exerciseType;
            temp.date = hash.date;
            temp.startTimeResult = hash.startTimeResult;
            temp.endTimeResult = hash.endTimeResult;
            temp.caloriesBurnedResult = hash.caloriesBurnedResult;
            temp.caloriesGoalResult = hash.caloriesGoalResult;
        }
        _dataContext.SaveChanges();
    }
}