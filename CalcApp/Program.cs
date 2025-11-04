using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator");
        Console.Write("First Number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Operator (+, -, *, /, ^, %)");
        string op = Console.ReadLine();

        Console.Write("Second Number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;
        bool valid = true;

        switch (op)
        {
            case "+": result = num1+num2; break;
            case "-": result = num1-num2; break;
            case "*": result = num1*num2; break;
            case "/": 
                if(num2 != 0) 
                    result = num1/num2; 
                else
                {
                    Console.WriteLine("Divide By Zero Error");
                    valid = false;
                }
                break;
            case "^": 
                result = num1;
                while(num2 != 1)
                {
                    result *= num1;
                    num2--;
                }
                break;
            default:
                Console.WriteLine("Invalid operator");
                valid = false;
                break;
        }
        if (valid)
        Console.WriteLine($"Result: {result}");

    }
}