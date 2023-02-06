namespace WorkoutApplicationServices.Commands;

using WorkoutApplicationServices.Models;
using System.Text.Json;

public class BuildExerciseTypeFromDictionary
{
    private Dictionary<string, object> data;

    public BuildExerciseTypeFromDictionary(Dictionary<string, object> data)
    {
        this.data = data;
        this.CleanUp();
    }

    public ExerciseType Execute()
    {
        ExerciseType exerciseType = new ExerciseType();

        if (this.data.ContainsKey("Id"))
        {
            exerciseType.Id = (int)this.data["Id"];
        }
        exerciseType.ExerciseName = (string)this.data["ExerciseName"];
        return exerciseType;
    }

    public void CleanUp()
    {
        if (this.data.ContainsKey("Id"))
        {
            if (this.data["Id"] is JsonElement)
            {
                this.data["Id"] = int.Parse(((JsonElement)this.data["Id"]).ToString());
            }
        }

        if (this.data["ExerciseName"] is JsonElement)
        {
            this.data["ExerciseName"] = ((JsonElement)this.data["ExerciseName"]).ToString();
        }   
    }
}