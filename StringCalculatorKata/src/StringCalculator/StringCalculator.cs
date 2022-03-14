namespace StringCalculator;

public class StringCalculator
{
    public int add(string numbers)
    {
        var digits = numbers.Split(',');
        var sum = 0;
        switch (digits.Length)
        {
            case 1:
                sum = AddSingleNumber(digits[0]);
                break;
            default:
                sum = AddMoreThanOneNumber(digits);
                break;
        }

        return sum;
    }

    private int AddSingleNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number)) return 0;
        else
        {
            int.TryParse(number, out var num);
            return num;
        }
    }

    private int AddMoreThanOneNumber(string[] numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            if(string.IsNullOrWhiteSpace(number))continue;
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
}