using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
     public class Administration:Employee
    {
  
        public Administration(String name) { }
        //abstract public void Manage();
        public override void Work()
        {
            
        }

        public override bool Rest(string day)
        {
            Console.WriteLine("Rest admin");

            return !day.Equals("Saturday", StringComparison.OrdinalIgnoreCase) &&
              !day.Equals("Sunday", StringComparison.OrdinalIgnoreCase);
        }
    
    }
}
