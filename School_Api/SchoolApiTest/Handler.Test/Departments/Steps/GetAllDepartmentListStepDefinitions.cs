using Moq;
using School_Application.Handlers.DepartMentHandler;
using School_Application.Query.DepartmentQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.Departments.Steps
{
    [Binding]
    public class GetAllDepartmentListStepDefinitions
    {
        private GetDepartmentHandler _handler;
        private Mock<IRepository<Department>> _repositoryMock;
        private IReadOnlyList<Department> _departments;
        private IEnumerable<Department> _departmentlist;

        public GetAllDepartmentListStepDefinitions()
        {
           // _repositoryMock = new Mock<IRepository<Department>>();
        }



        [Given(@"Query to get all Departmrnt list")]
        public  void GivenQueryToGetAllDepartmrntList()
        {
            
            // Create a mock repository object and set it up to return a list of departments
            _repositoryMock =  new Mock<IRepository<Department>>();
            _departments = new List<Department>
            {
            new Department { Id = 1, Name = "Department 1" },
            new Department { Id = 2, Name = "Department 2" },
            new Department { Id = 3, Name = "Department 3" }
            };
             _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(_departments);

            // Create a new instance of GetDepartmentHandler with the mock repository object
            _handler = new GetDepartmentHandler(_repositoryMock.Object);

        }

        [When(@"Query is handled to get all Department")]
        public async void WhenQueryIsHandledToGetAllDepartment()
        {
            // Call the Handle method with a new instance of GetDepartmentQuery and save the result
            var query = new GetDepartmentQuery();
            var result = await _handler.Handle(query, CancellationToken.None);

            // Save the result to be used in the next step
            _departmentlist = result;
        }

        [Then(@"Department list will retrive")]
        public void ThenDepartmentListWillRetrive()
        {
            // Verify that the result returned by the Handle method is the same as the list of departments
            Assert.AreEqual(_departmentlist, _departments);
            Assert.AreEqual(3, _departmentlist.Count());
            Assert.AreEqual(_departments.Count(), _departmentlist.Count());     
        }
    }
}
