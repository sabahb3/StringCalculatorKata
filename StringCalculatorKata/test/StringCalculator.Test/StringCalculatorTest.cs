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
    [Fact]
    public void Should_Return_The_Same_Number_When_Adding_String_With_Single_Number()
    {
        //Arrange
        StringCalculator stringCalculator = new StringCalculator();
        string numbers = "1";
    
        // Act
        int result = stringCalculator.add(numbers);
    
        // Assert
        Assert.Equal(1,result);

    }
}