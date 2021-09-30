using NUnit.Framework;
using NumbersToStringAPI.Controllers;
using NumbersToStringAPI;
using Microsoft.AspNetCore.Mvc;

namespace NumbersToStringAPI_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ApiTest()
        {
            var controller = new NumbersToStringController();

            OkObjectResult result = (OkObjectResult)controller.Convert(new NumbersToStringController.NumberObject(2.05));
            
            Assert.IsTrue((string)result.Value == "TWO DOLLARS AND FIVE CENTS");
        }

        [Test]
        public void ApiMultipleTest()
        {
            var controller = new NumbersToStringController();

            NumbersToStringController.NumberObject[] numbers = new NumbersToStringController.NumberObject[3];

            numbers[0] = new NumbersToStringController.NumberObject(1.01);
            numbers[1] = new NumbersToStringController.NumberObject(492.5);
            numbers[2] = new NumbersToStringController.NumberObject(82673.11);

            OkObjectResult result = (OkObjectResult)controller.ConvertMultiple(numbers);

            string[] strs = (string[])result.Value;

            Assert.IsTrue(strs[0] == "ONE DOLLAR AND ONE CENT");
            Assert.IsTrue(strs[1] == "FOUR HUNDRED AND NINETY TWO DOLLARS AND FIFTY CENTS");
            Assert.IsTrue(strs[2] == "EIGHTY TWO THOUSAND SIX HUNDRED AND SEVENTY THREE DOLLARS AND ELEVEN CENTS");
        }

        [Test]
        public void ConverterTest()
        {
            Assert.IsTrue(NumberToStringConverter.Convert(2.05) == "TWO DOLLARS AND FIVE CENTS");
            Assert.IsTrue(NumberToStringConverter.Convert(47.50) == "FOURTY SEVEN DOLLARS AND FIFTY CENTS");
            Assert.IsTrue(NumberToStringConverter.Convert(5) == "FIVE DOLLARS AND ZERO CENTS");
            Assert.IsTrue(NumberToStringConverter.Convert(205.31) == "TWO HUNDRED AND FIVE DOLLARS AND THIRTY ONE CENTS");
            Assert.IsTrue(NumberToStringConverter.Convert(4000.0) == "FOUR THOUSAND DOLLARS AND ZERO CENTS");
            Assert.IsTrue(NumberToStringConverter.Convert(1.01) == "ONE DOLLAR AND ONE CENT");
            Assert.IsTrue(NumberToStringConverter.Convert(0.01) == "ZERO DOLLARS AND ONE CENT");
        }
    }
}