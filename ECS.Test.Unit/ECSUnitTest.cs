using NUnit.Framework;
using ECS.Application;


namespace ECS.Test.Unit
{
    [TestFixture]
    [Author("Mads Steiner Kristensen")]
    public class ECSUnitTest
    {
        private Application.ECS _uut;
        private StubHeater _stubheater;
        private StubTemperatureSensor _stubsensor;
        private MockHeater _mockheater;
        private MockTemperatureSensor _mocksensor;

        [SetUp]
        public void Setup()
        {
            _stubheater = new StubHeater();
            _stubsensor = new StubTemperatureSensor();

            _mockheater = new MockHeater();
            _mocksensor = new MockTemperatureSensor();
        }

        [Test]
        public void GetTemperature_PositiveTemperature_ResultIsCorrect()
        {
            _uut = new Application.ECS(24, _stubheater, _stubsensor);
            _stubsensor.Temperature = 25;

            var result = _uut.GetCurrentTemperature();

            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void GetTemperature_NegativeTemperature_ResultIsCorrect()
        {
            _uut = new Application.ECS(24, _stubheater, _stubsensor);
            _stubsensor.Temperature = -5;

            var result = _uut.GetCurrentTemperature();

            Assert.That(result, Is.EqualTo(-5));
        }


        [Test]
        public void Regulate_PositiveTemperatureBelowThreshold_CalledHeaterTurnOnOnce()
        {
            _uut = new Application.ECS(24, _mockheater, _mocksensor);
            _mocksensor.Temperature = 20;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOnCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_NegativeTemperatureBelowThreshold_CalledHeaterTurnOnOnce()
        {
            _uut = new Application.ECS(24, _mockheater, _mocksensor);
            _mocksensor.Temperature = -5;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOnCalledTimes, Is.EqualTo(1));

        }

        [Test]
        public void Regulate_PositiveTemperatureAboveThreshold_CalledHeaterTurnOffOnce()
        {
            _uut = new Application.ECS(20, _mockheater, _mocksensor);
            _mocksensor.Temperature = 25;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOffCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_NegativeTemperatureAboveThreshold_CalledHeaterTurnOffOnce()
        {
            _uut = new Application.ECS(-5, _mockheater, _mocksensor);
            _mocksensor.Temperature = -2;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOffCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_TemperatureEqualThreshold_CalledHeaterTurnOffOnce()
        {

        }

    }
}
