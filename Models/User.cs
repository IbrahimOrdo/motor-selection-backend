using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace motor_selection_backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string NameSurname { get; set; }

        [Range(16, 100)]
        public int Age { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; }

        [Required, MaxLength(20)]
        public string MaritalStatus { get; set; }

        [Required, MaxLength(100)]
        public string Occupation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AnnualIncome { get; set; }

        public int WeeklyTravelDistance { get; set; }

        [MaxLength(50)]
        public string PreferredVehicleType { get; set; }

        [MaxLength(20)]
        public string FuelType { get; set; }

        public bool HasPurchasedVehicle { get; set; }

        public int? VehiclePurchaseYear { get; set; }
    }
}
