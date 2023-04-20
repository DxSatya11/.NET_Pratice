using Moq;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApiTest.Repository.Test.School
{
    public class School_Repository_Test
    {
        private readonly Mock<IRepository<Schools>> _schoolRpository;
        public School_Repository_Test()
        {
            _schoolRpository = new Mock<IRepository<Schools>>();

        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsync_School_Test()
        {
            // Assert.Pass();

            _schoolRpository.Setup(srvc => srvc.GetAllAsync()).ReturnsAsync(new List<Schools>()
            {
                new Schools()
                {
                  Id =1,
                  Name= "Test",

                }
            });
            // Act
            var result = await _schoolRpository.Object.GetAllAsync();
            //Assert
            Assert.True(result.Count == 1);

        }

        [Test]
        public async Task GetAllAsync_School_WithNoData_Test()
        {
            // Arrange
            _schoolRpository.Setup(srvc => srvc.GetAllAsync()).ReturnsAsync(new List<Schools>());

            // Act
            var result = await _schoolRpository.Object.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count);
        }

    }
}
