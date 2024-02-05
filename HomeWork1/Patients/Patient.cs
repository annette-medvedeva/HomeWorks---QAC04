using HomeWork1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    public class Patient : PlanTreatment
    {
        public string Name { get; set; }
        public Doctor SelectedDoctor { get; set; }
        public string SelectedDay { get; set; }
        public string SelectedProcedure { get; set; }
        public int QueueNumber { get; set; }

        public Patient(string name, Doctor selectedDoctor, string selectedDay, string selectedProcedure, int queueNumber)
        {
            Name = name;
            SelectedDoctor = selectedDoctor;
            SelectedDay = selectedDay;
            SelectedProcedure = selectedProcedure;
            QueueNumber = queueNumber;
            QueueNumber = queueNumber;
        }
        override public void PatientTreat()
        {

        }
        public override void ProvideTreatmentOptions()
        {

        }

        



    }
}


