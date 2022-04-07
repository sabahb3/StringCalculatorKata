namespace StringCalculator;

public class StringCalculator
{
    public const int BigNumber = 1000;

    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers)) return 0;
        var parsedString = ParseString(numbers);
        var num = string.Join(string.Empty, parsedString.numbers);
        var delimiters = parsedString.delimiter.ToArray();
        var digits = num.Split(delimiters);
        return AddNumbers(digits);
    }

    private (List<char> delimiter, List<char> numbers) ParseString(string numbers)
    {
        var delimiters = new List<char>();
        var num = new List<char>();
        if (numbers.Contains('\\') && numbers.Contains('\n'))
        {
            delimiters = numbers.Skip(1).TakeWhile(s => s != '\n').ToList();
            num = numbers.SkipWhile(n => n != '\n').Skip(1).ToList();
        }
        else if (numbers.Contains('\\') && !numbers.Contains('\n'))
        {
            throw new Exception("Invalid arguments");
        }
        else if (!numbers.Contains('\\'))
        {
            num = numbers.Select(n => n).ToList();
            delimiters.Add(',');
        }

        delimiters.Add('\n');
        return (delimiters, num);
    }


    private int AddNumbers(string[] numbers)
    {
        if (numbers.Any(string.IsNullOrWhiteSpace)) throw new Exception("Invalid arguments");

        if (!numbers.All(s => int.TryParse(s, out var num)))
        {
            throw new Exception("Invalid arguments");
        }
        var negativeNumber = numbers.Select(int.Parse).Where(CheckIfNegative).ToList();
        if (negativeNumber.Any()) AnnouncingPresenceOfNegativeNumbers(negativeNumber);
        return numbers.Select(int.Parse).Where(num => num <= BigNumber).Sum();
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