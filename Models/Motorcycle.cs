namespace motor_selection_backend.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public int EngineSize { get; set; } // Motor hacmi
        public string? SuitableFor { get; set; } // Uygun olduğu kullanıcı profili
    }
}
