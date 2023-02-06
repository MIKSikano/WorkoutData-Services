namespace WorkoutDataServices.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WorkoutApplicationServices.Interfaces;
using WorkoutApplicationServices.Commands;
using WorkoutApplicationServices.Models;

[ApiController]
[Route("exercise_type")]

public class ExerciseTypeController : ControllerBase
{
    private readonly IExerciseTypeService _exerciseTypeService;

     public ExerciseTypeController(IExerciseTypeService exerciseTypeService)
    {
        _exerciseTypeService = exerciseTypeService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("workout_data", _exerciseTypeService.GetAll());
        return Ok(data);
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateExerciseType validator = new ValidateExerciseType(hash);
        validator.Run();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            var cmd = new BuildExerciseTypeFromDictionary(hash);

            ExerciseType exerciseType = cmd.Execute();
            _exerciseTypeService.Save(exerciseType);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Exercise Type");
            return Ok(message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        ExerciseType exerciseType = _exerciseTypeService.GetById(id);
        return Ok(exerciseType);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _exerciseTypeService.Delete(id);
        return Ok("Exercise Type is Deleted");
    }
}