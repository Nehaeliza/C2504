using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4task2
{
    internal class Allergy
    {
        public int AllergyID;
        public string PatientName;
        public string Allergen;
        public int SeverityLevel;

        public Allergy(int _id, string _name, string _allergen, int _severitylevel)
        {
            AllergyID = _id;
            PatientName = _name;
            Allergen = _allergen;
            SeverityLevel = _severitylevel;
        }

        public override string ToString()
        {
            return $"[id={AllergyID}, PatientName={PatientName}, Allergen={Allergen}, SeverityLevel={SeverityLevel}]";
        }
    }
}
