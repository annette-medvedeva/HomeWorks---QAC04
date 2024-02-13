using HomeWorks;
using System;

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
