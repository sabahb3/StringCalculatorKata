namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        var parsedString = ParseString(numbers);
        var digits = parsedString.numbers.Split(parsedString.Delimiter.ToArray());
        return AddNumbers(digits);
    }

    private (List<char> Delimiter, string numbers) ParseString(string numbers)
    {
        var delimiters = new List<char>();
        var index = 0;
        if (numbers.StartsWith("\\"))
        {
            index = 1;
            while (numbers[index] != '\n')
            {
                delimiters.Add(numbers[index]);
                index++;
                if (index > numbers.Length)
                    throw new Exception("Invalid arguments");
            }

            if (index < numbers.Length) index++;
        }
        else
        {
            delimiters.Add(',');
        }

        return (delimiters, new string(numbers.Substring(index)));
    }


    private int AddNumbers(string[] numbers)
    {
        var sum = 0;
        foreach (var number in numbers)
        {
            if (string.IsNullOrWhiteSpace(number)) continue;
            if (number.Contains('\n'))
            {
                sum += AddTwoNumbersWithNewLine(number);
                continue;
            }

            if (int.TryParse(number, out var num))
                sum += num;
            else
                throw new Exception("Invalid arguments");
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
                if (int.TryParse(digits[0], out var num0) &&
                    int.TryParse(digits[1], out var num1))
                    return num0 + num1;
                else
                    throw new Exception("Invalid arguments");
            }
        }

        throw new Exception("Invalid arguments");
    }
}