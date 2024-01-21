using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    abstract public class Doctor : Employee
    {

        public Doctor(String name)
        {
            this.name = name;
        }
        virtual public void Treat()
        {
            Console.WriteLine("Doctor treats " + name);
        }
        public override void Work()
        {
            this.Treat();
        }
        public override bool Rest(string day)
        {
            Console.WriteLine("Resting doctor " + name);
            return true;
        }

        abstract public void Schedule();
        public abstract void ProvideTreatmentOptions();
    }
}
