using Moq;
using School_Application.Commands.StudentCommand;
using School_Application.Handlers.StudentHandler;
using School_Application.Query.DepartmentQuery;
using School_Application.Response.DepartmentResponse;
using School_Application.Response.SchoolResponse;
using School_Application.Response.StudentResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using School_Ifrastructure.Repository;
using System;
using System.Linq.Expressions;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.Students.Steps
{
    [Binding]
    public class AddStudentStepDefinitions
    {
        private readonly Mock<IRepository<Student>> _mockStudentRepository = new Mock<IRepository<Student>>();
        private readonly Mock<IRepository<Schools>> _mockSchoolRepository = new Mock<IRepository<Schools>>();
        private readonly Mock<IRepository<Department>> _mockDepartmentRepository = new Mock<IRepository<Department>>();
        private CreateStudentCommand _command;
        private AddStudentResponse _response;
        private IReadOnlyList<Student> _students;


        [Given(@"Handel StudentCommand request")]
        public void GivenHandelStudentCommandRequest()
        {
            _command = new CreateStudentCommand
            {
                Id = 1,
                Name = "John Doe",
                Address = "Jajpur",
                DOB = DateTime.Parse("04/03/2001"),
                School_id = 1,
                Dep_id = 1
            };

            var school = new Schools { Id = 1, Name = "School A" };
            var department = new Department { Id = 1, Name = "Department A" };
            var student = new Student { Id = 1, Name = "John Doe", Address = "Jajpur", DOB = DateTime.Parse("04/03/2001"), School = school, School_id = school.Id, Dep_id = department.Id, Department = department };

            _mockSchoolRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(school);
            _mockDepartmentRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(department);
            _mockStudentRepository.Setup(x => x.AddAsync(It.IsAny<Student>())).ReturnsAsync(student);
            _mockStudentRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Student, object>>[]>())).ReturnsAsync(new List<Student> { student });

        }

        [When(@"StudentCommand is handled to add")]
        public async void WhenStudentCommandIsHandledToAdd()
        {
           // throw new PendingStepException();
            var handler = new AddStudentHandler(_mockStudentRepository.Object, _mockSchoolRepository.Object, _mockDepartmentRepository.Object);
            // _response = await handler.Handle(_command, CancellationToken.None);

            // Get all students
            _students = await _mockStudentRepository.Object.GetAllAsync(t => t.School, t => t.Department);

        }

        [Then(@"Student added successfully")]
        public async void ThenStudentAddedSuccessfully()
        {

            _mockStudentRepository.Verify(x => x.AddAsync(It.IsAny<Student>()), Times.Once);
            _mockSchoolRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockDepartmentRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);

            Assert.IsNotNull(_response);
            Assert.AreEqual(_command.Name, _response.Name);
            Assert.AreEqual(_command.Address, _response.Address);
            Assert.AreEqual(_command.DOB, _response.DOB);
            Assert.AreEqual(_command.School_id, _response.School_id);
            Assert.AreEqual(_command.Dep_id, _response.Dep_id);

            // Check if the student was added
            var newStudent = _students.FirstOrDefault(x => x.Name == _command.Name);
            Assert.IsNotNull(newStudent);
            Assert.AreEqual(_command.Name, newStudent.Name);
            Assert.AreEqual(_command.Address, newStudent.Address);
            Assert.AreEqual(_command.DOB, newStudent.DOB);
            Assert.AreEqual(_command.School_id, newStudent.School_id);
            Assert.AreEqual(_command.Dep_id, newStudent.Dep_id);

        }
    }
}
