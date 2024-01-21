using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Dentist:Doctor
    {
        public Dentist(String name) : base(name)
        { 
            
        }

         override public void Treat()
        {
            Console.WriteLine("Dentist treats " + name);
        }
        public override bool Rest(string day)
        {
            return !day.Equals("sat", StringComparison.OrdinalIgnoreCase) &&
                   !day.Equals("sun", StringComparison.OrdinalIgnoreCase);

        }

        public override void Schedule()
        {
            Console.WriteLine("Расписание: Mon - Fri");
        }

        public override void ProvideTreatmentOptions()
        {
            Console.WriteLine("Dentist's Treatment Options:");
            Console.WriteLine("1. Dental Cleaning");
            Console.WriteLine("2. Filling");
            Console.WriteLine("3. Tooth Extraction");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 3)
            {
                string result = "";

                switch (number)
                {
                    case 1:
                        result = "Dental Cleaning";
                        break;
                    case 2:
                        result = "Filling";
                        break;
                    case 3:
                        result = "Tooth Extraction";
                        break;

                }

                Console.WriteLine($"Вы выбрали такую процедуру:{result}");
            }
        }
    }
}
