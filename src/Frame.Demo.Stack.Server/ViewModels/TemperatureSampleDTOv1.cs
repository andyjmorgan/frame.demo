namespace Frame.Demo.Stack.Server.ViewModels
{

    public record TemperatureSampleDTOv1
    {
        public Int64 Time { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Location { get; set; }
    }

}
