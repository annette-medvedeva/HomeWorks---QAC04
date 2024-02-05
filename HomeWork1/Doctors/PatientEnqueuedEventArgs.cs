using HomeWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1.Doctors
{
    public class PatientEnqueuedEventArgs : EventArgs
    {
        public PatientEnqueuedEventArgs(Patient patient)
        {
            Patient = patient;
        }

        public Patient Patient { get; }
    }
}
