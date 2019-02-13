using ECS.Application;

namespace ECS.Test.Unit
{

    // USED FOR STATE TEST (ASSERT ON UNIT UNDER TEST)
    public class StubHeater : IHeater
    {
        public void TurnOn()
        {

        }

        public void TurnOff()
        {

        }
    }

    // USED FOR BEHAVIORAL TEST (ASSERT ON MOCK)
    public class MockHeater : IHeater
    {
        public int TurnOnCalledTimes { get; private set; }
        public int TurnOffCalledTimes { get; private set; }

        public void TurnOn()
        {
            TurnOnCalledTimes++;
        }

        public void TurnOff()
        {
            TurnOffCalledTimes++;
        }
    }
}
