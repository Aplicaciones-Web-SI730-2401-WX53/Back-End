using _1.API.Controllers;
using _1.API.Response;
using _2._Domain;
using _3._Data;
using _3._Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace TestProject1;

public class TutorialControllerUnitTest
{
    [Fact]
    public async Task GetAsync_ReturnSuccess()
    {
        //Arrange
        var mapperMock = Substitute.For<IMapper>();
        var tutorialDataMock = Substitute.For<ITutorialData>();
        var tutorialDomainMock = Substitute.For<ITutorialDomain>();
        var tutorialController = new TutorialController(tutorialDataMock, tutorialDomainMock, mapperMock);

        var fakeList = new List<Tutorial>
        {
            new Tutorial
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Year = 2021
            }
        };
        
        var returnList = new List<TutorialResponse>
        {
            new TutorialResponse
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Year = 2021
            }
        };
        tutorialDataMock.getAllAsync().Returns(fakeList);
        mapperMock.Map<List<Tutorial>, List<TutorialResponse>>(fakeList).Returns(returnList);
        
        //Act   
        var result = await tutorialController.GetAsync();

        //Assert
        Assert.IsType<OkObjectResult>(result);

    }
   
    [Fact]
    public async Task GetAsync_ReturnNotFound()
    {
        //Arrange
        var mapperMock = Substitute.For<IMapper>();
        var tutorialDataMock = Substitute.For<ITutorialData>();
        var tutorialDomainMock = Substitute.For<ITutorialDomain>();
        var tutorialController = new TutorialController(tutorialDataMock, tutorialDomainMock, mapperMock);

        var fakeList = new List<Tutorial>();
        var returnList = new List<TutorialResponse>();
        tutorialDataMock.getAllAsync().Returns(fakeList);
        mapperMock.Map<List<Tutorial>, List<TutorialResponse>>(fakeList).Returns(returnList);
        
        //Act   
        var result = await tutorialController.GetAsync();

        //Assert
        Assert.IsType<NotFoundResult>(result);

    }
}