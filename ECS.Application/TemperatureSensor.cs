using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Application
{
    public class TemperatureSensor : ITemperatureSensor
    {
        private readonly Random _generator = new Random(); 

        public int GetTemperature()
        {
            return _generator.Next(-5, 45);
        }
    }
}
