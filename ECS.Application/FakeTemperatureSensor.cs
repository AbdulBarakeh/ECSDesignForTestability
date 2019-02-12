using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Application
{
    class FakeTemperatureSensor : ITemperatureSensor
    {
        public int GetTemperature()
        {
            throw new NotImplementedException();
        }
    }
}
