using System;
using System.Text;

namespace HomeWorks
{
    internal class HomeWork4
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //func3_1();
            //func3_2();
            //func3_3();
            //func3_4();
            //func3_5();
            //func3_5_2();
            //func3_6();
            //func3_7();
            //func3_8();
            func3_9();
            //func3_10();
            //func3_11();
            //func3_12();
          
        }

        //Найти минимальный элемент массива
        public static void func3_1()
        {
            Random random = new Random();
            int[] temp = new int[5];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = random.Next(10);
            }
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + ", ");
            }
            Console.WriteLine();
            int min = temp[0];

            for (int i = 1; i < 5; i++)
            {
                if (temp[i] < min)
                {
                    min = temp[i];
                }
            }
            Console.WriteLine(min);
            Console.ReadLine();
        }

        //Найти максимальный элемент массива
        public static void func3_2()
        {
            Random random = new Random();
            int[] temp = new int[5];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = random.Next(15);
            }
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + ", ");
            }
            Console.WriteLine();
            int max = temp[0];

            for (int i = 1; i < 5; i++)
            {
                if (temp[i] > max)
                {
                    max = temp[i];
                }
            }
            Console.WriteLine(max);
            Console.ReadLine();
        }

        //Найти индекс минимального элемента массива
        //Найти индекс максимального элемента массива
        public static void func3_3()
        {
            int[] temp = new int[10];
            Random random = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = random.Next(20);
            }
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + ", ");
            }
            Console.WriteLine();
            int min = temp[0];
            int max = temp[0];
            int minIndex = 0;
            int maxIndex = 0;
            for (int i = 1; i < temp.Length; i++)
            {
                if (temp[i] < min)
                {
                    min = temp[i];
                    minIndex = i;
                }
                if (temp[i] > max)
                {
                    max = temp[i];
                    maxIndex = i;
                }
            }
            Console.WriteLine("индекс минимального элемента массива: " + minIndex + " элемент массива: " + min);
            Console.WriteLine("индекс максимального элемента массива: " + maxIndex + " элемент массива: " + max);
            Console.ReadLine();

        }
        //Посчитать сумму элементов массива с нечетными индексами
        public static void func3_4()
        {
            int[] temp = new int[5];
            Random random = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = random.Next(5);
            }
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + ", ");
            }
            Console.WriteLine();
            int sum = 0;
            for (int i = 0; i < temp.Length; i += 2)
            {
                sum += temp[i];

            }
            Console.WriteLine("Сумма элементов массива с нечетными индексами: " + sum);
            Console.ReadLine();
        }
        //Сделать реверс массива (массив в обратном направлении)
        public static void func3_5()
        {
            int[] temp = new int[5];
            Random random = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = random.Next(12);
            }
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + " ");
            }
            int length = temp.Length;
            for (int i = 0; i < length / 2; i++)
            {
                int arr = temp[i];
                temp[i] = temp[length - i - 1];
                temp[length - i - 1] = arr;
            }
            Console.WriteLine("\nМассив после реверса: ");
            foreach (int element in temp)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        
        //Сделать реверс массива (массив в обратном направлении)
        public static void func3_5_2()
        {
            int[] mass = new int[5] { 1, 2, 3, 4, 5 };
            for (int i = mass.Length - 1; i >= 0; i--)
            {
                Console.Write(mass[i] );
            }
            Console.ReadLine();
        }

        //Посчитать количество нечетных элементов массива
        public static void func3_6()
        {
            int[] temp = new int[5];
            Random random = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = random.Next(5);
            }
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + ", ");
            }
            Console.WriteLine();
            int count = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] % 2 != 0)
                {
                    count = count + temp[i];
                }
            }
            Console.WriteLine("Сумма нечетных Элементов Массива: " + count);
            Console.ReadLine();
        }

        //Поменять местами первую и вторую половину массива, например, для
        //массива 1 2 3 4, результат 3 4 1 2, или для 12345 - 45312
        public static void func3_7()
        {
            int[] temp = new int[5];
            Random random = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = random.Next(10);
            }
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + " ");
            }
            Console.WriteLine();
            int a = temp.Length % 2 == 0 ? temp.Length / 2 : temp.Length / 2 + 1;
            for (int i = 0; i < temp.Length / 2; i++)
            {
                int b = temp[i];
                temp[i] = temp[i + a];
                temp[i + a] = b;  
            }
            Console.WriteLine("Перевернутый массив: ");
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write(temp[i] + " ");
            }
            Console.ReadLine();

        }

            //Двумерные массивы: Найти минимальный элемент массива; Найти максимальный элемент массива
            public static void func3_8()
            {
            Random random = new Random();
            int[,] nums2 = new int[6, 4];
            for (int i = 0; i < nums2.GetLength(0); i++)
            {
                for (int j = 0; j < nums2.GetLength(1); j++)
                {
                    nums2[i, j] = random.Next(10);
                }
            }
            for (int i = 0; i < nums2.GetLength(0); i++)
            {
                for (int j = 0; j < nums2.GetLength(1); j++)
                {
                    Console.Write($"{nums2[i, j]} ");
                }
                Console.WriteLine();
            }
            int min = nums2[0, 0];
            int max = nums2[0, 0];

            for (int i = 0; i < nums2.GetLength(0); i++)
            {
                for (int j = 0; j < nums2.GetLength(1); j++)
                {
                    if (nums2[i, j] < min)
                    {
                        min = nums2[i, j];
                    }

                    if (nums2[i, j] > max)
                    {
                        max = nums2[i, j];
                    }
                }
            }
            Console.WriteLine($"Минимальный элемент массива: {min}");
            Console.WriteLine($"Максимальный элемент массива: {max}");
            Console.ReadLine();
        }

            //Двумерные массивы:Найти индекс минимального элемента массива; Найти индекс максимального элемента массива
            public static void func3_9()
            {
            Random random = new Random();
            int[,] nums2 = new int[6, 4];
            for (int i = 0; i < nums2.GetLength(0); i++)
            {
                for (int j = 0; j < nums2.GetLength(1); j++)
                {
                    nums2[i, j] = random.Next(10);
                }
            }
            for (int i = 0; i < nums2.GetLength(0); i++)
            {
                for (int j = 0; j < nums2.GetLength(1); j++)
                {
                    Console.Write($"{nums2[i, j]} ");
                }
                Console.WriteLine();
            }
            int minIndexRow = 0, minIndexCol = 0;
            int maxIndexRow = 0, maxIndexCol = 0;
            int min = nums2[0, 0];
            int max = nums2[0, 0];

            for (int i = 0; i < nums2.GetLength(0); i++)
            {
                for (int j = 0; j < nums2.GetLength(1); j++)
                {
                    if (nums2[i, j] < min)
                    {
                        min = nums2[i, j];
                        minIndexRow = i;
                        minIndexCol = j;
                    }

                    if (nums2[i, j] > max)
                    {
                        max = nums2[i, j];
                        maxIndexRow = i;
                        maxIndexCol = j;
                    }
                }
            }
            Console.WriteLine("индекс минимального элемента массива: "+"строка "+ minIndexRow +" колонка "+ minIndexCol+ " элемент min " + min);
            Console.WriteLine("индекс максимального элемента массива: "+ "строка " + maxIndexRow + " колонка " + maxIndexCol + " элемент max " + max);
            Console.ReadLine();
        }

            //Двумерные массивы:Найти количество элементов массива, которые больше всех своих соседей
            //одновременно
            public static void func3_10()
            {

            }

            //Двумерные массивы:Отразите массив относительно его главной диагонали
            public static void func3_11()
            {

            }
            //Двумерные массивы: Дана вещественная матрица размерности n * m. По матрице получить
            //логический вектор, присвоив его k-ому элементу значение true , если
            //выполнено указанное условие и значение false иначе: - все элементы k
            //столбца нулевые; - элементы k строки матрицы упорядочены по убыванию; - k
            //строка массива симметрична.
            public static void func3_12()
            {

            }
   }



    }


