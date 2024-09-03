using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace task2
    {
        internal class AllergyMenu
        {
            public static void Menu()
            {
                AllergyUI ui = new AllergyUI();
                bool running = true;

                while (running)
                {
                    Console.WriteLine("\nAllergy Management System");
                    Console.WriteLine("1. Create Allergy");
                    Console.WriteLine("2. Read Allergy");
                    Console.WriteLine("3. Update Allergy");
                    Console.WriteLine("4. Delete Allergy");
                    Console.WriteLine("5. List All Allergy");
                    Console.WriteLine("6. Max SeverityLevel");
                    Console.WriteLine("7. SecondMin Severity");
                    Console.WriteLine("8. Sort Allergy based on Allergen");
                    Console.WriteLine("9. Exit");

                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ui.CreateAllergy();
                            break;
                        case "2":
                            ui.ReadAllergy();
                            break;
                        case "3":
                            ui.UpdateAllergy();
                            break;
                        case "4":
                            ui.DeleteAllergy();
                            break;
                        case "5":
                            ui.ListAllAllergy();
                            break;
                        case "6":
                            ui.FindMaxSeverity();
                            break;
                        case "7":
                            ui.FindSecondMinSeverity();
                            break;
                        case "8":
                            ui.SortByAllergen();
                            break;
                        case "9":
                            running = false;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue....");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
