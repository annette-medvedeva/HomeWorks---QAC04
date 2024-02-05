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

        public Employee() { }

        protected Employee(string name)
        {
            Name = name;
        }

        public abstract void Work();
        public virtual bool Rest(DayOfWeek day) 
        {
            return true;
        }
        public abstract void Schedule();

    }
}
