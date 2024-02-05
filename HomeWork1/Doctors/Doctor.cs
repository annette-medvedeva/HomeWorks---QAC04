using HomeWork1.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    abstract public class Doctor : Employee
    {
        private Queue<Patient> patientQueue = new Queue<Patient>();
        public delegate void PatientEnqueuedEventHandler(object sender, PatientEnqueuedEventArgs e);
        public event EventHandler<PatientEnqueuedEventArgs> PatientEnqueued;
        public int PublicQueueCount => QueueCount;
        protected int QueueCount { get; private set; }
        public Doctor(String name)
        {
            this.Name = name;
            QueueCount = 0;

        }
        virtual public void Treat()
        {
            Console.WriteLine("Doctor treats " + Name);
        }
        public override void Work()
        {
            this.Treat();
        }
        public override bool Rest(DayOfWeek day)
        {
            Console.WriteLine("Resting doctor " + Name);
            return true;
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

        override public void Schedule() 
        { 
            Console.WriteLine($"Расписание: {GetScheduleText()}"); 
        }
        public abstract string ProvideTreatmentOptions();
        protected virtual void OnPatientEnqueued(Patient patient)
        {
            PatientEnqueued?.Invoke(this, new PatientEnqueuedEventArgs(patient));
        }
        virtual public void EnqueuePatient(Patient patient)
        {
            patientQueue.Enqueue(patient);
            Console.WriteLine($"Очередь к доктору {Name}:");
            OnPatientEnqueued(patient); 
            QueueCount++;
            patient.QueueNumber = QueueCount;
            Console.WriteLine($"Пациент {patient.Name} добавлен в очередь к {Name}. Номер в очереди: {patient.QueueNumber}");
        }

        public void DisplayPatientQueue()
        {
            Console.WriteLine($"Очередь у {Name}:");
            foreach (var patient in patientQueue)
            {
                Console.WriteLine($"{patient.Name} - {patient.SelectedDay} - {patient.SelectedProcedure}");
            }
        }

       



    }
}
