using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Application
{
    public class FakeTemperatureSensor : ITemperatureSensor
    {
        public int TemperatureWillBe = 0;

        public int GetTemperature()
        {
            return TemperatureWillBe;
        }
    }
}
