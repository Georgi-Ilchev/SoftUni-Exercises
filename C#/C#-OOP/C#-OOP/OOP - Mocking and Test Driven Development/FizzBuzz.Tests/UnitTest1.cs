using FizzBuzz.Contracts;
using FizzBuzz.Tests.Fakes;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class Tests
    {
        //with mock
        private Mock<IWriter> writer;
        private FizzBuzz fizzBuzz;
        private string result;

        //with fakes
        //private FakeConsoleWriter writer;
        //private FizzBuzz fizzBuzz;

        [SetUp]
        public void Setup()
        {
            //with mock
            writer = new Mock<IWriter>();
            //add writer for test
            fizzBuzz = new FizzBuzz(writer.Object);
            result = "";

            writer.Setup(w => w.WirteLine(It.IsAny<string>())).Callback<string>(i => result += i);

            //with fakes
            //writer = new FakeConsoleWriter();
            //fizzBuzz = new FizzBuzz(writer);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre1to2ThenRestultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(1, 2);

            //with mock
            Assert.AreEqual("12", result);
            //with fakes
            //Assert.AreEqual("12", writer.Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre1to3ThenRestultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(1, 3);

            //with mock
            Assert.AreEqual("12fizz", result);
            //with fakes
            //Assert.AreEqual("12fizz", writer.Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre4to6ThenRestultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(4, 6);
            //with mock
            Assert.AreEqual("4buzzfizz", result);
            //with fakes
            //Assert.AreEqual("4buzzfizz", writer.Result);
        }
        [Test]
        public void GivenFizzBuzzWhenNumbersAre14to17ThenRestultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(14, 17);

            //with mock
            Assert.AreEqual("14fizzbuzz1617", result);
            //with fakes
            //Assert.AreEqual("14fizzbuzz1617", writer.Result);
        }
        [Test]
        public void GivenFizzBuzzWhenNumbersAreMinus5to2ThenRestultShouldBeCorrect()
        {
            fizzBuzz.PrintNumbers(-5, 2);
            //with mock
            Assert.AreEqual("12", result);
            //with fakes
            //Assert.AreEqual("12", writer.Result);
        }
    }
}