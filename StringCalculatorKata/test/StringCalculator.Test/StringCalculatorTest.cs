using System;
using Xunit;

namespace StringCalculator.Test;

public class StringCalculatorTest
{
    [Theory]
    [InlineData(" ", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3", 6)]
    [InlineData("1,1,1,1,1,1,1,1", 8)]
    public void ShouldReturnAdditionResultOfStringContainingNumbers(string numbers, int expectedResult)
    {
        //Arrange
        var stringCalculator = new StringCalculator();

        // Act
        var result = stringCalculator.Add(numbers);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("\n", 0)]
    [InlineData("1\n1", 2)]
    [InlineData("1\n2,3", 6)]
    public void ShouldReturnAdditionResultOfStringContainingNumbersAndNewLineBetweenTwoNumbers(string numbers,
        int expectedResult)
    {
        //Arrange
        var stringCalculator = new StringCalculator();

        // Act
        var result = stringCalculator.Add(numbers);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("\\;.\n1;0", 1)]
    [InlineData("\\;.\n1;0.1", 2)]
    [InlineData("\\;.\n1;0.2", 3)]
    public void ShouldReturnAdditionResultOfStringContainsDifferentDelimiters(string numbers, int expectedResult)
    {
        //Arrange
        var stringCalculator = new StringCalculator();

        // Act
        var result = stringCalculator.Add(numbers);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("\\;.\n-1;0", "negatives not allowed: -1")]
    [InlineData("1,0,-2", "negatives not allowed: -2")]
    [InlineData("1,0,-1,-2", "negatives not allowed: -1 -2")]

    public void ShouldThrowExceptionWhenTheStringContainsNegativeNumbers(string numbers, string expectedMessage)
    {
        //Arrange
        var stringCalculator = new StringCalculator();

        // Act
        Action add = () => stringCalculator.Add(numbers);

        // Assert
        var exception = Assert.Throws<Exception>(add);
        Assert.Equal(expectedMessage, exception.Message);
    }
}