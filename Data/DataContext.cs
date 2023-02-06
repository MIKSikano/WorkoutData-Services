namespace WorkoutApplicationServices.Data;
using Microsoft.EntityFrameworkCore;
using WorkoutApplicationServices.Models;

public class DataContext : DbContext
{
    //data na map niya
    public DbSet<ExerciseData> ExerciseDatas {get; set;}
    public DbSet<ExerciseType> ExerciseTypes {get; set;}
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}