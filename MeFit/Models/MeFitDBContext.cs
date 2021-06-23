using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class MeFitDBContext : DbContext
    {
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalWorkout> GoalWorkouts { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<ProgramWorkout> ProgramWorkouts { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public MeFitDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
            modelBuilder.Entity<ProgramWorkout>().HasKey(pw => new { pw.ProgramId, pw.WorkoutId });
            modelBuilder.Entity<GoalWorkout>().HasKey(gw => new { gw.GoalId, gw.WorkoutId });


            modelBuilder.Entity<Address>().HasData(
               new Address { Id = 1, AddressLine1 = "Drammensveien 1", City = "Oslo", Country = "Norway", PostalCode = 2700 },
               new Address { Id = 2, AddressLine1 = "1st Avenue 45", City = "Leeds, AL", Country = "USA", PostalCode = 4600 },
               new Address { Id = 3, AddressLine1 = "Skaugumsåsen 1", City = "Asker", Country = "Norway", PostalCode = 4500 },
               new Address { Id = 4, AddressLine1 = "Lakkegata 14B", City = "Oslo", Country = "Norway", PostalCode = 2000 },
               new Address { Id = 5, AddressLine1 = "Gran Vía 100", City = "Madrid", Country = "Spain", PostalCode = 6000 },
               new Address { Id = 6, AddressLine1 = "Granskauen 1050F", City = "Hønefoss", Country = "Norway", PostalCode = 4500 }
           );

            modelBuilder.Entity<Models.Profiles>().HasData(
               new Models.Profiles
               {
                   Id = 1,
                   Email = "kari.nordmann@ciber.no",
                   AddressId = 1,
                   UserId = 1,
                   Disabilities = "Dysleksia, transplanted hip",
                   MedicalConditions = "Weak heart",
                   Weight = 94.5,
                   Height = 187.0,
               },
               new Models.Profiles
               {
                   Id = 2,
                   AddressId = 2,
                   UserId = 2,
                   Email = "charles.barkley@nba.com",
                   Disabilities = "",
                   MedicalConditions = "",
                   Weight = 114.5,
                   Height = 198.0,
               },
               new Models.Profiles
               {
                   Id = 3,
                   AddressId = 3,
                   UserId = 3,
                   Email = "haakon.magnus@kongehuset.no",
                   Disabilities = "",
                   MedicalConditions = "",
                   Weight = 100.5,
                   Height = 193.0,
               },
               new Models.Profiles
               {
                   Id = 4,
                   AddressId = 4,
                   UserId = 4,
                   Email = "j_johansen@hotmail.com",
                   Disabilities = "",
                   MedicalConditions = "",
                   Weight = 94.5,
                   Height = 187.0,
               },
               new Models.Profiles
               {
                   Id = 5,
                   AddressId = 5,
                   UserId = 5,
                   Email = "martinmann@gmail.com",
                   Disabilities = "",
                   MedicalConditions = "",
                   Weight = 114.5,
                   Height = 198.0,
               },
               new Models.Profiles
               {
                   Id = 6,
                   AddressId = 6,
                   UserId = 6,
                   Email = "kari.nordmann@ciber.no",
                   Disabilities = "",
                   MedicalConditions = "",
                   Weight = 62,
                   Height = 170,
               }
           );


            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Name = "Skips",
                    Description = "Skip on one foot for 10 seconds, than repeat on the other foot.",
                    Image = "",
                    VidLink = ""
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Sit-Ups",
                    Description = "Lay on your back, bring your arms behind your " +
                                  "head and lift your torso before you slowly lower it again.",
                    Image = "",
                    VidLink = ""
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Push-Ups",
                    Description = "Lay faced down, bring your hands to the floor on both sides " +
                                  "next to your chest, lift your body so only your hands and toes touch the floor. " +
                                  "When your arms are straight, lower your body steady to the floor again.",
                    Image = "",
                    VidLink = ""
                }
            );

            modelBuilder.Entity<Set>().HasData(
               new Set
               {
                   Id = 1,
                   ExerciseId = 1,
                   WorkoutId = 1,
                   ExerciseRepetitions = 10
               },
               new Set
               {
                   Id = 2,
                   ExerciseId = 2,
                   WorkoutId = 1,
                   ExerciseRepetitions = 10
               },
               new Set
               {
                   Id = 3,
                   ExerciseId = 1,
                   WorkoutId = 1,
                   ExerciseRepetitions = 10
               },
               new Set
               {
                   Id = 4,
                   ExerciseId = 2,
                   WorkoutId = 1,
                   ExerciseRepetitions = 10
               }
           );

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   FirstName = "Harald",
                   LastName = "Rex",
                   Email = "harald.rex@kongehuset.no",
                   Role = Role.Admin,
                   IsContributor = false,
                   IsAdmin = false
               },
               new User
               {
                   Id = 2,
                   FirstName = "Charles",
                   LastName = "Barkley",
                   Email = "charles.barkley@nba.com",
                   Role = Role.Contributer,
                   IsContributor = false,
                   IsAdmin = false
               },
               new User
               {
                   Id = 3,
                   FirstName = "Haakon Magnus",
                   LastName = "Crown Prince of Norway",
                   Email = "haakon.magnus@kongehuset.no",
                   Role = Role.User,
                   IsContributor = false,
                   IsAdmin = false
               },
               new User
               {
                   Id = 4,
                   FirstName = "Jan",
                   LastName = "Johansen",
                   Email = "j_johansen@hotmail.com",
                   Role = Role.User,
                   IsContributor = false,
                   IsAdmin = false
               },
               new User
               {
                   Id = 5,
                   FirstName = "Martin",
                   LastName = "Ødegaard",
                   Email = "martinmann@gmail.com",
                   Role = Role.User,
                   IsContributor = false,
                   IsAdmin = false
               },
               new User
               {
                   Id = 6,
                   FirstName = "Kari",
                   LastName = "Nordmann",
                   Email = "kari.nordmann@ciber.no",
                   Role = Role.Contributer,
                   IsContributor = false,
                   IsAdmin = false
               }
           );

            modelBuilder.Entity<Goal>().HasData(
               new Goal
               {
                   Id = 1,
                   EndDate = new DateTime(2021, 6, 16),
                   Achieved  = false,
                   ProgramId = 1
               }
           );

            modelBuilder.Entity<Models.Programs>().HasData(
               new Models.Programs
               {
                   Id = 1,
                   Name = "Basic Core Program",
                   Category = "Nomal people"
               },
                new Models.Programs
                {
                    Id = 2,
                    Name = "Basic Chest Program",
                    Category = "Nomal people less chest"
                }
           );

            modelBuilder.Entity<Workout>().HasData(
                new Workout
                {
                    Id = 1,
                    Name = "Basic Circle Workout",
                    Type = "arms",
                    SetId = 1
                },
                 new Workout
                 {
                     Id = 2,
                     Name = "Basic Square Workout",
                     Type = "legs",
                     SetId = 1
                 }
            );
           
        }


    }
}
