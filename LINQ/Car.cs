using System;
using Newtonsoft.Json;

namespace LINQ
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        [JsonProperty("Manufactor Year")]
        public int ManufactorYear { get; set; }

        public string VIN { get; set; }
        public string Color { get; set; }

        [JsonProperty("Max Speed")]
        public int MaxSpeed { get; set; }

        // Default Constructor
        public Car()
        {
            Id = 0;
            Make = "Unknown";
            Model = "Unknown";
            ManufactorYear = 0;
            VIN = "N/A";
            Color = "Unspecified";
            MaxSpeed = 0;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"ID: {Id}, Make: {Make}, Model: {Model}, Year: {ManufactorYear}, VIN: {VIN}, Color: {Color}, Max Speed: {MaxSpeed} km/h";
        }
    }
}
