using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Therapist: Doctor
    {
        public Therapist(String name, String specialization) : base(name, specialization)
        {
            this.Specialization = "Терапевт";
            InitializeSchedule();
        }
        override public void Treat()
        {
            Console.WriteLine("Therapist: " + Name);
        }
        public override void Schedule()
        {
            Console.WriteLine($"Расписание:\n {GetScheduleText()}");
        }
        private Dictionary<DayOfWeek, string> schedule = new Dictionary<DayOfWeek, string>();
        private void InitializeSchedule()
        {
            schedule.Add(DayOfWeek.Monday, "с 8:00 до 14:00");
            schedule.Add(DayOfWeek.Tuesday, "выходной");
            schedule.Add(DayOfWeek.Wednesday, "с 8:00 до 14:00");
            schedule.Add(DayOfWeek.Thursday, "выходной");
            schedule.Add(DayOfWeek.Friday, "с 10:00 до 17:00");
            schedule.Add(DayOfWeek.Saturday, "с 8:00 до 14:00");
            schedule.Add(DayOfWeek.Sunday, "выходной");
        }
        private string GetScheduleText()
        {
            StringBuilder scheduleText = new StringBuilder();
            foreach (var entry in schedule)
            {
                scheduleText.AppendLine($"{entry.Key}: {entry.Value}");
            }
            return scheduleText.ToString();
        }
        public override bool Rest(DayOfWeek day)
        {
            return day == DayOfWeek.Tuesday || day == DayOfWeek.Thursday || day == DayOfWeek.Sunday;
        }

        public override string ProvideTreatmentOptions()
        {
            Console.WriteLine("Therapist's Treatment Options:");
            Console.WriteLine("1. General Checkup");
            Console.WriteLine("2. Prescription");
            Console.WriteLine("3. Therapy Sessions");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 3)
            {
                string procedure = "";

                switch (number)
                {
                    case 1:
                        procedure = "General Checkup";
                        break;
                    case 2:
                        procedure = "Prescription";
                        break;
                    case 3:
                        procedure = "Therapy Sessions";
                        break;

                }

                Console.WriteLine($"Вы выбрали такую процедуру:{procedure}");
                return procedure;
            }
            return "";
        }
    }
}
