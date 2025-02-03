using Microsoft.EntityFrameworkCore;
using motor_selection_backend.Models;

namespace motor_selection_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Default test data ekleyebilirsin (opsiyonel)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, NameSurname = "John Doe", Age = 30, Height = 180.5, Weight = 75.3, Gender = "Male", MaritalStatus = "Single", Occupation = "Engineer", AnnualIncome = 50000, WeeklyTravelDistance = 200, PreferredVehicleType = "SUV", FuelType = "Hybrid", HasPurchasedVehicle = true, VehiclePurchaseYear = 2022 }
            );
        }
    }
}
