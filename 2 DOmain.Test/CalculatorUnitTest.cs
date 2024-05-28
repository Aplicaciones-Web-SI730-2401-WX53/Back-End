using _2._Domain;

namespace _2_DOmain.Test;

public class CalculatorUnitTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(5, 7, 12)]
    [InlineData(6, 6, 12)]
    public void Sum(int number1 ,int number2, int expected)
    {
        //Arrage
        Calculator calculator = new Calculator();
        
        //Act
        var result=  calculator.Sum(number1, number2);
        
        //Assert
        Assert.Equal(expected, result);
    }
}