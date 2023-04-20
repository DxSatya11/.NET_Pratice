using Moq;
using School_Application.Handlers.DepartmentHandler;
using School_Application.Query.DepartmentQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.Departments.Steps
{
    [Binding]
    public class GetDepartmentByIdStepDefinitions
    {
        private Mock<IRepository<Department>> _repository;
        private GetDepartmentByIdQuery _query;
        private Department _result;

        [Given(@"GetDepartmentByIdQuery to get Department By Id")]
        public void GivenGetDepartmentByIdQueryToGetDepartmentById()
        {
            //throw new PendingStepException();
            _query = new GetDepartmentByIdQuery();
            //{
            //    id = 1,
            //};
        }

        [When(@"GetDepartmentByIdQuery is handled to get Department")]
        public async void WhenGetDepartmentByIdQueryIsHandledToGetDepartment()
        {
            //throw new PendingStepException();
            _repository = new Mock<IRepository<Department>>();
            _repository.Setup(x => x.GetByIdAsync(_query.id)).ReturnsAsync(new Department());

            var handler = new GetDepartmentByIdHandler(_repository.Object);
            _result = await handler.Handle(_query, new CancellationToken());
        }

        [Then(@"Department data is retrive using it's Id")]
        public void ThenDepartmentDataIsRetriveUsingItsId()
        {
            // throw new PendingStepException();
            Assert.NotNull(_result);
        }
    }
}
