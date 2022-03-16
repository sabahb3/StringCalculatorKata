namespace StringCalculator;

public class StringCalculator
{
    public const int BigNumber = 1000;

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
        var negativeNumber = string.Empty;
        foreach (var number in numbers)
        {
            if (string.IsNullOrWhiteSpace(number)) continue;
            if (number.Contains('\n'))
            {
                var addingTwoNumberResult = AddTwoNumbersWithNewLine(number);
                sum += addingTwoNumberResult.sum;
                if (!string.IsNullOrEmpty(addingTwoNumberResult.NegativeNumber))
                    negativeNumber += addingTwoNumberResult.NegativeNumber;
                continue;
            }

            if (int.TryParse(number, out var num))
            {
                if (CheckIfNegative(num))
                {
                    negativeNumber += $"{num} ";
                }
                else
                {
                    if (num <= BigNumber) sum += num;
                }
            }
            else
            {
                throw new Exception("Invalid arguments");
            }
        }

        if (!string.IsNullOrEmpty(negativeNumber)) AnnouncingPresenceOfNegativeNumbers(negativeNumber);
        return sum;
    }

    private (int sum, string NegativeNumber) AddTwoNumbersWithNewLine(string numbers)
    {
        var negativeNumber = string.Empty;
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
                {
                    var sum = 0;
                    if (!CheckIfNegative(num0) && !CheckIfNegative(num1))
                    {
                        if (num0 <= BigNumber) sum += num0;
                        if (num1 <= BigNumber) sum += num1;
                    }
                    else if (CheckIfNegative(num0))
                    {
                        negativeNumber += $"{num0} ";
                    }
                    else if (CheckIfNegative(num1))
                    {
                        negativeNumber += $"{num1} ";
                    }

                    return (sum, negativeNumber);
                }
                else
                {
                    throw new Exception("Invalid arguments");
                }
            }
        }

        throw new Exception("Invalid arguments");
    }

    private bool CheckIfNegative(int num)
    {
        if (num < 0) return true;
        return false;
    }

    private void AnnouncingPresenceOfNegativeNumbers(string numbers)
    {
        throw new Exception($"negatives not allowed: {numbers}".Trim());
    }
}