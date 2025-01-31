namespace motor_selection_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; } // Kilo
        public double Height { get; set; } // Boy
        public string? Occupation { get; set; } // Meslek
    }
}
