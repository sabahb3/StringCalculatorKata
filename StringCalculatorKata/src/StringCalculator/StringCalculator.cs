namespace StringCalculator;

public class StringCalculator
{
    public const int BigNumber = 1000;

    public int Add(string numbers)
    {
        var parsedString = ParseString(numbers);
        var digits = parsedString.numbers.Split(parsedString.delimiter.ToArray());
        return AddNumbers(digits);
    }

    private (List<char> delimiter, string numbers) ParseString(string numbers)
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
        delimiters.Add('\n');
        return (delimiters, new string(numbers.Substring(index)));
    }


    private int AddNumbers(string[] numbers)
    {
        var sum = 0;
        var negativeNumber = new List<int>();
        foreach (var number in numbers)
        {
            if (string.IsNullOrWhiteSpace(number)) continue;
            if (int.TryParse(number, out var num))
            {
                if (CheckIfNegative(num))
                {
                    negativeNumber.Add(num);
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

        if (negativeNumber.Count>0) AnnouncingPresenceOfNegativeNumbers(negativeNumber);
        return sum;
    }
    
    private bool CheckIfNegative(int num)
    {
        if (num < 0) return true;
        return false;
    }

    private void AnnouncingPresenceOfNegativeNumbers(List<int> numbers)
    {
        var negativeNumbers = string.Join(' ', numbers);
        throw new Exception($"negatives not allowed: {negativeNumbers}".Trim());
    }
}