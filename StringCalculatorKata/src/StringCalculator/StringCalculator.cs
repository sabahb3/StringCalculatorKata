namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        var digits = numbers.Split(',');
        return AddNumbers(digits);
    }
    
    private int AddNumbers(string[] numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            if(string.IsNullOrWhiteSpace(number))continue;
            if (number.Contains('\n'))
            {
                sum += AddTwoNumbersWithNewLine(number);
                continue;
            }
            if (int.TryParse(number, out var num))
            {
                sum += num;
            }
            else
            {
                break;
            }
        }
        return sum;
    }

    private int AddTwoNumbersWithNewLine(string numbers)
    {
        var digits = numbers.Split('\n');
        if (digits.Length == 2)
        {
            if (string.IsNullOrWhiteSpace(digits[0]) || string.IsNullOrWhiteSpace(digits[1]))
            {
                throw new Exception("Invalid arguments");
            }
            else
            {
                int.TryParse(digits[0] , out var num0);
                int.TryParse(digits[1], out var num1);
                return num0 + num1;
            }
            
        }
        throw new Exception("Invalid arguments");
    }
}