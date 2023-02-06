namespace WorkoutApplicationServices.Commands;

using WorkoutApplicationServices.Models;
using System.Text.Json;

public class BuildWorkoutDataFromDictionary
{
    private Dictionary<string, object> data;

    public BuildWorkoutDataFromDictionary(Dictionary<string, object> data)
    {
        this.data = data;
        this.CleanUp();
    }

    public ExerciseData Execute()
    {
        ExerciseData exerciseData = new ExerciseData();

        if (this.data.ContainsKey("id"))
        {
            exerciseData.Id = (int)this.data["id"];
        }
        exerciseData.date = (string)this.data["date"];
        exerciseData.startTimeResult = (string)this.data["startTimeResult"];
        exerciseData.endTimeResult = (string)this.data["endTimeResult"];
        exerciseData.caloriesBurnedResult = (int)this.data["caloriesBurnedResult"];
        exerciseData.caloriesGoalResult = (int)this.data["caloriesBurnedGoalResult"];
        exerciseData.ExerciseTypeId = int.Parse(this.data["ExerciseTypeId"].ToString());

        return exerciseData;
    }

    public void CleanUp()
    {
        if (this.data.ContainsKey("id"))
        {
            if (this.data["id"] is JsonElement)
            {
                this.data["id"] = int.Parse(((JsonElement)this.data["id"]).ToString());
            }
        }

        // if (this.data["exerciseType"] is JsonElement)
        // {
        //     this.data["exerciseType"] = ((JsonElement)this.data["exerciseType"]).ToString();
        // }

        if (this.data["date"] is JsonElement)
        {
            this.data["date"] = ((JsonElement)this.data["date"]).ToString();
        }   

        if (this.data["startTimeResult"] is JsonElement)
        {
            this.data["startTimeResult"] = ((JsonElement)this.data["startTimeResult"]).ToString();
        }

        if (this.data["endTimeResult"] is JsonElement)
        {
            this.data["endTimeResult"] = ((JsonElement)this.data["endTimeResult"]).ToString();
        }

        if (this.data["caloriesBurnedResult"] is JsonElement)
        {
            this.data["caloriesBurnedResult"] = int.Parse(((JsonElement)this.data["caloriesBurnedResult"]).ToString());
        }

        if (this.data["caloriesBurnedGoalResult"] is JsonElement)
        {
            this.data["caloriesBurnedGoalResult"] = int.Parse(((JsonElement)this.data["caloriesBurnedGoalResult"]).ToString());
        }
    }
}