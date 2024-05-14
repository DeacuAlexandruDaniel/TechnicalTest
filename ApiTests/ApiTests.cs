using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Technical_Test___Deacu_Alexandru_Daniel.Controllers;
using Technical_Test___Deacu_Alexandru_Daniel.Services;

namespace YourTestNamespace
{
    [TestFixture]
    public class ApiControllerTests
    {
        private ApiController _controller;

        [SetUp]
        public void Setup()
        {
            var balancedBracketsService = new BalancedBracketsService(); 
            var findSingleNumberService = new FindSingleNumberService(); 
            _controller = new ApiController(balancedBracketsService, findSingleNumberService);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_Balanced()
        {
            // Arrange
            var input = "{[]}"; 

            // Act
            var result = _controller.CheckBalancedBrackets(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result); 
            Assert.AreEqual(200, result.StatusCode); 
            Assert.AreEqual("Balanced", result.Value);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_NotBalanced()
        {
            // Arrange
            var input = "{[}";

            // Act
            var result = _controller.CheckBalancedBrackets(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result); 
            Assert.AreEqual(200, result.StatusCode); 
            Assert.AreEqual("Not Balanced", result.Value);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_EmptyInput()
        {
            // Arrange
            string input = ""; 

            // Act
            var result = _controller.CheckBalancedBrackets(input) as ObjectResult;

            // Assert
            Assert.IsNotNull(result); 
            Assert.AreEqual(500, result.StatusCode); 
            Assert.AreEqual("Internal Server Error", result.Value);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_NullInput()
        {
            // Arrange
            string input = null; 

            // Act
            var result = _controller.CheckBalancedBrackets(input) as ObjectResult;

            // Assert
            Assert.IsNotNull(result); 
            Assert.AreEqual(500, result.StatusCode); 
            Assert.AreEqual("Internal Server Error", result.Value); 
        }


        [Test]
        public void TestFindSingleNumberEndpoint_SingleNumberExists()
        {
            // Act
            var result = _controller.FindSingleNumber(new int[] { 1, 2, 2, 3, 3 }) as ObjectResult;

            // Assert
            Assert.AreEqual(1, result.Value);
        }

        [Test]
        public void TestFindSingleNumberEndpoint_SingleNumberAtEnd()
        {
            // Act
            var result = _controller.FindSingleNumber(new int[] { 2, 2, 3, 3, 1 }) as ObjectResult;

            // Assert
            Assert.AreEqual(1, result.Value);
        }

        [Test]
        public void TestFindSingleNumberEndpoint_SingleNumberAtBeginning()
        {
            // Act
            var result = _controller.FindSingleNumber(new int[] { 1, 2, 2, 3, 3 }) as ObjectResult;

            // Assert
            Assert.AreEqual(1, result.Value);
        }

        private void AssertIsInternalServerError(Action action)
        {
            // Act and Assert
            var result = _controller.FindSingleNumber(null);
            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }
    }
}