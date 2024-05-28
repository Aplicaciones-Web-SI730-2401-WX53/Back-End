using _2._Domain;
using _3._Data;
using _3._Data.Models;
using Moq;

namespace _2_DOmain.Test;

public class TutorialDomainTest
{
    [Fact]
    public void SaveAsync_ValidTutorial_ReturnsValidId()
    {
        //Arrage
        Tutorial tutorial = new Tutorial()
        {
            Name = "Tutorial 1",
            Description = "Description 1"
        };
        Tutorial tutorial2 = null;
        
        List<Tutorial> tutorials = new List<Tutorial>();
        
        var tutorialDataMock = new Mock<ITutorialData>();
        tutorialDataMock.Setup(t => t.GetByNameAsync(tutorial.Name)).ReturnsAsync(tutorial2);
        tutorialDataMock.Setup(t => t.getAllAsync()).ReturnsAsync(tutorials);
        tutorialDataMock.Setup(t => t.SaveAsync(tutorial)).ReturnsAsync(1);
        
        TutorialDomain tutorialDomain = new TutorialDomain(tutorialDataMock.Object);
        
        //Act
        var result=  tutorialDomain.SaveAsync(tutorial);
        
        //Assert
        Assert.Equal(1, result.Id);
    }
    
    [Fact]
    public void DeleteAsync_ValidId_ReturnsTrue()
    {
        //Arrage
        Tutorial tutorial = new Tutorial()
        {
            Id = 1,
            Name = "Tutorial 1",
            Description = "Description 1"
        };
        
        var tutorialDataMock = new Mock<ITutorialData>();
        tutorialDataMock.Setup(t => t.GetByIdAsync(tutorial.Id)).ReturnsAsync(tutorial);
        tutorialDataMock.Setup(t => t.DeleteAsync(tutorial.Id)).ReturnsAsync(true);
        
        TutorialDomain tutorialDomain = new TutorialDomain(tutorialDataMock.Object);
        
        //Act
        var result=  tutorialDomain.DeleteAsync(tutorial.Id);
        
        //Assert
        Assert.Equal(true,result.Result);
    } 
    
    [Fact]
    public void DeleteAsync_InvalidId_ReturnsFalse()
    {
        //Arrage
        Tutorial tutorial = new Tutorial()
        {
            Id = 0,
            Name = "Tutorial 1",
            Description = "Description 1"
        };
        
        var tutorialDataMock = new Mock<ITutorialData>();
        tutorialDataMock.Setup(t => t.GetByIdAsync(tutorial.Id)).ReturnsAsync((Tutorial)null);
        
        TutorialDomain tutorialDomain = new TutorialDomain(tutorialDataMock.Object);
        
        //Act
        var result=  tutorialDomain.DeleteAsync(tutorial.Id);
        
        //Assert
        Assert.ThrowsAsync<Exception>(async () => await tutorialDomain.DeleteAsync(tutorial.Id));
    }
}