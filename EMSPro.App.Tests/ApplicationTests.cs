using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using EMSPro.Core.IService;
using System.IO;
using EMSPro.App.Helper;
using EMSPro.Models.Model;
using EMSPro.App;

namespace EMSPro.Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        private Mock<IEmployeeService> _mockEmployeeService;
        private Mock<IDepartmentService> _mockDepartmentService;
        private Mock<IRoleService> _mockRoleService;

        [SetUp]
        public void Setup()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _mockDepartmentService = new Mock<IDepartmentService>();
            _mockRoleService = new Mock<IRoleService>();
        }

        [Test]
        public void Authenticate_Sets_IsLoggedIn_To_True_When_Valid_Credentials()
        {
            // Arrange
            var application = new Application(_mockEmployeeService.Object, _mockDepartmentService.Object, _mockRoleService.Object);

            // Simulate user input for username and password
            var userInput = "admin\npassword\n";
            using (var consoleInput = new StringReader(userInput))
            {
                Console.SetIn(consoleInput);

                // Act
                application.Authenticate();

                // Assert
                Assert.IsTrue(application._isLoggedIn);
            }
        }

        [Test]
        public void Authenticate_Sets_IsLoggedIn_To_False_When_Invalid_Credentials()
        {
            // Arrange
            var application = new Application(_mockEmployeeService.Object, _mockDepartmentService.Object, _mockRoleService.Object);

            // Simulate user input for username and password
            var userInput = "invalidUsername\ninvalidPassword\n";
            using (var consoleInput = new StringReader(userInput))
            {
                Console.SetIn(consoleInput);

                // Act
                application.Authenticate();

                // Assert
                Assert.IsFalse(application._isLoggedIn);
            }
        }
    }
}
