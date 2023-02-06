namespace WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Models;

public interface IExerciseTypeService
{
    public List<ExerciseType> GetAll();
    public void Save(ExerciseType hash);
    public ExerciseType GetById(int Id);
    public void Delete(int Id);

    
}