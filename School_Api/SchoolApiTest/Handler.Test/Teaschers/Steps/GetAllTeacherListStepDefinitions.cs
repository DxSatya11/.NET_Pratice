using Moq;
using School_Application.Handlers.Teachers;
using School_Application.Query.TeacherQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Linq.Expressions;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.Teaschers.Steps
{
    [Binding]
    public class GetAllTeacherListStepDefinitions
    {
        private GetTeacherHandler _handler;
        private Mock<IRepository<Teacher>> _repositoryMock;
      //  private IEnumerable<Teacher> _expectedTeacherslist;
        private IReadOnlyList<Teacher> _expectedTeachers;
        private GetTeacherQuery _query;
        private CancellationToken _cancellationToken;


        [Given(@"Query to get all teachers list")]
        public void GivenQueryToGetAllTeachersList()
        {
            // throw new PendingStepException();

            _query = new GetTeacherQuery();
            _cancellationToken = new CancellationToken();
            var school = new Schools { Id = 1, Name="Test School" };
            var department = new Department { Id = 1, Name = "Test Department" };

            var school2 = new Schools { Id = 2, Name = "Test2 School" };
            var department2 = new Department { Id = 2, Name = "Test2 Department" };
            _expectedTeachers = new List<Teacher>
            {
            new Teacher { Id = 1, Name = "jdfh d",Email="abcd@gmail.com",Phone="555986523",Age=45,Dep_id=department.Id,Department = department,School_id=school.Id,School = school},
            new Teacher { Id = 1, Name = "gvdsugvd",Email="gsdcv@gmail.com",Phone="84444",Age=46,Dep_id=department2.Id,Department = department2,School_id=school2.Id,School = school2},
            };
        }

        [When(@"Query is handled to get teacher list")]
        public async void WhenQueryIsHandledToGetTeacherList()
        {
            //throw new PendingStepException();

            _repositoryMock = new Mock<IRepository<Teacher>>();
            _repositoryMock
                .Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Teacher, object>>[]>()))
                .ReturnsAsync(_expectedTeachers);

            _handler = new GetTeacherHandler(_repositoryMock.Object);

            var result = await _handler.Handle(_query, _cancellationToken);
            ScenarioContext.Current.Set<IEnumerable<Teacher>>(result);
        }

        [Then(@"Teacher list will be retrive")]
        public async void ThenTeacherListWillBeRetrive()
        {
            //throw new PendingStepException();
            var actualTeachers = ScenarioContext.Current.Get<IEnumerable<Teacher>>();
            Assert.NotNull(actualTeachers);
            Assert.AreEqual(_expectedTeachers.Count(), actualTeachers.Count());
            Assert.AreEqual(_expectedTeachers, actualTeachers);
        }
    }
}
