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
            // Compiled modeli kullan
            if (!AppContext.TryGetSwitch("Microsoft.EntityFrameworkCore.Issue.29452", out var isEnabled) || !isEnabled)
            {
                throw new InvalidOperationException("Compiled model is not enabled.");
            }

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.NameSurname).IsRequired();
        //        entity.Property(e => e.Age);
        //        entity.Property(e => e.Height);
        //        entity.Property(e => e.Weight);
        //        entity.Property(e => e.Gender); 
        //        entity.Property(e => e.MaritalStatus);
        //        entity.Property(e => e.Occupation); 
        //        entity.Property(e => e.AnnualIncome); 
        //        entity.Property(e => e.WeeklyTravelDistance);
        //        entity.Property(e => e.PreferredVehicleType);
        //        entity.Property(e => e.FuelType);
        //        entity.Property(e => e.HasPurchasedVehicle); 
        //        entity.Property(e => e.VehiclePurchaseYear);
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    //// Default test data ekleyebilirsin (opsiyonel)
        //    //modelBuilder.Entity<User>().HasData(
        //    //    new User { Id = 1, NameSurname = "John Doe", Age = 30, Height = 180.5, Weight = 75.3, Gender = "Male", MaritalStatus = "Single", Occupation = "Engineer", AnnualIncome = 50000, WeeklyTravelDistance = 200, PreferredVehicleType = "SUV", FuelType = "Hybrid", HasPurchasedVehicle = true, VehiclePurchaseYear = 2022 }
        //    //);
        //}
    }
}
