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
        private StubWindow _stubWindow;

        private MockHeater _mockheater;
        private MockTemperatureSensor _mocksensor;
        private MockWindow _mockWindow;

        [SetUp]
        public void Setup()
        {
            _stubheater = new StubHeater();
            _stubsensor = new StubTemperatureSensor();
            _stubWindow = new StubWindow();

            _mockheater = new MockHeater();
            _mocksensor = new MockTemperatureSensor();
            _mockWindow = new MockWindow();   
        }

        [Test]
        public void GetTemperature_PositiveTemperature_ResultIsCorrect()
        {
            _uut = new Application.ECS(_stubheater, _stubsensor, _stubWindow);
            _stubsensor.Temperature = 25;

            var result = _uut.GetCurrentTemperature();

            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void GetTemperature_NegativeTemperature_ResultIsCorrect()
        {
            _uut = new Application.ECS(_stubheater, _stubsensor, _stubWindow);
            _stubsensor.Temperature = -5;

            var result = _uut.GetCurrentTemperature();

            Assert.That(result, Is.EqualTo(-5));
        }


        [Test]
        public void Regulate_PositiveTemperatureBelowThreshold_CalledHeaterTurnOnOnce()
        {
            _uut = new Application.ECS(_mockheater, _stubsensor, _stubWindow) {HeaterThreshold = 24};
            _stubsensor.Temperature = 20;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOnCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_NegativeTemperatureBelowThreshold_CalledHeaterTurnOnOnce()
        {
            _uut = new Application.ECS(_mockheater, _stubsensor, _stubWindow) { HeaterThreshold = 24 };
            _stubsensor.Temperature = -5;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOnCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_PositiveTemperatureAboveThreshold_CalledHeaterTurnOffOnce()
        {
            _uut = new Application.ECS(_mockheater, _stubsensor, _stubWindow) { HeaterThreshold = 24 };
            _stubsensor.Temperature = 25;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOffCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_NegativeTemperatureAboveThreshold_CalledHeaterTurnOffOnce()
        {
            _uut = new Application.ECS(_mockheater, _stubsensor, _stubWindow) { HeaterThreshold = -5 };
            _stubsensor.Temperature = -2;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOffCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_PositiveTemperatureEqualThreshold_CalledHeaterTurnOffOnce()
        {
            _uut = new Application.ECS(_mockheater, _stubsensor, _stubWindow) { HeaterThreshold = 24 };
            _stubsensor.Temperature = 24;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOffCalledTimes, Is.EqualTo(1));
        }

        [Test]
        public void Regulate_NegativeTemperatureEqualThreshold_CalledHeaterTurnOffOnce()
        {
            _uut = new Application.ECS(_mockheater, _stubsensor, _stubWindow) { HeaterThreshold = -5 };
            _stubsensor.Temperature = -5;

            _uut.Regulate();

            Assert.That(_mockheater.TurnOffCalledTimes, Is.EqualTo(1));
        }

    }
}
