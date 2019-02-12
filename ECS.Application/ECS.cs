using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Application
{
    public class ECS
    {
        private int Threshold { get; set; }

        private IHeater _heater;
        private ITemperatureSensor _temperatureSensor;

        public ECS(int threshold, IHeater heater, ITemperatureSensor temperatureSensor)
        {
            Threshold = threshold;
            _heater = heater;
            _temperatureSensor = temperatureSensor;
        }

        public void Regulate()
        {
            int temperature = _temperatureSensor.GetTemperature();
            if(temperature < Threshold)
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
