namespace WorkoutDataServices.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Commands;
using WorkoutApplicationServices.Models;

[ApiController]
[Route("workout_data")]
public class WorkoutDataController : ControllerBase
{
    private readonly IWorkoutDataService _workoutDataService;

    public WorkoutDataController(IWorkoutDataService workoutDataService)
    {
        _workoutDataService = workoutDataService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<ExerciseData> exerciseData = _workoutDataService.GetAll();
        return Ok(exerciseData);
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateWorkoutData validator = new ValidateWorkoutData(hash);
        validator.Tapusin();

        if (validator.MayError())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            var cmd = new BuildWorkoutDataFromDictionary(hash);

            ExerciseData exerciseData = cmd.Execute();
            _workoutDataService.Save(exerciseData);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Workout Data Added, ayaw na maging panda");
            return Ok(message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        ExerciseData exerciseData = _workoutDataService.GetById(id);
        return Ok(exerciseData);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _workoutDataService.Delete(id);
        return Ok("Workout Data is Deleted");
    }
}
