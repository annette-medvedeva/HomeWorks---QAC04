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
            InitializeSchedule();
        }
        override public void Treat()
        {
            Console.WriteLine("Surgeon treat: " + Name + " "+ bodyPart);
        }
        public override void Schedule()
        {
            Console.WriteLine($"Расписание:\n  {GetScheduleText()}");
        }
        public override void EnqueuePatient(Patient patient)
        {
            base.EnqueuePatient(patient);
            
        }
        private Dictionary<DayOfWeek, string> schedule = new Dictionary<DayOfWeek, string>();
        private void InitializeSchedule()
        {
            schedule.Add(DayOfWeek.Monday, "с 14:00 до 20:00");
            schedule.Add(DayOfWeek.Tuesday, "выходной");
            schedule.Add(DayOfWeek.Wednesday, "с 8:00 до 14:00");
            schedule.Add(DayOfWeek.Thursday, "выходной");
            schedule.Add(DayOfWeek.Friday, "выходной");
            schedule.Add(DayOfWeek.Saturday, "с 14:00 до 20:00");
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
            return day == DayOfWeek.Tuesday || day == DayOfWeek.Friday || day == DayOfWeek.Sunday || day == DayOfWeek.Thursday;
        }
        public override string ProvideTreatmentOptions()
        {
            Console.WriteLine("Surgeon's Treatment Options:");
            Console.WriteLine("1. Head Surgery");
            Console.WriteLine("2. Leg Surgery");
            Console.WriteLine("3. Other Surgical Procedures");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= 3)
            {
                string procedure = "";

                switch (number)
                {
                    case 1:
                        procedure = "Head Surgery";
                        break;
                    case 2:
                        procedure = "Leg Surgeryg";
                        break;
                    case 3:
                        procedure = "Other Surgical Procedures";
                        break;

                }

                Console.WriteLine($"Вы выбрали такую процедуру: {procedure}");
                return procedure;
            }
            return "";
        }
    }
}
