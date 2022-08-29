using System;

namespace ConsoleApp1
{ 
    public class Forecast
    {
        public int Temperature {get; set;}
        public int Presure { get; set; }
    }
    class Application
    {
        public static void  ChangeTheString(string weather)
        {
            weather = "sunny";
        }

        public static void ChangeTheArray(string[] rainyDays)
        {
            rainyDays[1] = "sunday";
        }

        public static void ChangeTheClassInstance(Forecast forcast)
        {
            forcast.Temperature = 35;
        }
        static void Main(string[] args)
        {
            string weather = "rainy";
            ChangeTheString(weather);
            Console.WriteLine("the weather is " + weather);

            string[] rainyDays = new[] { "Monday", "Friday" };
            ChangeTheArray(rainyDays);
            Console.WriteLine("The Rainy days were on " + rainyDays[0] + " and " + rainyDays[1]);

            Forecast forcast = new Forecast { Presure = 700, Temperature = 20 };
            ChangeTheClassInstance(forcast);
            Console.WriteLine("The temperature is " + forcast.Temperature + "*C");
        }
    }
}
