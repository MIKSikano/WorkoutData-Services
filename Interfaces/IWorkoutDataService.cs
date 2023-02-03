namespace WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Models;

public interface IWorkoutDataService
{
    public List<ExerciseData> GetAll();
    public void Save(ExerciseData hash);
    public ExerciseData GetById(int Id);
    public void Delete(int Id);
}