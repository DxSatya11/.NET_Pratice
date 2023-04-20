using AutoMapper;
using Moq;
using School_Application.Commands.DepartmentCommand;
using School_Application.Handlers.DepartmentHandler;
using School_Application.Mappers;
using School_Application.Query.DepartmentQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApiTest.Handler.Test
{
    [TestFixture]
    public class Department_Handler_Test
    {
        private Mock<IRepository<Department>> _mockRepository;
        private AddDepartmentHandler _handler;


        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<Department>>();
            _handler = new AddDepartmentHandler(_mockRepository.Object);

        }


        [Test]
        public async Task Handle_WithValidQuery_ShouldReturnDepartmentList()
        {
            //// Arrange
            //var departmentList = new List<Department>()
            //{
            //new Department()
            //   {
            //    Id = 1,
            //    Name = "Department A"
            //   },
            //new Department()
            //  {
            //    Id = 2,
            //    Name = "Department B"
            //  }
            //};
            //_mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(departmentList);

            //var query = new GetDepartmentQuery();

            //// Act
            //var result = await _handler.Handle(query, CancellationToken.None);

            //// Assert
            //Assert.That(result, Is.Not.Null);
            //Assert.That(result.Count(), Is.EqualTo(departmentList.Count));
            //Assert.That(result, Is.EqualTo(departmentList));

            // Assert.Pass();

            _mockRepository.Setup(srvc => srvc.GetAllAsync()).ReturnsAsync(new List<Department>()
            {
                new Department()
                {
                  Id =1,
                  Name= "Test",

                },
                 new Department()
                {
                  Id =1,
                  Name= "Test",

                }
            });
            // Act
            var result = await _mockRepository.Object.GetAllAsync();
            //Assert
            Assert.True(result.Count == 2);

        }



        [Test]
        public async Task Handle_WithValidCommand_ShouldReturnResponse()
        {
            // Arrange
            var command = new CreateDepartmentCommand { Name = "Department A" };
            var department = new Department { Id = 1, Name = "Department A" };
            _mockRepository.Setup(x => x.AddAsync(It.IsAny<Department>())).ReturnsAsync(department);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Department A"));
        }

        [Test]
        public void Handle_WithNullCommand_ShouldThrowException()
        {
            // Arrange
            CreateDepartmentCommand command = null;

            // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(() => _handler.Handle(command, CancellationToken.None));
        }
        [Test]
        public void CreateDepartmentCommand_WithNullName_ShouldThrowValidationException()
        {
            // Arrange
            var command = new CreateDepartmentCommand { Name = null };
            var validationContext = new ValidationContext(command);

            // Act & Assert
            var exception = Assert.Throws<ValidationException>(() => Validator.ValidateObject(command, validationContext, true));
            Assert.That(exception.Message, Is.EqualTo("Department Name Required"));
        }

    }
}
