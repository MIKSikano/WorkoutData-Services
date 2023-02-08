﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkoutApplicationServices.Data;

#nullable disable

namespace workoutapplicationservices.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230208014353_ADDEDConfigureDatabase")]
    partial class ADDEDConfigureDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkoutApplicationServices.Models.ExerciseData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.Property<int>("caloriesBurnedGoalResult")
                        .HasColumnType("int");

                    b.Property<int>("caloriesBurnedResult")
                        .HasColumnType("int");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endTimeResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("startTimeResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseDatas");
                });

            modelBuilder.Entity("WorkoutApplicationServices.Models.ExerciseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExerciseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("WorkoutApplicationServices.Models.ExerciseData", b =>
                {
                    b.HasOne("WorkoutApplicationServices.Models.ExerciseType", "ExerciseType")
                        .WithMany("ExerciseDatas")
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("WorkoutApplicationServices.Models.ExerciseType", b =>
                {
                    b.Navigation("ExerciseDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
