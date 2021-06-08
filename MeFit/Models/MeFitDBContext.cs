using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class MeFitDBContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalWorkout> GoalWorkouts { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramWorkout> ProgramWorkouts { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public MeFitDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramWorkout>().HasKey(pw => new { pw.ProgramId, pw.WorkoutId });
            modelBuilder.Entity<GoalWorkout>().HasKey(gw => new { gw.GoalId, gw.WorkoutId });
        }

        
    }
}
