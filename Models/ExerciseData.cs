namespace WorkoutApplicationServices.Models;

public class ExerciseData
{
    public int Id {get; set;}
    public string date {get; set;}
    public string startTimeResult {get; set;}
    public string endTimeResult {get; set;}
    public int caloriesBurnedResult {get; set;}
    public int caloriesBurnedGoalResult {get; set;}
    public int ExerciseTypeId {get; set;}
    public ExerciseType ExerciseType {get; set;}
    public ExerciseData()
    {
        
    }
}