using NUnit.Framework;
using System;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private Computer computer2;
        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Acer", "Nitro", 1600.00m);
            this.computer2 = new Computer("Lenovo", "Thinkpad", 2000.00m);
        }

        [Test]
        [Category("Constructor")]
        public void Constructor_ShouldInitializeCollecton()
        {
            ComputerManager computerManager = new ComputerManager();

            int expected = 0;
            var actual = computerManager.Count;
            var actual1 = computerManager.Computers;

            Assert.AreEqual(expected, actual);
            Assert.That(actual1, Is.Empty);
        }

        [Test]
        [Category("AddComputer")]
        public void AddComputer_ShouldAddComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            var expected = 1;
            var actual = computerManager.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("AddComputer")]
        public void AddComputer_ShouldThrowAExcepton_WhenTryToAddNull()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }

        [Test]
        [Category("AddComputer")]
        public void AddComputer_ShouldThrowAExcepton_WhenTryToAddSameComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }

        [Test]
        [Category("RemoveComputer")]
        public void Remove_ShouldRemoveComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            computerManager.AddComputer(this.computer2);

            var computer = computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model);

            var expected = 1;
            var actual = computerManager.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("RemoveComputer")]
        public void Remove_ShouldThrowException_WhenTryRemoveNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = computerManager.RemoveComputer(this.computer.Manufacturer, null);
            });
        }

        [Test]
        [Category("GetComputer")]
        public void GetComputer_ShouldGetComputerCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            computerManager.AddComputer(this.computer2);

            var computerA = computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            var expected = this.computer.Manufacturer;
            var actual = computerA.Manufacturer;
            Assert.AreEqual(expected, actual);

            var expected2 = this.computer.Model;
            var actual2 = computerA.Model;
            Assert.AreEqual(expected2, actual2);
        }

        [Test]
        [Category("GetComputer")]
        [TestCase(null, "Nitro5")]
        [TestCase("Asus", null)]
        public void GetComputer_ShouldThrowException_WhenTryGetNull(string manufacture, string model)
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computerA = computerManager.GetComputer(manufacture, model);
            });
        }

        [Test]
        [Category("GetComputer")]
        public void GetComputer_ShouldThrowException_WhenCantFindComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer(this.computer2.Manufacturer, this.computer2.Model));
        }

        [Test]
        [Category("GetComputersByManufacturer")]
        public void GetComputersByManufacturer_Should_Work_Correctly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            computerManager.AddComputer(this.computer2);

            var collection = computerManager.GetComputersByManufacturer("Acer").ToList();

            var expected = 1;
            var actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Category("GetComputersByManufacturer")]
        public void GetComputersByManufacturer_ShouldThrowException_WhenManufactureIsNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            computerManager.AddComputer(this.computer2);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var collection = computerManager.GetComputersByManufacturer(null).ToList();
            });
        }

        //more tests

        //[Test]
        //public void Remove_ShouldThrowException_WhenTryToRemoveManufacturerNull()
        //{
        //    ComputerManager computerManager = new ComputerManager();
        //    computerManager.AddComputer(this.computer);

        //    Assert.Throws<ArgumentNullException>(() =>
        //    {
        //        var computer = computerManager.RemoveComputer(null, "Model");
        //    });
        //}

        //[Test]
        //public void GetComputersByManufacturerShouldReturnEmptyCollectionWhenNoMatchesFound()
        //{
        //    ComputerManager computerManager = new ComputerManager();
        //    computerManager.AddComputer(this.computer);

        //    var collection = computerManager.GetComputersByManufacturer("Asus").ToList();

        //    CollectionAssert.IsEmpty(collection);
        //}
    }
}