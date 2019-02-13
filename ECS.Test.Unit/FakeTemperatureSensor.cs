using ECS.Application;

namespace ECS.Test.Unit
{
    public class FakeTemperatureSensor : ITemperatureSensor
    {
        public int Temperature { get; set; }
  
        public FakeTemperatureSensor()
        {
            Temperature = 0;
        }

        public int GetTemperature()
        {
            return Temperature;
        }
    }
}
