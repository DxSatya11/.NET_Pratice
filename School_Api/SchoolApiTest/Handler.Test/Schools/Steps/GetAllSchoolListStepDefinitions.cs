using Moq;
using School_Application.Handlers.DepartMentHandler;
using School_Application.Handlers.School;
using School_Application.Query.DepartmentQuery;
using School_Application.Query.SchoolQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.School.Steps
{
    [Binding]
    public class GetAllSchoolListStepDefinitions
    {

        private GetSchoolQueryHandler _handler;
        private Mock<IRepository<Schools>> _repositoryMock;
        private IReadOnlyList<Schools> _schools;
        private IEnumerable<Schools> _schoolslist;

        public GetAllSchoolListStepDefinitions()
        {
            _repositoryMock = new Mock<IRepository<Schools>>();
        }



        [Given(@"Query to get all School list")]
        public void GivenQueryToGetAllSchoolList()
        {
            // Create a mock repository object and set it up to return a list of schools

            _schools = new List<Schools>
            {
            new Schools { Id = 1, Name = "Schools 1" },
            new Schools { Id = 2, Name = "Schools 2" },
            new Schools { Id = 3, Name = "Schools 3" }
            };
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(_schools);

            // Create a new instance of GetSchoolHandler with the mock repository object
            _handler = new GetSchoolQueryHandler(_repositoryMock.Object);
        }

        [When(@"Query is handled to get all school list")]
        public async void WhenQueryIsHandledToGetAllSchoolList()
        {
            // Call the Handle method with a new instance of GetSchoolQuery and save the result
            var query = new GetSchoolQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            // Save the result to be used in the next step
            _schoolslist = result;
        }

        [Then(@"School list will be retrive successfully")]
        public void ThenSchoolListWillBeRetriveSuccessfully()
        {
            // Verify that the result returned by the Handle method is the same as the list of school
            Assert.AreEqual(_schoolslist, _schools);
            Assert.AreEqual(3, _schoolslist.Count());
            Assert.AreEqual(_schools.Count(), _schoolslist.Count());
        }
    }
}
