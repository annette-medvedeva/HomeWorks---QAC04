using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    abstract internal class PlanTreatment:ITreatable
    {
        public PlanTreatment() { }

        public abstract void PatientTreat();
        public abstract void ProvideTreatmentOptions();
    }
}
