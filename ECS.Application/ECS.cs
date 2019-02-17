using System;

namespace ECS.Application
{
    public class ECS
    {
        private int _windowThreshold;

        public int HeaterThreshold { get; set; }
        public int WindowThreshold
        {
            get => _windowThreshold;
            set => _windowThreshold = value > HeaterThreshold ? value : HeaterThreshold + 1;
        }

        private readonly IWindow _window;
        private readonly IHeater _heater;
        private readonly ITemperatureSensor _temperatureSensor;

        public ECS(IHeater heater, ITemperatureSensor temperatureSensor, IWindow window)
        {
            HeaterThreshold = 0;
            WindowThreshold = 0;
            _window = window;
            _heater = heater;
            _temperatureSensor = temperatureSensor;
        }

        public void Regulate()
        {
            var temperature = _temperatureSensor.GetTemperature();
            Console.WriteLine(temperature);
            if (temperature < HeaterThreshold){
                _heater.TurnOn();
                _window.Close();
            } else if (temperature > HeaterThreshold && temperature < WindowThreshold){
                _heater.TurnOff();
                _window.Close();
            } else if (temperature > HeaterThreshold && temperature > WindowThreshold) {
               _heater.TurnOff();
               _window.Open();
            } else {
                _heater.TurnOff();
                _window.Close();
            }
        }

        public int GetCurrentTemperature()
        {
            return _temperatureSensor.GetTemperature();
        }
    }
}
