using Xunit;

namespace StringCalculator.Test;

public class StringCalculatorTest
{
    [Theory]
    [InlineData(" ", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3",6)]
    [InlineData("1,1,1,1,1,1,1,1",8)]
    public void ShouldReturnAdditionResultOfStringContainingNumbers(string numbers, int expectedResult)
    {
        //Arrange
        StringCalculator stringCalculator = new StringCalculator();
        
        // Act
        int result = stringCalculator.Add(numbers);
        
        // Assert
        Assert.Equal(expectedResult,result);   
    }
    
    [Theory]
    [InlineData("\n", 0)]
    [InlineData("1\n1", 2)]
    [InlineData("1\n2,3", 6)]
    public void ShouldReturnAdditionResultOfStringContainingNumbersAndNewLineBetweenTwoNumbers(string numbers, int expectedResult)
    {
        //Arrange
        StringCalculator stringCalculator = new StringCalculator();
        
        // Act
        int result = stringCalculator.Add(numbers);
        
        // Assert
        Assert.Equal(expectedResult,result);   
    }
        

}