using System;

namespace ECS.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ECS sys = new Application.ECS(new Heater(), new TemperatureSensor(), new Window()) { HeaterThreshold = 20, WindowThreshold = 25};

            sys.Regulate();


        }
    }
}
