using Xunit;

namespace StringCalculator.Test;

public class StringCalculatorTest
{
    [Fact]
    public void Should_Return_Zero_When_Adding_An_Empty_String()
    {
        //Arrange
        StringCalculator stringCalculator = new StringCalculator();
        string numbers = " ";
        
        // Act
        int result = stringCalculator.add(numbers);
        
        // Assert
        Assert.Equal(0,result);

    }
}