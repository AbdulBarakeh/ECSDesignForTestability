using ECS.Application;

namespace ECS.Test.Unit
{
    public class StubTemperatureSensor : ITemperatureSensor
    {
        public int Temperature { get; set; }
  
        public StubTemperatureSensor()
        {
            Temperature = 0;
        }

        public int GetTemperature()
        {
            return Temperature;
        }
    }

    public class MockTemperatureSensor : ITemperatureSensor
    {
        public int Temperature { get; set; }

        public MockTemperatureSensor()
        {
            Temperature = 0;
        }

        public int GetTemperature()
        {
            return Temperature;
        }
    }
}
