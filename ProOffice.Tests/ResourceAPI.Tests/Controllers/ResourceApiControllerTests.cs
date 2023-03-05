using FakeItEasy;
using FluentAssertions;
using ProOffice.ResourceAPI.Controllers;
using ProOffice.ResourceAPI.Models.Dto;
using ProOffice.ResourceAPI.Repository;
using System.Collections.Generic;
using Xunit;

namespace ProOffice.Tests.ResourceAPI.Tests.Controllers
{
    public class ResourceApiControllerTests
    {
        private IResourceRepository _resourceRepository;
        protected ResponseDto _response;

        public ResourceApiControllerTests()
        {
            _resourceRepository = A.Fake<IResourceRepository>();
            _response = new ResponseDto();
        }

        [Fact]
        public void ShouldReturnAllResources()
        {
            //Arrange
            var resources = A.Fake<IEnumerable<ResourceDto>>();
            A.CallTo(() => _resourceRepository.GetResources()).Returns(resources);
            var controller = new ResourceApiController(_resourceRepository);

            //Act
            var result = controller.Get();

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<ResponseDto>();
        }
    }
}
