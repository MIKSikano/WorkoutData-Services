namespace WorkoutApplicationServices.Configuration;
using WorkoutApplicationServices.Models;

public class ApplicationContext
{
    public List<ExerciseData> exerciseData;

    private static ApplicationContext instance = null;

    public static ApplicationContext Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ApplicationContext();
            }
            return instance;
        }
    }

    // public ApplicationContext()
    // {
    //     this.exerciseData = new List<ExerciseData>();
    //     ExerciseData exerciseData1 = new ExerciseData
    //     {
    //         Id = 1,
    //         exerciseType = "Cycling",
    //         date = "2023-01-19",
    //         startTimeResult = "15:00",
    //         endTimeResult = "16:00",
    //         caloriesBurnedResult = 256,
    //         caloriesGoalResult = 500
    //     };

    //     ExerciseData exerciseData2 = new ExerciseData
    //     {
    //         Id = 2,
    //         exerciseType = "Running",
    //         date = "2023-01-20",
    //         startTimeResult = "14:00",
    //         endTimeResult = "16:00",
    //         caloriesBurnedResult = 700,
    //         caloriesGoalResult = 600
    //     };

    //     exerciseData.Add(exerciseData1);
    //     exerciseData.Add(exerciseData2);
    // }
}
