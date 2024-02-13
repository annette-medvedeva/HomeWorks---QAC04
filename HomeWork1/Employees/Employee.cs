using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    public abstract class Employee:IWRestable
    {
        public String Name;
        public int Age;
        public String Specialization;

        public Employee() { }

        protected Employee(string name, String specialization)
        {
            Name = name;
            Specialization = specialization;
        }

        public abstract void Work();
        public virtual bool Rest(DayOfWeek day) 
        {
            return true;
        }
        
    }
}
