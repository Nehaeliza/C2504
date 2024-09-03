using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4task2
{
    internal class AllergyUI
    {
        private AllergyDAO allergyDAO = new AllergyDAO();

        public void CreateAllergy()
        {
            Console.Write("Enter Patient Name: ");
            string PatientName = Console.ReadLine();
            Console.Write("Enter Allergen Name: ");
            string AllergenName = Console.ReadLine();
            Console.Write("Enter Severity: ");
            int Severity = int.Parse(Console.ReadLine());

            Allergy allergy = new Allergy(0, PatientName, AllergenName, Severity);

            allergyDAO.Create(allergy);
            Console.WriteLine("Prescription created successfully.");
        }

        public void ReadAllergy()
        {
            Console.Write("Enter Allergy ID: ");
            int id = int.Parse(Console.ReadLine());

            Allergy allergy = allergyDAO.Read(id);
            if (allergy != null)
            {
                Console.WriteLine($"ID: {allergy.AllergyID}");
                Console.WriteLine($"Patient Name: {allergy.PatientName}");
                Console.WriteLine($"Medication Name: {allergy.Allergen}");
                Console.WriteLine($"Dosage: {allergy.SeverityLevel} mg");
            }
            else
            {
                Console.WriteLine("Allergy not found.");
            }
        }

        public void UpdateAllergy()
        {
            Console.Write("Enter Allergy ID: ");
            int id = int.Parse(Console.ReadLine());

            Allergy allergy = allergyDAO.Read(id);
            if (allergy != null)
            {
                Console.Write("Enter new Patient Name: ");
                allergy.PatientName = Console.ReadLine();
                Console.Write("Enter new Medication Name: ");
                allergy.Allergen = Console.ReadLine();
                Console.Write("Enter new Dosage: ");
                allergy.SeverityLevel = int.Parse(Console.ReadLine());

                allergyDAO.Update(allergy);
                Console.WriteLine("Allergy updated successfully.");
            }
            else
            {
                Console.WriteLine("Allergy not found.");
            }
        }

        public void DeleteAllergy()
        {
            Console.Write("Enter Allergy ID: ");
            int id = int.Parse(Console.ReadLine());

            allergyDAO.Delete(id);
            Console.WriteLine("Allergy deleted successfully.");
        }

        public void ListAllAllergy()
        {
            List<Allergy> allergy = allergyDAO.ListAll();
            foreach (Allergy item in allergy)
            {
                Console.WriteLine($"ID: {item.AllergyID}, Patient Name: {item.PatientName}, Allergen Name: {item.Allergen}, Severity: {item.SeverityLevel}");
            }
        }

        public void FindMaxSeverity()
        {
            Allergy allergy = allergyDAO.FindMostSevere();
            Console.WriteLine(allergy);
        }

        public void FindSecondMinSeverity()
        {
            Allergy allergy = allergyDAO.FindSecondMin();
            Console.WriteLine(allergy);
        }

        public void SortByAllergen()
        {
            List<Allergy> allergy = allergyDAO.SortByAllergen();
            foreach (Allergy item in allergy)
            {
                Console.WriteLine($"ID: {item.AllergyID}, Patient Name: {item.PatientName}, Allergen Name: {item.Allergen}, Severity: {item.SeverityLevel}");
            }

        }
    }
}
