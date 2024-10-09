using System;

class Program
{
    static double GetNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double number))
                return number;
            else
                Console.WriteLine("Ошибка: пожалуйста, введите корректное число.");
        }
    }

    static string GetOperation()
    {
        while (true)
        {
            Console.Write("Выберите операцию (+, -, *, /): ");
            string operation = Console.ReadLine();
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
                return operation;
            else
                Console.WriteLine("Ошибка: неверная операция. Пожалуйста, выберите из предложенных.");
        }
    }

    static double? Calculate(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль невозможно.");
                    return null;
                }
                return num1 / num2;
            default:
                return null;
        }
    }

    static void Main()
    {
        while (true)
        {
            double num1 = GetNumber("Введите первое число: ");
            double num2 = GetNumber("Введите второе число: ");
            string operation = GetOperation();

            double? result = Calculate(num1, num2, operation);

            if (result.HasValue)
                Console.WriteLine($"Результат: {num1} {operation} {num2} = {result}");

            Console.Write("Хотите выполнить еще одну операцию? (да/нет): ");
            string cont = Console.ReadLine().ToLower();
            if (cont != "да")
            {
                Console.WriteLine("Программа завершена.");
                break;
            }
        }
    }
}

