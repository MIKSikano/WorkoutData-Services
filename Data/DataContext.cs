namespace WorkoutApplicationServices.Data;
using Microsoft.EntityFrameworkCore;
using WorkoutApplicationServices.Models;

public class DataContext : DbContext
{
    //data na map niya
    public DbSet<ExerciseData> ExerciseDatas {get; set;}
    public DbSet<ExerciseType> ExerciseTypes {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseData>()
            .HasOne(d => d.ExerciseType)
            .WithMany(t => t.ExerciseDatas);
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}