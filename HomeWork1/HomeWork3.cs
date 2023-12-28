using System;
using System.Text;

namespace HomeWorks
{
    internal class HomeWork3
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = Encoding.UTF8;
            //func3_1();
            //func3_2();
            //func3_3();
            //func3_4();
            //func3_5();
            //func3_6();
            //func3_7();
            //func3_8();
            //func3_9();
            //func3_10();
            //func3_11();
            //func3_12();
            //func3_16();
            //func3_17();
            //func3_18();
            //func3_19();

        }
        //Пользователь вводит 2 числа (A и B). Возвести число A в степень B.
        static void func3_1()
        {
            Console.WriteLine("Enter a:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter b:");
            int b = Convert.ToInt32(Console.ReadLine());
            int result = 1;
            for (int i = 1; i <= b; i++)
            {
                result *= a;
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
        //Пользователь вводит 1 число (A). Вывести все числа от 1 до 1000, которые делятся на A.
        static void func3_2()
        {
            Console.WriteLine("Введите a:");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = a; i <= 1000; i += a)
            {
                if (i % a == 0)
                    Console.WriteLine(i);
            }
            Console.ReadLine();
        }
        //16.Вычислить приближенно значение бесконечной суммы (справа от каждой суммы дается ее точное значение, с которым можно сравнить полученный ответ):
        static void func3_16()
        {
            Console.WriteLine("Введите значение точности d:");
            double d = Convert.ToDouble(Console.ReadLine());
            double result = 0, a = 0;
            int i = 1;
            do
            {
                a = (1.0 / (i * i));
                result += a;
                i++;
            }
            while (a > d);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        //Пользователь вводит 1 число (A). Найдите количество положительных целых чисел, квадрат которых меньше A.
        static void func3_3()
        {
            Console.WriteLine("Введите значение a:");
            int a = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            for (int i = 1; i * i < a; i++)
            {
                count++;
            }
            Console.WriteLine("Количество положительных целых чисел, квадрат которых меньше {0}, равно {1}", a, count);
            Console.ReadLine();
        }

        //Пользователь вводит 1 число (A). Вывести наибольший делитель (кроме самого A) числа A.
        static void func3_4()
        {
            Console.WriteLine("Введите значение a:");
            int a = Convert.ToInt32(Console.ReadLine());
            int division = 0;
            for (int i = 1; i <= a / 2; i++)
            {
                if (a % i == 0)
                {
                    division = i;
                }
            }
            Console.WriteLine("Наибольший делитель числа a: {0} (кроме самого числа) равен division: {1}", a, division);
            Console.ReadLine();
        }

        //Пользователь вводит 2 числа (A и B). Вывести сумму всех чисел из диапазона от A до B, которые делятся без остатка на 7 (Учтите, что при вводе B может оказаться меньше A).
        static void func3_5()
        {
            int a, b;
            do
            {
                Console.WriteLine("Введите значение a:");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите значение b:");
                b = Convert.ToInt32(Console.ReadLine());
                if (b < a)
                {
                    Console.WriteLine("Ошибка: b должно быть больше или равно a");
                }
            }
            while (b < a);
            int summa = 0;
            for (int i = a; i <= b; i++)
            {
                if (i % 7 == 0)
                {
                    summa += i;
                }
            }
            Console.WriteLine("Сумма всех чисел из диапазона от {0} до {1}, которые делятся без остатка на 7: {2}", a, b, summa);
            Console.ReadLine();
        }

        //Пользователь вводит 1 положительное число (N). Выведите N-ое число ряда фибоначчи.В ряду фибоначчи каждое следующее число является суммой двух
        //предыдущих.Первое и второе считаются равными 1
        static void func3_6()
        {
            int n;
            do
            {
                Console.WriteLine("Введите положительное число N:");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка: Введите положительное число.");
                }
            }
            while (n <= 0);
            if (n <= 2)
            {
                Console.WriteLine("N-ое число ряда фибоначчи: 1");
                Console.ReadLine();
            }
            else
            {
                int a = 1;
                int b = 1;
                int result = 0;

                for (int i = 3; i <= n; i++)
                {
                    result = a + b;
                    a = b;
                    b = result;
                }

                Console.WriteLine($"N-е число в ряде Фибоначчи: {result}");
                Console.ReadLine();
            }
        }

        //Пользователь вводит 2 числа. Найти их наибольший общий делитель
        //используя алгоритм Евклида.
        static void func3_7()
        {
            Console.WriteLine("Введите первое число:");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int gcd = 1;

            while (number2 != 0)
            {
                int temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }
            Console.WriteLine($"Наибольший общий делитель чисел {number1} и {number2} равен {number1}");
            Console.ReadLine();
        }

        //Пользователь вводит целое положительное число, которое является кубом целого числа N.
        //Найдите число N методом половинного деления.
        static void func3_8()
        {
            Console.WriteLine("Введите целое положительное число (куб):");
            int targetCube = Convert.ToInt32(Console.ReadLine());
            int start = 1;
            int end = targetCube;
            int mid = 0;
            while (start <= end)
            {
                mid = (start + end) / 2;
                int cube = mid * mid * mid;
                if (cube == targetCube)
                {
                    Console.WriteLine($"Число N: {mid}");
                    return;
                }
                else if (cube < targetCube)
                {
                    start = mid + 1;

                }
                else
                {
                    end = mid - 1;

                }
            }
            Console.WriteLine("Число N не найдено.");
            Console.ReadLine();
        }

        //Пользователь вводит 1 число. Найти количество нечетных цифр этого числа.
        public static void func3_9()
        {
            Console.WriteLine("Введите целое число a: ");
            int a = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            int oddDigitCount = 0;
            while (a > 0)
            {
                int digit = a % 10;
                if (digit % 2 != 0)
                {
                    oddDigitCount++;
                }
                a /= 10;
            }
            Console.WriteLine($"Количество нечетных цифр: {oddDigitCount}");
            Console.ReadLine();
        }

        //Пользователь вводит 1 число. Найти число, которое является зеркальным
        //отображением последовательности цифр заданного числа, например, задано
        //число 123, вывести 321
        public static void func3_10()
        {
            Console.WriteLine("Введите целое число a:");
            int a = Convert.ToInt32(Console.ReadLine());
            int reversedNumber = 0;
            while (a > 0)
            {
                int digit = a % 10;
                reversedNumber = reversedNumber * 10 + digit;
                a /= 10;
            }
            Console.WriteLine($"Зеркальное число: {reversedNumber}");
            Console.ReadLine();

        }

        //Пользователь вводит целое положительное число (N). Выведите числа в
        //диапазоне от 1 до N, сумма четных цифр которых больше суммы нечетных.
        public static void func3_11()
        {
            Console.WriteLine("Введите целое положительное число:");
            int N = Convert.ToInt32(Console.ReadLine());
            int sumEvenDigits = 0;
            int sumOddDigits = 0;
            for (int i = 1; i <= N; i++)
            {
                int number = i;
                while (number > 0)
                {
                    int digit = number % 10;
                    if (digit % 2 == 0)
                    {
                        sumEvenDigits += digit;
                    }
                    else
                    {
                        sumOddDigits += digit;
                    }

                    number /= 10;
                }
                if (sumEvenDigits > sumOddDigits)
                {
                    Console.WriteLine(i);
                    Console.ReadLine();
                }
                sumEvenDigits = 0;
                sumOddDigits = 0;

            }
        }

        //Пользователь вводит 2 числа. Сообщите, есть ли в написании двух чисел
        //одинаковые цифры.Например, для пары 123 и 3456789, ответом будет
        //являться “ДА”, а, для пары 500 и 99 - “НЕТ”.
        public static void func3_12()
        {
            Console.WriteLine("Введите первое число:");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int number2 = Convert.ToInt32(Console.ReadLine());
            string strNumber1 = number1.ToString();
            string strNumber2 = number2.ToString();
            bool hasCommonDigits = false;
            int tempNumber1 = number1;
            while (tempNumber1 > 0)
            {
                int digit1 = tempNumber1 % 10;
                int tempNumber2 = number2;
                while (tempNumber2 > 0)
                {
                    int digit2 = tempNumber2 % 10;
                    if (digit1 == digit2)
                    {
                        hasCommonDigits = true;
                        Console.WriteLine($"ДА, общая цифра: {digit1}");
                        Console.ReadLine();
                    }

                    tempNumber2 /= 10;
                }
                tempNumber1 /= 10;
            }
            if (!hasCommonDigits)
            {
                Console.WriteLine("НЕТ");
                Console.ReadLine();
            }
        }

        //Найти все двузначные числа, сумма цифр которых не меняется при
        //умножении числа на 2,3,4,5,6,7,8,9.
        public static void func3_17()
        {

        }

        //Найти все трехзначные числа, представимые в виде сумм факториалов
        //своих цифр.
        public static void func3_18() { }

        //Можно ли заданное натуральное число М представить в виде суммы
        //квадратов двух натуральных чисел? Написать программу решения этой задачи.
        public static void func3_19() { }
    }
}
