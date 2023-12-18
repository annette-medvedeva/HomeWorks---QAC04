using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string lastName;
            int age;
            Console.WriteLine("First Programm");
            Console.WriteLine("Enter your First Name: ");
            name=Console.ReadLine();
            Console.WriteLine("Enter your Second Name: ");
            lastName=Console.ReadLine();
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Hello, {name} {lastName}, you are {age} years old.");
            Console.ReadLine();
        }
    }
}
