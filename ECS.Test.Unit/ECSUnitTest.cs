using NUnit.Framework;
using ECS.Application;


namespace ECS.Test.Unit
{

    [TestFixture]
    [Author("Mads Steiner Kristensen")]
    public class ECSUnitTest
    {
        private Application.ECS _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Application.ECS(20, new StubHeater(), new StubTemperatureSensor());
        }




    }
}
