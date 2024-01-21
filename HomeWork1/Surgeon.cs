using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Surgeon:Doctor
    {
        private String bodyPart;
        public Surgeon(String name , String bodyPart) :base(name)
        {
        this.bodyPart = bodyPart;
        }
        override public void Treat()
        {
            Console.WriteLine("Surgeon treat: " + name + " "+ bodyPart);
        }
        public override void Schedule()
        {
            Console.WriteLine(" Расписание: Surgeon: Tuesday, thursday");
        }
        public override bool Rest(string day)
        {
            return !day.Equals("mon", StringComparison.OrdinalIgnoreCase) &&
                   !day.Equals("wed", StringComparison.OrdinalIgnoreCase);
        }
        public override void ProvideTreatmentOptions()
        {
            Console.WriteLine("Surgeon's Treatment Options:");
            Console.WriteLine("1. Head Surgery");
            Console.WriteLine("2. Leg Surgery");
            Console.WriteLine("3. Other Surgical Procedures");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 3)
            {
                string result = "";

                switch (number)
                {
                    case 1:
                        result = "Head Surgery";
                        break;
                    case 2:
                        result = "Leg Surgeryg";
                        break;
                    case 3:
                        result = "Other Surgical Procedures";
                        break;

                }

                Console.WriteLine($"Вы выбрали такую процедуру:{result}");
            }
        }
    }
}
