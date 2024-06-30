using MAM.Assessment.BusinessLogic.Helper;
using MAM.Assessment.BusinessLogic.Models;
using NUnit.Framework;

namespace MAM.Assessment.Test
{
    public class BusinessLogicTest
    {
        [Test]
        public void TestExtractValueFromString()
        {
            // Arrange
            var input = new List<string>
            {
                "1 Book at 12.49",
                "1 Music CD at 14.99",
                "1 Chocolate bar at 0.85"
            };

            // Act
            var result = StringHelper.ExtractValueFromString(input);

            // Assert
            Assert.AreEqual(3, result.Count, "Unexpected number of items extracted.");

            Assert.AreEqual("Book", result[0].Name, "Name of first item does not match.");
            Assert.AreEqual(12.49, result[0].Price, "Price of first item does not match.");

            Assert.AreEqual("Music CD", result[1].Name, "Name of second item does not match.");
            Assert.AreEqual(14.99, result[1].Price, "Price of second item does not match.");

            Assert.AreEqual("Chocolate bar", result[2].Name, "Name of third item does not match.");
            Assert.AreEqual(0.85, result[2].Price, "Price of third item does not match.");
        }

        [Test]
        public void TestInput1()
        {
            // Arrange
            List<string> input1 = new List<string>
            {
                "1 Book at 12.49",
                "1 Music CD at 14.99",
                "1 Chocolate bar at 0.85"
            };

            // Act
            var receipt = new ReceiptModel(input1);

            // Assert
            Assert.AreEqual(Math.Round(29.83, 2), Math.Round(receipt.TotalPrice, 2));
            Assert.AreEqual(Math.Round(1.50, 2), Math.Round(receipt.TotalSalesTax, 2));
        }

        [Test]
        public void TestInput2()
        {
            // Arrange
            List<string> input2 = new List<string>
            {
                "1 Imported box of chocolates at 10.00",
                "1 Imported bottle of perfume at 47.50"
            };


            // Act
            var receipt = new ReceiptModel(input2);

            // Assert
            Assert.AreEqual(Math.Round(65.15, 2), Math.Round(receipt.TotalPrice, 2));
            Assert.AreEqual(Math.Round(7.65, 2), Math.Round(receipt.TotalSalesTax, 2));
        }

        [Test]
        public void TestInput3()
        {
            // Arrange
            var input3 = new List<string>
            {
                "1 Imported bottle of perfume at 27.99",
                "1 Bottle of perfume at 18.99",
                "1 Packet of paracetamol at 9.75",
                "1 Box of imported chocolates at 11.25"
            };


            // Act
            var receipt = new ReceiptModel(input3);

            // Assert
            Assert.AreEqual(Math.Round(74.68, 2), Math.Round(receipt.TotalPrice, 2));
            Assert.AreEqual(Math.Round(6.70, 2), Math.Round(receipt.TotalSalesTax, 2));
        }
    }
}

