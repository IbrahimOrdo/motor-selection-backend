using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace motor_selection_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnnualIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeeklyTravelDistance = table.Column<int>(type: "int", nullable: false),
                    PreferredVehicleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HasPurchasedVehicle = table.Column<bool>(type: "bit", nullable: false),
                    VehiclePurchaseYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "AnnualIncome", "FuelType", "Gender", "HasPurchasedVehicle", "Height", "MaritalStatus", "NameSurname", "Occupation", "PreferredVehicleType", "VehiclePurchaseYear", "WeeklyTravelDistance", "Weight" },
                values: new object[] { 1, 30, 50000m, "Hybrid", "Male", true, 180.5, "Single", "John Doe", "Engineer", "SUV", 2022, 200, 75.299999999999997 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
