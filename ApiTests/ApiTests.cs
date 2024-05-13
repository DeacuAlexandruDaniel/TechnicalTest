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
            var apiService = new ApiService(); 
            _controller = new ApiController(apiService);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_Balanced()
        {
            // Act
            var result = _controller.CheckBalancedBrackets("{[]}");

            // Assert
            Assert.AreEqual("Balanced", result);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_NotBalanced()
        {
            // Act
            var result = _controller.CheckBalancedBrackets("{[}");

            // Assert
            Assert.AreEqual("Not Balanced", result);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_EmptyInput()
        {
            // Act and Assert
            var ex = Assert.Throws<ArgumentNullException>(() => _controller.CheckBalancedBrackets(""));
            Assert.AreEqual("Input null or empty string", ex.ParamName);
        }

        [Test]
        public void TestCheckBalancedBracesEndpoint_NullInput()
        {
            // Act and Assert
            var ex = Assert.Throws<ArgumentNullException>(() => _controller.CheckBalancedBrackets(null));
            Assert.AreEqual("Input null or empty string", ex.ParamName);
        }


        [Test]
        public void TestFindSingleNumberEndpoint_SingleNumberExists()
        {
            // Act
            var result = _controller.FindSingleNumber(new int[] { 1, 2, 2, 3, 3 });

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestFindSingleNumberEndpoint_NoSingleNumber()
        {
            // Act and Assert
            Assert.Throws<Exception>(() => _controller.FindSingleNumber(new int[] { 1, 1, 2, 2 }));
        }

        [Test]
        public void TestFindSingleNumberEndpoint_EmptyInput()
        {
            // Act and Assert
            Assert.Throws<Exception>(() => _controller.FindSingleNumber(new int[] { }));
        }


        [Test]
        public void TestFindSingleNumberEndpoint_SingleNumberAtEnd()
        {
            // Act
            var result = _controller.FindSingleNumber(new int[] { 2, 2, 3, 3, 1 });

            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestFindSingleNumberEndpoint_SingleNumberAtBeginning()
        {
            // Act
            var result = _controller.FindSingleNumber(new int[] { 1, 2, 2, 3, 3 });

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}