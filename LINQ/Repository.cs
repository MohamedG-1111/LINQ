using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LINQ
{
    public static class Repository
    {

        public static List<Car> GetCars()
        {
            string json = File.ReadAllText("D:\\Route Tasks\\linq\\LINQ\\CAR_MOCK_DATA.json");

            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);

            return cars;

        }
        public static void PrintCars(IEnumerable<Car> cars)
        {
            const int idWidth = 4;
            const int makeWidth = 15;
            const int modelWidth = 17;
            const int yearWidth = 18;
            const int vinWidth = 20;
            const int colorWidth = 10;
            const int speedWidth = 12;

            string separator = $"+{new string('-', idWidth)}+{new string('-', makeWidth)}+{new string('-', modelWidth)}+{new string('-', yearWidth)}+{new string('-', vinWidth)}+{new string('-', colorWidth)}+{new string('-', speedWidth)}+";


            Console.WriteLine(separator);
            Console.WriteLine($"| {"Id",-idWidth}  | {"Make",-makeWidth} |   {"Model",-modelWidth} |   {"Manufactor Year",-yearWidth} | {"VIN",-vinWidth} | {"color",-colorWidth} | {"Speed",-speedWidth} |");


            Console.WriteLine(separator);

            foreach (var car in cars)
            {
                //if (car == null) return;
                string color = string.IsNullOrWhiteSpace(car.Color) ? "N/A" : car.Color;
                string speed = car.MaxSpeed == 0 ? "N/A" : car.MaxSpeed.ToString();

                Console.WriteLine($"| {car.Id,-idWidth}  | {car.Make,-makeWidth} |   {car.Model,-modelWidth} |   {car.ManufactorYear,-yearWidth} | {car.VIN,-vinWidth} | {color,-colorWidth} | {speed,-speedWidth} |");
            }


            Console.WriteLine(separator);


            Console.WriteLine($"\nCount: {cars.Count()}");
        }
    }
}
