using MAM.Assessment.BusinessLogic.Helper;
using MAM.Assessment.BusinessLogic.Models;
using NUnit.Framework;

namespace MAM.Assessment.Test
{
    public class BusinessLogicTest
    {
        // Test for parsing input strings into ItemModel objects
        [Test]
        public void TestExtractValueFromString()
        {
            // Arrange
            var input = new List<string> { "1 Book at 12.49", "1 Music CD at 14.99", "1 Chocolate bar at 0.85" };

            // Act
            var result = StringHelper.ExtractValueFromString(input);

            // Assert
            Assert.That(result, Has.Count.EqualTo(3), "Unexpected number of items extracted.");
            Assert.Multiple(() =>
            {
                Assert.That(result[0].Name, Is.EqualTo("Book"), "Name of first item does not match.");
                Assert.That(result[0].Price, Is.EqualTo(12.49), "Price of first item does not match.");

                Assert.That(result[1].Name, Is.EqualTo("Music CD"), "Name of second item does not match.");
                Assert.That(result[1].Price, Is.EqualTo(14.99), "Price of second item does not match.");

                Assert.That(result[2].Name, Is.EqualTo("Chocolate bar"), "Name of third item does not match.");
                Assert.That(result[2].Price, Is.EqualTo(0.85), "Price of third item does not match.");
            });
        }

        // Test for calculating total price and sales tax with input 1
        [Test]
        public void TestInput1()
        {
            // Arrange
            var input = new List<string> { "1 Book at 12.49", "1 Music CD at 14.99", "1 Chocolate bar at 0.85" };

            // Act
            var receipt = new ReceiptModel(input);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(Math.Round(receipt.TotalPrice, 2), Is.EqualTo(Math.Round(29.83, 2)));
                Assert.That(Math.Round(receipt.TotalSalesTax, 2), Is.EqualTo(Math.Round(1.50, 2)));
            });
        }

        // Test for calculating total price and sales tax with input 2
        [Test]
        public void TestInput2()
        {
            // Arrange
            var input = new List<string> { "1 Imported box of chocolates at 10.00", "1 Imported bottle of perfume at 47.50" };

            // Act
            var receipt = new ReceiptModel(input);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(Math.Round(receipt.TotalPrice, 2), Is.EqualTo(Math.Round(65.15, 2)));
                Assert.That(Math.Round(receipt.TotalSalesTax, 2), Is.EqualTo(Math.Round(7.65, 2)));
            });
        }

        // Test for calculating total price and sales tax with input 3
        [Test]
        public void TestInput3()
        {
            // Arrange
            var input3 = new List<string> 
            { 
                "1 Imported bottle of perfume at 27.99", "1 Bottle of perfume at 18.99", 
                "1 Packet of paracetamol at 9.75", "1 Box of imported chocolates at 11.25" 
            };

            // Act
            var receipt = new ReceiptModel(input3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(Math.Round(receipt.TotalPrice, 2), Is.EqualTo(Math.Round(74.68, 2)));
                Assert.That(Math.Round(receipt.TotalSalesTax, 2), Is.EqualTo(Math.Round(6.70, 2)));
            });
        }
    }
}
