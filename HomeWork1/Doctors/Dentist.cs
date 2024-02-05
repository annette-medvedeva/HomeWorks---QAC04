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
            InitializeSchedule();
        }

         override public void Treat()
        {
            Console.WriteLine("Лечит стоматолог " + Name);
        }
        public override bool Rest(DayOfWeek day)
        {
            return day == DayOfWeek.Tuesday || day == DayOfWeek.Sunday;
        }
        public override void Schedule()
        {
            Console.WriteLine($"Расписание : \n {GetScheduleText()}");
        }
        public override void EnqueuePatient(Patient patient)
        {
            base.EnqueuePatient(patient);
        }
        private Dictionary<DayOfWeek, string> schedule = new Dictionary<DayOfWeek, string>();
        private void InitializeSchedule()
        {
            schedule.Add(DayOfWeek.Monday, "с 8:00 до 14:00");
            schedule.Add(DayOfWeek.Tuesday, "выходной");
            schedule.Add(DayOfWeek.Wednesday, "с 8:00 до 14:00");
            schedule.Add(DayOfWeek.Thursday, "с 8:00 до 14:00");
            schedule.Add(DayOfWeek.Friday, "с 8:00 до 14:00");
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

        public override string ProvideTreatmentOptions()
        {
            Console.WriteLine("Варианты лечения у стоматолога:");
            Console.WriteLine("1. Чистка зубов");
            Console.WriteLine("2. Наполнение");
            Console.WriteLine("3. Удаление зуба");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 3)
            {
                string procedure = "";

                switch (number)
                {
                    case 1:
                        procedure = "Чистка зубов";
                        break;
                    case 2:
                        procedure = "Наполнение";
                        break;
                    case 3:
                        procedure = "Удаление зуба";
                        break;

                }

                Console.WriteLine($"Вы выбрали такую процедуру: {procedure}");
                return procedure;
            }
            return "";
        }
    }
}
