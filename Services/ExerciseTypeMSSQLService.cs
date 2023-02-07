namespace  WorkoutApplicationServices.Services;

using System.Collections.Generic;
using WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Models;
using Microsoft.EntityFrameworkCore;
using WorkoutApplicationServices.Data;
using WorkoutApplicationServices.Commands;
public class ExerciseTypeMSSQLService : IExerciseTypeService
{
    private readonly DataContext _dataContext;


    public ExerciseTypeMSSQLService(DataContext dataContext)
    {
        _dataContext = dataContext;
      
    }
    public void Delete(int Id)
    {
        ExerciseType exerciseType = _dataContext.ExerciseTypes.SingleOrDefault(o => o.Id == Id);
        _dataContext.ExerciseTypes.Remove(exerciseType);
        _dataContext.SaveChanges();
    }

    
    public List<ExerciseType> GetAll()
    {
       return _dataContext.ExerciseTypes.ToList<ExerciseType>();
    }

    public ExerciseType GetById(int Id)
    {
        return _dataContext.ExerciseTypes.SingleOrDefault(o => o.Id == Id);
    }

    public void Save(ExerciseType hash)
    {
        if(hash.Id == null || hash.Id == 0){
            _dataContext.ExerciseTypes.Add(hash);
        } else {
            ExerciseType temp = this.GetById(hash.Id);
            temp.ExerciseName = hash.ExerciseName;
        }
        _dataContext.SaveChanges();
    }
}