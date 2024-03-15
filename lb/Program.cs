using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен 0");
        }

        this.numerator = numerator;
        this.denominator = denominator;
    }

    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            denominator = value;
        }
    }

    public double DecimalValue
    {
        get { return (double)numerator / denominator; }
    }

    public Fraction Simplify()
    {
        int gcd = GCD(numerator, denominator);
        return new Fraction(numerator / gcd, denominator / gcd);
    }

    private int GCD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return GCD(b, a % b);
    }

    public Fraction Add(Fraction fraction)
    {
        int resultNumerator = numerator * fraction.denominator + fraction.numerator * denominator;
        int resultDenominator = denominator * fraction.denominator;
        return new Fraction(resultNumerator, resultDenominator).Simplify();
    }

    public Fraction Subtract(Fraction fraction)
    {
        int resultNumerator = numerator * fraction.denominator - fraction.numerator * denominator;
        int resultDenominator = denominator * fraction.denominator;
        return new Fraction(resultNumerator, resultDenominator).Simplify();
    }

    public Fraction Multiply(Fraction fraction)
    {
        int resultNumerator = numerator * fraction.numerator;
        int resultDenominator = denominator * fraction.denominator;
        return new Fraction(resultNumerator, resultDenominator).Simplify();
    }

    public Fraction Divide(Fraction fraction)
    {
        int resultNumerator = numerator * fraction.denominator;
        int resultDenominator = denominator * fraction.numerator;
        return new Fraction(resultNumerator, resultDenominator).Simplify();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числитель для первой дроби:");
        int numerator1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите знаменатель для первой дроби:");
        int denominator1 = int.Parse(Console.ReadLine());

        Fraction fraction1 = new Fraction(numerator1, denominator1);

        Console.WriteLine("Введите числитель для второй дроби:");
        int numerator2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите знаменатель для второй дроби:");
        int denominator2 = int.Parse(Console.ReadLine());

        Fraction fraction2 = new Fraction(numerator2, denominator2);

        Console.WriteLine("Сумма дробей: " + fraction1.Add(fraction2).Numerator + "/" + fraction1.Add(fraction2).Denominator + " (" + fraction1.Add(fraction2).DecimalValue + ")");
        Console.WriteLine("Разность дробей: " + fraction1.Subtract(fraction2).Numerator + "/" + fraction1.Subtract(fraction2).Denominator + " (" + fraction1.Subtract(fraction2).DecimalValue + ")");
        Console.WriteLine("Произведение дробей: " + fraction1.Multiply(fraction2).Numerator + "/" + fraction1.Multiply(fraction2).Denominator + " (" + fraction1.Multiply(fraction2).DecimalValue + ")");
        Console.WriteLine("Частное дробей: " + fraction1.Divide(fraction2).Numerator + "/" + fraction1.Divide(fraction2).Denominator + " (" + fraction1.Divide(fraction2).DecimalValue + ")");
    }
}