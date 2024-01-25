using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeWorks
{
    internal class HomeWork5
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //func5_1();
            //func5_2();
            //func5_3();
            //func5_4();
            func5_5();


        }
        //1 Заменить в строке все вхождения 'test' на 'testing'. Удалить из текста все
        //символы, являющиеся цифрами.

        public static void func5_1()
        {
            Console.WriteLine("Введите строку с 'test' и цифрами:");
            string text = Console.ReadLine();
            text = text.Replace("test", "testing");
            text = Regex.Replace(text, @"[0-9]", "");
            Console.WriteLine("Измененная строка:" + text);
            Console.ReadLine();

        }
        //2 Используя метод вывода значения в консоль, выполните конкатенацию слов и
        //выведите на экран следующую фразу:
        //Welcome to the TMS lesons.
        //Каждое слово должно быть записано отдельно и взято в кавычки, например "Welcome".
        //Не забывайте о пробелах после каждого слова
        public static void func5_2()
        {
            string word1 = "Welcome";
            string word2 = "to";
            string word3 = "the";
            string word4 = "TMS";
            string word5 = "lessons";
            string phrase = word1 + " " + word2 + " " + word3 + " " + word4 + " " + word5;
            Console.WriteLine(phrase);
            Console.ReadLine();

        }

        //3 Дана строка: teamwithsomeofexcersicesabcwanttomakeitbetter.
        // Необходимо найти в данной строке "abc", записав всё что до этих символов в первую
        //переменную, а также всё, что после них во вторую.
        //Результат вывести в консоль.
        public static void func5_3()
        {
            string str = "teamwithsomeofexcersicesabcwanttomakeitbetter";
            string before = "";
            string after = "";
            int index = str.IndexOf("abc");
            if (index != 1)
            {
                before = str.Substring(0, index);
                after = str.Substring(index + 3);
            }
            Console.WriteLine("Before: " + before);
            Console.WriteLine("After: " + after);
            Console.ReadLine();
        }

        //4 Дана строка: Плохой день.
        //с помощью метода substring удалить слово "плохой". После чего необходимо
        //используя команду insert создать строку со значением: Хороший день!!!!!!!!!.
        //Заменить последний "!" на "?"
        public static void func5_4()
        {
            string str = "Плохой день.";
            string newStr = "";
            newStr = str.Substring(0, 6);
            newStr += " день!";
            newStr = newStr.Replace("!", "?");
            Console.WriteLine(newStr);
            Console.ReadLine();
        }

        //5 Написать программу со следующим функционалом:
        //        На вход передать строку(будем считать, что это номер документа).
        //Номер документа имеет формат xxxx-yyy-xxxx-yyy-xyxy, где x — это число,
        //а y — это буква.
        //Вывести на экран в одну строку два первых блока по 4 цифры.
        //Вывести на экран номер документа, но блоки из трех букв заменить
        //на*** (каждая буква заменятся на*).
        //Вывести на экран только одни буквы из номера документа в
        //формате yyy/yyy/y/y в нижнем регистре.
       
        public static void func5_5()
        {
            Console.WriteLine("Введите номер документа:");
            string number = Console.ReadLine();

            string[] blocks = number.Split('-');

            Console.WriteLine("Первые два блока по 4 цифры: {0} {1}", blocks[0], blocks[1]);

            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i].Length == 3)
                {
                    blocks[i] = "***";
                }
                
            }
            Console.WriteLine("Номер документа с замененными блоками: {0}", string.Join("-", blocks));
            string letters = Regex.Replace(number, @"[^a-zA-Z]", "");
            string[] lettersBlocks = Regex.Split(letters.ToLower(), @"(?<=\G.{3})(?!$)");
            Console.WriteLine("Только буквы из номера документа: {0}", string.Join("/", lettersBlocks));
            Console.ReadLine();

        }
 


    }



}


