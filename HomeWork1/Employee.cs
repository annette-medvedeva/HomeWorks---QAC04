using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    public abstract class Employee:IWRestable
    {
        public String name;
        public int age;

        public Employee() { }

        public abstract void Work();
        public virtual bool Rest(string day) 
        {
            return true;
        }

    }
}
