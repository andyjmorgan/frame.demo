using System.ComponentModel.DataAnnotations;

namespace Frame.Demo.Stack.DBContext.Classes
{
    public record TemperatureSample
    {
        [Key]
        public int Id { get; set; }
        public string? Location { get; init; }
        public DateTime Time { get; init; }
        public int Temperature { get; init; }
    }
}
