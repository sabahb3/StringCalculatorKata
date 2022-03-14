using Xunit;

namespace StringCalculator.Test;

public class StringCalculatorTest
{
    [Theory]
    [InlineData(" ", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    public void ShouldReturnAdditionResultOfStringContainingNumbers(string numbers, int expectedResult)
    {
        //Arrange
        StringCalculator stringCalculator = new StringCalculator();
        
        // Act
        int result = stringCalculator.add(numbers);
        
        // Assert
        Assert.Equal(expectedResult,result);   
    }
        

}