using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Therapist: Doctor
    {
        public Therapist(String name) : base(name)
        { 
        
        }
        override public void Treat()
        {
            Console.WriteLine("Therapist: " + name);
        }
        public override void Schedule()
        {
            Console.WriteLine(" Расписание: Monday, Wednesday, Friday");
        }
        public override bool Rest(string day)
        {
            return !day.Equals("thu", StringComparison.OrdinalIgnoreCase) &&
                   !day.Equals("tue", StringComparison.OrdinalIgnoreCase);
        }

        public override void ProvideTreatmentOptions()
        {
            Console.WriteLine("Therapist's Treatment Options:");
            Console.WriteLine("1. General Checkup");
            Console.WriteLine("2. Prescription");
            Console.WriteLine("3. Therapy Sessions");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 3)
            {
                string result = "";

                switch (number)
                {
                    case 1:
                        result = "General Checkup";
                        break;
                    case 2:
                        result = "Prescription";
                        break;
                    case 3:
                        result = "Therapy Sessions";
                        break;

                }

                Console.WriteLine($"Вы выбрали такую процедуру:{result}");
            }
        }
    }
}
