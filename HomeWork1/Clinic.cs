using HomeWork1.Enums;
using HomeWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    public class Clinic
    {
        public List<Patient> patients { get; private set; }
        public List<Doctor> doctors{ get; private set; }
        public SpecializationEnum specialization { get; private set; }


        public Clinic() {
            patients = new List<Patient>();
            doctors = new List<Doctor>();
            specialization = new SpecializationEnum();
        }
        public Clinic(List<Patient> patients, List<Doctor> doctors, SpecializationEnum spec)
        {
            this.patients = patients;
            this.doctors = doctors;
            this.specialization = spec;
        }
    }
}
