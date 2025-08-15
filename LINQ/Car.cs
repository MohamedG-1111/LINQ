using System;
using Newtonsoft.Json;

namespace LINQ
{
    public class Car:IEquatable<Car>
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
        //public Car(int id, string make, string model, int manufactorYear, string vIN, string color, int maxSpeed)
        //{
        //    Id = 0;
        //    Make = "Unknown";
        //    Model = "Unknown";
        //    ManufactorYear = 0;
        //    VIN = "N/A";
        //    Color = "Unspecified";
        //    MaxSpeed = 0;
        //    Id = id;
        //    Make = make;
        //    Model = model;
        //    ManufactorYear = manufactorYear;
        //    VIN = vIN;
        //    Color = color;
        //    MaxSpeed = maxSpeed;
        //}
        public Car()
        { }
        public Car(int id, string make, string model, int manufactorYear, string vIN, string color, int maxSpeed)
        {
            Id = id;
            Make = make;
            Model = model;
            ManufactorYear = manufactorYear;
            VIN = vIN;
            Color = color;
            MaxSpeed = maxSpeed;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"ID: {Id}, Make: {Make}, Model: {Model}, Year: {ManufactorYear}, VIN: {VIN}, Color: {Color}, Max Speed: {MaxSpeed} km/h";
        }

        public bool Equals(Car? other)
        {
            if (other is null) return false;
            return Id == other.Id
                && Make == other.Make
                && Model == other.Model
                && ManufactorYear == other.ManufactorYear
                && VIN == other.VIN
                && Color == other.Color
                && MaxSpeed == other.MaxSpeed;
        }

        //public override bool Equals(object? obj) => Equals(obj as Car);

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Make, Model, ManufactorYear, VIN, Color, MaxSpeed);
        }

    }
}
