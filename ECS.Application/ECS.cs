using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Application
{
    public class ECS
    {
        public int HeaterThreshold { get; set; }
        public int WindowThreshold { get; set; } 

        private readonly IHeater _heater;
        private readonly ITemperatureSensor _temperatureSensor;

        public ECS(IHeater heater, ITemperatureSensor temperatureSensor)
        {
            HeaterThreshold = 0;
            WindowThreshold = 0;
            _heater = heater;
            _temperatureSensor = temperatureSensor;
        }

        public void Regulate()
        {
            var temperature = _temperatureSensor.GetTemperature();
            if(temperature < HeaterThreshold)
                _heater.TurnOn();
            else 
                _heater.TurnOff();
        }

        public int GetCurrentTemperature()
        {
            return _temperatureSensor.GetTemperature();
        }
    }
}
