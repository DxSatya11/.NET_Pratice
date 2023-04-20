using Moq;
using School_Application.Commands.StudentCommand;
using School_Application.Commands.TeacherCommand;
using School_Application.Handlers.StudentHandler;
using School_Application.Handlers.Teachers;
using School_Application.Response.StudentResponse;
using School_Application.Response.TeacherResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Linq.Expressions;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.Teaschers.Steps
{
    [Binding]
    public class AddTeacherStepDefinitions
    {
        private readonly Mock<IRepository<Teacher>> _mockTeacherRepository = new Mock<IRepository<Teacher>>();
        private readonly Mock<IRepository<Schools>> _mockSchoolRepository = new Mock<IRepository<Schools>>();
        private readonly Mock<IRepository<Department>> _mockDepartmentRepository = new Mock<IRepository<Department>>();
        private CreateTeacherCommand _command;
        private AddTeacherResponse _response;
        private IReadOnlyList<Teacher> _teacher;

        [Given(@"HAndel Teachercommand request")]
        public void GivenHAndelTeachercommandRequest() 
        {
            _command = new CreateTeacherCommand
            {
                Name = "John Doe",
                Age=45,
                Email= "sdjn@gmail.com",
                Phone="4545457",  
                Subject = "Math",
                School_id = 1,
                Dep_id = 1
            };

            var school = new Schools { Id = 1, Name = "School A" };
            var department = new Department { Id = 1, Name = "Department A" };
            var teacher = new Teacher { Id = 1, Name = "John Doe", Age = 45, Email = "sdjn@gmail.com", Phone = "4545457", Subject = "Math", School = school, School_id = school.Id, Dep_id = department.Id, Department = department };

            _mockSchoolRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(school);
            _mockDepartmentRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(department);
            _mockTeacherRepository.Setup(x => x.AddAsync(It.IsAny<Teacher>())).ReturnsAsync(teacher);
            _mockTeacherRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Teacher, object>>[]>())).ReturnsAsync(new List<Teacher> { teacher });

        }

        [When(@"Teachercommand is handled to add teacher data")]
        public async void WhenTeachercommandIsHandledToAddTeacherData()
        {
            
            var handler = new AddTeacherHandler(_mockTeacherRepository.Object, _mockSchoolRepository.Object, _mockDepartmentRepository.Object);
            _response = await handler.Handle(_command, CancellationToken.None);

            // Get all students
            _teacher = await _mockTeacherRepository.Object.GetAllAsync(t => t.School, t => t.Department);
        }

        [Then(@"Teacher data added successfully")]
        public void ThenTeacherDataAddedSuccessfully()
        {
            _mockTeacherRepository.Verify(x => x.AddAsync(It.IsAny<Teacher>()), Times.Once);
            _mockSchoolRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockDepartmentRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);

            Assert.IsNotNull(_response);
            Assert.AreEqual(_command.Name, _response.Name);
            Assert.AreEqual(_command.Email, _response.Email);
            Assert.AreEqual(_command.School_id, _response.School_id);
            Assert.AreEqual(_command.Dep_id, _response.Dep_id);

            // Check if the student was added
            var newStudent = _teacher.FirstOrDefault(x => x.Name == _command.Name);
            Assert.IsNotNull(newStudent);
            Assert.AreEqual(_command.Name, newStudent.Name);
            Assert.AreEqual(_command.Email, newStudent.Email);
            Assert.AreEqual(_command.School_id, newStudent.School_id);
            Assert.AreEqual(_command.Dep_id, newStudent.Dep_id);
        }
    }
}
