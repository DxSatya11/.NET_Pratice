using Moq;
using School_Application.Commands.DepartmentCommand;
using School_Application.Handlers.DepartmentHandler;
using School_Application.Response.DepartmentResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using TechTalk.SpecFlow;


namespace SchoolApiTest.Handler.Test.Departments.Steps
{
    [Binding]
    public class AddDepartmentStepDefinitions
    {
        private readonly Mock<IRepository<Department>> _mockRepository = new Mock<IRepository<Department>>();
        private CreateDepartmentCommand _command;
        private AddDepartmentResponse _response;
        [Given(@"Command Request")]
        public void GivenCommandRequest()
        {
            _command = new CreateDepartmentCommand { Name = "Department A" };
            var department = new Department { Id = 1, Name = "Department A" };
            _mockRepository.Setup(x => x.AddAsync(It.IsAny<Department>())).ReturnsAsync(department);

        }

        [When(@"Command is handled to Add")]
        public async void WhenCommandIsHandledToAdd()
        {
            var handler = new AddDepartmentHandler(_mockRepository.Object);
            _response = await handler.Handle(_command, CancellationToken.None);
        }

        [Then(@"Department is added Successfully")]
        public void ThenDepartmentIsAddedSuccessfully()
        {
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<Department>()), Times.Once);
            Assert.IsNotNull(_response);
            Assert.AreEqual(_command.Name, _response.Name);
        }
    }
}
