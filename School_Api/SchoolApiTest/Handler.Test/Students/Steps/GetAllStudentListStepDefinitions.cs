using Moq;
using School_Application.Handlers.StudentHandler;
using School_Application.Handlers.Teachers;
using School_Application.Query.StudentQuery;
using School_Application.Query.TeacherQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Linq.Expressions;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.Students.Steps
{
    [Binding]
    public class GetAllStudentListStepDefinitions
    {
        private GetStudentHandler _handler;
        private Mock<IRepository<Student>> _repositoryMock;
        private IReadOnlyList<Student> _expectedStudents;
        private GetStudentQuery _query;
        private CancellationToken _cancellationToken;


        [Given(@"StudentQuery to get all students list")]
        public void GivenStudentQueryToGetAllStudentsList()
        {
            _query = new GetStudentQuery();
            _cancellationToken = new CancellationToken();
            var school = new Schools { Id = 1, Name = "Test School" };
            var department = new Department { Id = 1, Name = "Test Department" };

            var school2 = new Schools { Id = 2, Name = "Test2 School" };
            var department2 = new Department { Id = 2, Name = "Test2 Department" };

            _expectedStudents = new List<Student>
            {
            new Student { Id = 1, Name = "Satya",Address="Jajpur",DOB = DateTime.Parse("04/03/2001"),Dep_id=department.Id,Department = department,School_id=school.Id,School = school},
            new Student { Id = 1, Name = "RAkesh",Address="BDK",DOB = DateTime.Parse("05/05/2009"),Dep_id=department2.Id,Department = department2,School_id=school2.Id,School = school2},
            };
        }

        [When(@"StudentQuery is handled to get Student list")]
        public async void WhenStudentQueryIsHandledToGetStudentList()
        {
            //throw new PendingStepException();
            _repositoryMock = new Mock<IRepository<Student>>();
            _repositoryMock.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Student, object>>[]>())).ReturnsAsync(_expectedStudents);
            _handler = new GetStudentHandler(_repositoryMock.Object);
            var result = await _handler.Handle(_query, _cancellationToken);
            ScenarioContext.Current.Set<IEnumerable<Student>>(result);
        }

        [Then(@"Student list is retrived")]
        public void ThenStudentListIsRetrived()
        {
            var actualStudents = ScenarioContext.Current.Get<IEnumerable<Student>>();
            Assert.NotNull(actualStudents); 
            Assert.AreEqual(_expectedStudents.Count(), actualStudents.Count()); 
            Assert.AreEqual(_expectedStudents,actualStudents);  
        }
    }
}
