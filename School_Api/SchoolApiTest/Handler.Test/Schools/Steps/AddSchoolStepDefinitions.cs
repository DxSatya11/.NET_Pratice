using Microsoft.Extensions.Localization;
using Moq;
using School_Application.Commands.DepartmentCommand;
using School_Application.Commands.SchoolCommand;
using School_Application.Handlers.DepartmentHandler;
using School_Application.Handlers.School;
using School_Application.Response.DepartmentResponse;
using School_Application.Response.SchoolResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using TechTalk.SpecFlow;

namespace SchoolApiTest.Handler.Test.School.Steps
{
    [Binding]
    public class AddSchoolStepDefinitions
    {
        private readonly Mock<IRepository<Schools>> _mockRepository = new Mock<IRepository<Schools>>();
        private SchoolCommand _command;
        private AddSchoolResponse _response;

        [Given(@"SchoolCommand request")]
        public void GivenSchoolCommandRequest()
        {
            _command = new SchoolCommand { Name = "Schools A" };
            var department = new Schools { Id = 1, Name = "Schools A" };
            _mockRepository.Setup(x => x.AddAsync(It.IsAny<Schools>())).ReturnsAsync(department);
        }

        [When(@"SchoolCommand is handled to add")]
        public async void WhenSchoolCommandIsHandledToAdd()
        {
            // var handler = new AddSchoolHandler(_mockRepository.Object);
            //_response = await handler.Handle(_command, CancellationToken.None);
            var localizer = new Mock<IStringLocalizer<AddSchoolHandler>>().Object;
            var handler = new AddSchoolHandler(_mockRepository.Object, localizer);
            _response = await handler.Handle(_command, CancellationToken.None);
        }

        [Then(@"School is added successfully")]
        public void ThenSchoolIsAddedSuccessfully()
        {
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<Schools>()), Times.Once);
            Assert.IsNotNull(_response);
            Assert.AreEqual(_command.Name, _response.Name);
        }
    }
}
