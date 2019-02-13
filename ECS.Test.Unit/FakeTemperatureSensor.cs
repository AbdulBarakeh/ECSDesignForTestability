using ECS.Application;

namespace ECS.Test.Unit
{
    // USED FOR STATE TEST (ASSERT ON UNIT UNDER TEST)
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

    // USED FOR BEHAVIORAL TEST (ASSERT ON MOCK) 
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
