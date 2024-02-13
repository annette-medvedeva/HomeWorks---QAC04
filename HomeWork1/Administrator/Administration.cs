using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
     public class Administration:Employee
    { 
        
        public Administration(String name, String specialization ): base(name, specialization) 
        { 
            InitializeSchedule(); 
        }
        public override void Work()
        {
            
        }
        public  void Schedule()
        {
            Console.WriteLine($"Расписание:\n {GetScheduleText()}");
        }
        private Dictionary<DayOfWeek, string> schedule = new Dictionary<DayOfWeek, string>();
        private void InitializeSchedule()
        {
            schedule.Add(DayOfWeek.Monday, "с 8:00 до 20:00");
            schedule.Add(DayOfWeek.Tuesday, "с 8:00 до 20:00");
            schedule.Add(DayOfWeek.Wednesday, "с 8:00 до 20:00");
            schedule.Add(DayOfWeek.Thursday, "с 8:00 до 20:00");
            schedule.Add(DayOfWeek.Friday, "с 8:00 до 20:00");
            schedule.Add(DayOfWeek.Saturday, "с 8:00 до 20:00");
            schedule.Add(DayOfWeek.Sunday, "с 8:00 до 20:00");
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
            return false;
        }
    
    }
}
