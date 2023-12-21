using System;
using System.Text;

namespace HomeWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //func2_1();
            //func2_2();
             //func2_2_2();
            //func2_3();
            func3_5();
            //func3_6();

        }
        //Пользователь вводит 2 числа (A и B). Если A>B, подсчитать A+B, если A=B, подсчитать A*B, если A<B, подсчитать A-B.
        static void func2_1()
        {
            Console.WriteLine("Введите первое число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            double b = Convert.ToDouble(Console.ReadLine());
            if (a > b)
            {
                double c = a + b;
                Console.WriteLine("a > b - сумма двух чисел: " + c);
            }
            else if (a == b)
            {
                double d = a * b;
                Console.WriteLine("a = b - сложение двух чисел: " + d);
            }
            else if (a < b)
            {
                double e = a - b;
                Console.WriteLine("a < b - вычитание двух чисел: " + e);
            }
            Console.ReadLine();

        }
        //Пользователь вводит 2 числа (X и Y). Определить какой четверти принадлежит точка с координатами(X, Y).
        static void func2_2()
        {
            Console.WriteLine("Введите координаты точки (X, Y):");
            Console.Write("X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            if (x > 0 && y > 0)
            {
                Console.WriteLine("Точка принадлежит к I четверти.");
            }
            else if (x < 0 && y > 0)
            {
                Console.WriteLine("Точка принадлежит к II четверти.");
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine("Точка принадлежит к III четверти.");
            }
            else if (x > 0 && y < 0)
            {
                Console.WriteLine("Точка принадлежит к IV четверти.");
            }
            else if (x == 0 && y != 0)
            {
                Console.WriteLine("Точка лежит на оси Y.");
            }
            else if (x != 0 && y == 0)
            {
                Console.WriteLine("Точка лежит на оси X.");
            }
            else if (x == 0 && y == 0)
            {
                Console.WriteLine("Точка является началом координат.");
            }
            Console.ReadLine();
        }

        //Пользователь вводит 2 числа (X и Y). Определить какой четверти принадлежит точка с координатами(X, Y). (Тернарная операя
        static void func2_2_2()
        {
            Console.WriteLine("Введите координаты точки (X, Y):");
            Console.Write("X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            string point = (x > 0) ? ((y > 0) ? "I четверть" : "IV четверть") : ((y > 0) ? "II четверть" : "III четверть");
            point = (x == 0) ? ((y == 0) ? "Начало координат" : "Ось Y") : ((y == 0) ? "Ось X" : point);
            Console.WriteLine($"Точка принадлежит к {point}.");
            Console.ReadLine();
        }


        //Пользователь вводит 3 числа (A, B и С). Выведите их в консоль в порядке возрастания.
        static void func2_3()
        {
            Console.WriteLine("Введите три числа (A, B и C):");
            Console.Write("A: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("B: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("C: ");
            double c = Convert.ToDouble(Console.ReadLine());
            double min, mid, max;
            if (a <= b && a <= c)     
            {
                min = a;
            }
            else if (b <= a && b <= c)
            {
                min = b;
            }
            else
            {
                min = c;
            }

            if (a >= b && a >= c)             

            {
                max = a;
            }
            else if (b >= a && b >= c)
            {
                max = b;
            }
            else
            {
                max = c;
            }
            if (a != min && a != max)            
            {
                mid = a;
            }
            else if (b != min && b != max)
            {
                mid = b;
            }
            else
            {
                mid = c;
            }
            Console.WriteLine("Числа в порядке возрастания: {0}, {1}, {2}", min, mid, max);
            Console.ReadLine();

        }
        //Пользователь вводит 3 числа (A, B и С). Выведите в консоль решение(значения X) квадратного уравнения стандартного вида, где A*X*2+BX +C=0.
        static void func3_4()
        {
            Console.WriteLine("Введите коэффициенты квадратного уравнения A, B и C:");
            Console.Write("A: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("B: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("C: ");
            double c = Convert.ToDouble(Console.ReadLine());
            double D = b * b - 4 * a * c;
            if (D > 0)
            {
                double e = (-b + Math.Sqrt(D)) / (2 * a);
                double f = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("Уравнение имеет два корня: X1 = " + e, "X2= " + f);
            }
            else if (D == 0)
            {
                double j = -b / (2 * a);
                Console.WriteLine("Уравнение имеет один корень: X =" + j);
            }
            else
            {
                Console.WriteLine("Уравнение не имеет действительных корней.");
            }
            Console.ReadLine();
        }
        //Пользователь вводит двузначное число. Выведите в консоль прописную запись этого числа. Например при вводе “25” в консоль будет выведено “двадцать пять”.
        static void func3_5()
        {
            Console.WriteLine("Введите двузначное число:");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 99)
            {
                int unitsDigit = number % 10;
                int tensDigit = number / 10;

                string result = "";
                switch (tensDigit)
                {
                    case 1:
                        switch (unitsDigit)
                        {
                            case 0:
                                result += "десять";
                                break;
                            case 1:
                                result += "одиннадцать";
                                break;
                            case 2:
                                result += "двенадцать";
                                break;
                            case 3:
                                result += "тринадцать";
                                break;
                            case 4:
                                result += "четырнадцать";
                                break;
                            case 5:
                                result += "пятнадцать";
                                break;
                            case 6:
                                result += "шестнадцать";
                                break;
                            case 7:
                                result += "семнадцать";
                                break;
                            case 8:
                                result += "восемнадцать";
                                break;
                            case 9:
                                result += "девятнадцать";
                                break;
                        }
                        break;
                    case 2:
                        result += "двадцать";
                        break;
                    case 3:
                        result += "тридцать";
                        break;
                    case 4:
                        result += "сорок";
                        break;
                    case 5:
                        result += "пятьдесят";
                        break;
                    case 6:
                        result += "шестьдесят";
                        break;
                    case 7:
                        result += "семьдесят";
                        break;
                    case 8:
                        result += "восемьдесят";
                        break;
                    case 9:
                        result += "девяносто";
                        break;
                }

                if (tensDigit != 1)
                {
                    switch (unitsDigit)
                    {
                        case 1:
                            result += " один";
                            break;
                        case 2:
                            result += " два";
                            break;
                        case 3:
                            result += " три";
                            break;
                        case 4:
                            result += " четыре";
                            break;
                        case 5:
                            result += " пять";
                            break;
                        case 6:
                            result += " шесть";
                            break;
                        case 7:
                            result += " семь";
                            break;
                        case 8:
                            result += " восемь";
                            break;
                        case 9:
                            result += " девять";
                            break;
                    }
                }

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите двузначное число от 1 до 99.");
            }

            Console.ReadLine();
        }


        //Определить, попадает ли точка M(x,y) в круг радиусом r с центром в точке(x0, y0)
        static void func3_6()
        {
            Console.WriteLine("Введите координаты центра круга (x0 y0):");
            Console.Write("x0: ");
            double x0 = double.Parse(Console.ReadLine());
            Console.Write("y0: ");
            double y0 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите радиус круга:");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координаты точки M (x y):");
            Console.Write("x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y: ");
            double y = double.Parse(Console.ReadLine());
            double distance = Math.Sqrt(Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2));
            if (distance <= r)
            {
                Console.WriteLine("Точка находится внутри круга.");
            }
            else
            {
                Console.WriteLine("Точка находится вне круга.");
            }
            Console.ReadLine();
        }
    }
}


