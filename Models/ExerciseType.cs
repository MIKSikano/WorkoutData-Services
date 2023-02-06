namespace WorkoutApplicationServices.Models 
{
    public class ExerciseType
    {
        public int Id {get; set;}
        public string ExerciseName {get; set;}
        public List<ExerciseData> ExerciseDatas {get;set;}
    }
}