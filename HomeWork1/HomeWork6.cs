
using HomeWorks;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HomeWorks
{
    internal class HomeWork6
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Добро пожаловать в нашу клинику");
            Console.WriteLine("Сегодня работают :");
            Patient patient= new Patient();
            Surgeon surgeon1 = new Surgeon("Sam", "head");
            Surgeon surgeon2 = new Surgeon("Sam", "head");
            Doctor sanya = new Surgeon("Mat", "leg");
            Dentist dentist1 = new Dentist("Dan");
            Dentist dentist2 = new Dentist("Maya");
            Therapist t = new Therapist("Tanya");
            Administration Polly = new Administration("Polly");
            Administration Sara = new Administration("Sara");

            List<IWRestable> wRables = new List<IWRestable>()
            {
            surgeon1,sanya,dentist1, Polly, Sara
            };
            foreach (var wRable in wRables)
            {
                wRable.Work();
            }

            Console.WriteLine("Введите ваше имя : ");
            String name = Convert.ToString(Console.ReadLine());
            Console.WriteLine(name + ", Выберите к какому доктору вы хотите попасть");
            patient.PatientTreat();

            Console.ReadLine();
        }


    }



}


