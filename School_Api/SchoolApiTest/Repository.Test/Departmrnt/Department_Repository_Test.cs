using Moq;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApiTest.Repository.Test
{
    public class Department_Repository_Test
    {
        private readonly Mock<IRepository<Department>> _departmentpository;
        public Department_Repository_Test()
        {
            _departmentpository = new Mock<IRepository<Department>>();

        }
       [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsync_Department_Test()
        {
            // Assert.Pass();

            _departmentpository.Setup(srvc => srvc.GetAllAsync()).ReturnsAsync(new List<Department>()
            {
                new Department()
                {
                Id =1,
                 Name= "Test",

                }
            });
            // Act
            var result = await _departmentpository.Object.GetAllAsync();
            //Assert
            Assert.True(result.Count == 1);

        }

        [Test]
        public async Task GetAllAsync_Department_WithNoData_Test()
        {
            // Arrange
            _departmentpository.Setup(srvc => srvc.GetAllAsync()).ReturnsAsync(new List<Department>());

            // Act
            var result = await _departmentpository.Object.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count);
        }


        [Test]
        public async Task Add_Department_Test()
        {
            //Arrange
            Department department = null;
            _departmentpository.Setup(srvc => srvc.AddAsync(It.IsAny<Department>())).Callback<Department>(x => department = x);
            var dep = new Department
            {
                Name = "Test",
            };

            //Act
            await _departmentpository.Object.AddAsync(department);

            //Assert
            Assert.AreEqual("Test", dep.Name);
        }


    }
}
