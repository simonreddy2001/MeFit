﻿// <auto-generated />
using System;
using MeFit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeFit.Migrations
{
    [DbContext(typeof(MeFitDBContext))]
    [Migration("20210618095018_updateBugFix")]
    partial class updateBugFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeFit.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressLine1 = "Drammensveien 1",
                            City = "Oslo",
                            Country = "Norway",
                            PostalCode = 2700
                        },
                        new
                        {
                            Id = 2,
                            AddressLine1 = "1st Avenue 45",
                            City = "Leeds, AL",
                            Country = "USA",
                            PostalCode = 4600
                        },
                        new
                        {
                            Id = 3,
                            AddressLine1 = "Skaugumsåsen 1",
                            City = "Asker",
                            Country = "Norway",
                            PostalCode = 4500
                        },
                        new
                        {
                            Id = 4,
                            AddressLine1 = "Lakkegata 14B",
                            City = "Oslo",
                            Country = "Norway",
                            PostalCode = 2000
                        },
                        new
                        {
                            Id = 5,
                            AddressLine1 = "Gran Vía 100",
                            City = "Madrid",
                            Country = "Spain",
                            PostalCode = 6000
                        },
                        new
                        {
                            Id = 6,
                            AddressLine1 = "Granskauen 1050F",
                            City = "Hønefoss",
                            Country = "Norway",
                            PostalCode = 4500
                        });
                });

            modelBuilder.Entity("MeFit.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TargetMuscleGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VidLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Skip on one foot for 10 seconds, than repeat on the other foot.",
                            Image = "",
                            Name = "Skips",
                            VidLink = ""
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lay on your back, bring your arms behind your head and lift your torso before you slowly lower it again.",
                            Image = "",
                            Name = "Sit-Ups",
                            VidLink = ""
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lay faced down, bring your hands to the floor on both sides next to your chest, lift your body so only your hands and toes touch the floor. When your arms are straight, lower your body steady to the floor again.",
                            Image = "",
                            Name = "Push-Ups",
                            VidLink = ""
                        });
                });

            modelBuilder.Entity("MeFit.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Achieved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Achieved = false,
                            EndDate = new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgramId = 1
                        });
                });

            modelBuilder.Entity("MeFit.Models.GoalWorkout", b =>
                {
                    b.Property<int>("GoalId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("GoalId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("GoalWorkouts");
                });

            modelBuilder.Entity("MeFit.Models.Profiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Disabilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GoalId")
                        .HasColumnType("int");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("MedicalConditions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int?>("SetId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("GoalId");

                    b.HasIndex("ProgramId");

                    b.HasIndex("SetId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Disabilities = "Dysleksia, transplanted hip",
                            Height = 187.0,
                            MedicalConditions = "Weak heart",
                            UserId = 1,
                            Weight = 94.5
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Disabilities = "",
                            Height = 198.0,
                            MedicalConditions = "",
                            UserId = 2,
                            Weight = 114.5
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            Disabilities = "",
                            Height = 193.0,
                            MedicalConditions = "",
                            UserId = 3,
                            Weight = 100.5
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 4,
                            Disabilities = "",
                            Height = 187.0,
                            MedicalConditions = "",
                            UserId = 4,
                            Weight = 94.5
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 5,
                            Disabilities = "",
                            Height = 198.0,
                            MedicalConditions = "",
                            UserId = 5,
                            Weight = 114.5
                        },
                        new
                        {
                            Id = 6,
                            AddressId = 6,
                            Disabilities = "",
                            Height = 170.0,
                            MedicalConditions = "",
                            UserId = 6,
                            Weight = 62.0
                        });
                });

            modelBuilder.Entity("MeFit.Models.ProgramWorkout", b =>
                {
                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ProgramId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ProgramWorkouts");
                });

            modelBuilder.Entity("MeFit.Models.Programs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Nomal people",
                            Name = "Basic Core Program"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Nomal people less chest",
                            Name = "Basic Chest Program"
                        });
                });

            modelBuilder.Entity("MeFit.Models.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseRepetitions")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Sets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseId = 1,
                            ExerciseRepetitions = 10,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExerciseId = 2,
                            ExerciseRepetitions = 10,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 3,
                            ExerciseId = 1,
                            ExerciseRepetitions = 10,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 4,
                            ExerciseId = 2,
                            ExerciseRepetitions = 10,
                            WorkoutId = 1
                        });
                });

            modelBuilder.Entity("MeFit.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContributor")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "harald.rex@kongehuset.no",
                            FirstName = "Harald",
                            IsAdmin = false,
                            IsContributor = false,
                            LastName = "Rex",
                            Password = "admin123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "charles.barkley@nba.com",
                            FirstName = "Charles",
                            IsAdmin = false,
                            IsContributor = false,
                            LastName = "Barkley",
                            Password = "admin123",
                            Role = "Contributer, Admin"
                        },
                        new
                        {
                            Id = 3,
                            Email = "haakon.magnus@kongehuset.no",
                            FirstName = "Haakon Magnus",
                            IsAdmin = false,
                            IsContributor = false,
                            LastName = "Crown Prince of Norway",
                            Password = "admin123",
                            Role = "User, Contributer, Admin"
                        },
                        new
                        {
                            Id = 4,
                            Email = "j_johansen@hotmail.com",
                            FirstName = "Jan",
                            IsAdmin = false,
                            IsContributor = false,
                            LastName = "Johansen",
                            Password = "admin123",
                            Role = "User, Contributer, Admin"
                        },
                        new
                        {
                            Id = 5,
                            Email = "martinmann@gmail.com",
                            FirstName = "Martin",
                            IsAdmin = false,
                            IsContributor = false,
                            LastName = "Ødegaard",
                            Password = "admin123",
                            Role = "User, Contributer, Admin"
                        },
                        new
                        {
                            Id = 6,
                            Email = "kari.nordmann@ciber.no",
                            FirstName = "Kari",
                            IsAdmin = false,
                            IsContributor = false,
                            LastName = "Nordmann",
                            Password = "admin123",
                            Role = "Contributer, Admin"
                        });
                });

            modelBuilder.Entity("MeFit.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SetId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Complete = false,
                            Name = "Basic Circle Workout",
                            SetId = 1,
                            Type = "arms"
                        },
                        new
                        {
                            Id = 2,
                            Complete = false,
                            Name = "Basic Square Workout",
                            SetId = 1,
                            Type = "legs"
                        });
                });

            modelBuilder.Entity("MeFit.Models.GoalWorkout", b =>
                {
                    b.HasOne("MeFit.Models.Goal", "Goal")
                        .WithMany("GoalWorkouts")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeFit.Models.Workout", "Workout")
                        .WithMany("GoalWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goal");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("MeFit.Models.Profiles", b =>
                {
                    b.HasOne("MeFit.Models.Address", "Address")
                        .WithMany("Profiles")
                        .HasForeignKey("AddressId");

                    b.HasOne("MeFit.Models.Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalId");

                    b.HasOne("MeFit.Models.Programs", "Program")
                        .WithMany("Profiles")
                        .HasForeignKey("ProgramId");

                    b.HasOne("MeFit.Models.Set", "Set")
                        .WithMany("Profiles")
                        .HasForeignKey("SetId");

                    b.HasOne("MeFit.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("MeFit.Models.Profiles", "UserId");

                    b.HasOne("MeFit.Models.Workout", "Workout")
                        .WithMany("Profiles")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("Address");

                    b.Navigation("Goal");

                    b.Navigation("Program");

                    b.Navigation("Set");

                    b.Navigation("User");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("MeFit.Models.ProgramWorkout", b =>
                {
                    b.HasOne("MeFit.Models.Programs", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeFit.Models.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("MeFit.Models.Set", b =>
                {
                    b.HasOne("MeFit.Models.Exercise", "Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeFit.Models.Workout", "Workout")
                        .WithMany("Sets")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("MeFit.Models.Address", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("MeFit.Models.Exercise", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("MeFit.Models.Goal", b =>
                {
                    b.Navigation("GoalWorkouts");
                });

            modelBuilder.Entity("MeFit.Models.Programs", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("MeFit.Models.Set", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("MeFit.Models.User", b =>
                {
                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MeFit.Models.Workout", b =>
                {
                    b.Navigation("GoalWorkouts");

                    b.Navigation("Profiles");

                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
