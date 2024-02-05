using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
     public abstract class PlanTreatment:ITreatable
    {
        public PlanTreatment() { }

        public abstract void PatientTreat();
        public abstract void ProvideTreatmentOptions();
    }
}
