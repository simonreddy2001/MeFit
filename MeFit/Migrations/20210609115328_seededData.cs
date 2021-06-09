using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeFit.Migrations
{
    public partial class seededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "ExerciseRepititions",
                table: "Sets",
                newName: "ExerciseRepetitions");

            migrationBuilder.RenameColumn(
                name: "Catagory",
                table: "Programs",
                newName: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProgramWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GoalWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "AddressLine3", "City", "Country", "PostalCode" },
                values: new object[,]
                {
                    { 1, "Drammensveien 1", null, null, "Oslo", "Norway", 2700 },
                    { 2, "1st Avenue 45", null, null, "Leeds, AL", "USA", 4600 },
                    { 3, "Skaugumsåsen 1", null, null, "Asker", "Norway", 4500 },
                    { 4, "Lakkegata 14B", null, null, "Oslo", "Norway", 2000 },
                    { 5, "Gran Vía 100", null, null, "Madrid", "Spain", 6000 },
                    { 6, "Granskauen 1050F", null, null, "Hønefoss", "Norway", 4500 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Image", "Name", "TargetMuscleGroup", "VidLink" },
                values: new object[,]
                {
                    { 1, "Skip on one foot for 10 seconds, than repeat on the other foot.", "", "Skips", null, "" },
                    { 2, "Lay on your back, bring your arms behind your head and lift your torso before you slowly lower it again.", "", "Sit-Ups", null, "" },
                    { 3, "Lay faced down, bring your hands to the floor on both sides next to your chest, lift your body so only your hands and toes touch the floor. When your arms are straight, lower your body steady to the floor again.", "", "Push-Ups", null, "" }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "Achieved", "EndDate", "ProgramId" },
                values: new object[] { 1, false, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 1, "Nomal people", "Basic Core Program" },
                    { 2, "Nomal people less chest", "Basic Chest Program" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsAdmin", "IsContributor", "LastName", "Role" },
                values: new object[,]
                {
                    { 1, "harald.rex@kongehuset.no", "Harald", false, false, "Rex", "Admin" },
                    { 2, "charles.barkley@nba.com", "Charles", false, false, "Barkley", "Contributer, Admin" },
                    { 3, "haakon.magnus@kongehuset.no", "Haakon Magnus", false, false, "Crown Prince of Norway", "User, Contributer, Admin" },
                    { 4, "j_johansen@hotmail.com", "Jan", false, false, "Johansen", "User, Contributer, Admin" },
                    { 5, "martinmann@gmail.com", "Martin", false, false, "Ødegaard", "User, Contributer, Admin" },
                    { 6, "kari.nordmann@ciber.no", "Kari", false, false, "Nordmann", "Contributer, Admin" }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "Complete", "Name", "SetId", "Type" },
                values: new object[,]
                {
                    { 1, false, "Basic Circle Workout", 1, "arms" },
                    { 2, false, "Basic Square Workout", 1, "legs" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "AddressId", "Disabilities", "GoalId", "Height", "MedicalConditions", "ProgramId", "SetId", "UserId", "Weight", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 1, "Dysleksia, transplanted hip", null, 187.0, "Weak heart", null, null, 1, 94.5, null },
                    { 2, 2, "", null, 198.0, "", null, null, 2, 114.5, null },
                    { 3, 3, "", null, 193.0, "", null, null, 3, 100.5, null },
                    { 4, 4, "", null, 187.0, "", null, null, 4, 94.5, null },
                    { 5, 5, "", null, 198.0, "", null, null, 5, 114.5, null },
                    { 6, 6, "", null, 170.0, "", null, null, 6, 62.0, null }
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "ExerciseId", "ExerciseRepetitions", "WorkoutId" },
                values: new object[,]
                {
                    { 1, 1, 10, 1 },
                    { 2, 2, 10, 1 },
                    { 3, 1, 10, 1 },
                    { 4, 2, 10, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Workouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProgramWorkouts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GoalWorkouts");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ExerciseRepetitions",
                table: "Sets",
                newName: "ExerciseRepititions");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Programs",
                newName: "Catagory");
        }
    }
}
