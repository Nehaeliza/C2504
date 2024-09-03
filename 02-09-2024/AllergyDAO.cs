using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace week4task2
{
    internal class AllergyDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=task2;Integrated Security=True;";
        /*
            how do you create the connection object?
            how do you create the command object?
            how do you write the parameterizied sql statement or query?
            how will you pass the value to the query?
            how will you establish the connection to database?
            how will you run the query?
        */
        public void Create(Allergy allergies)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Prescription (PatientName, Allergen, SeverityLevel) VALUES (@PatientName, @Allergen, @SeverityLevel)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PatientName", allergies.PatientName);
                    cmd.Parameters.AddWithValue("@Allergen", allergies.Allergen);
                    cmd.Parameters.AddWithValue("@SeverityLevel", allergies.SeverityLevel);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        // Read a Trainer by ID
        /*
   how do you create the connection object?
   how do you create the command object?
   how do you write the parameterizied sql statement or query?
   how will you pass the value to the query?
   how will you establish the connection to database?
   how will you run the query?
   what is reader object?
   how will you read a row or row-by-row many rows using reader object?
        what is job of the reader.Read() function?
        how do you use the reader object after Read() function?
   */
        public Allergy Read(int id)
        {
            try
            {
                Allergy allergy = null;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT AllergyID, PatientName, Allergen, SeverityLevel FROM Allergy WHERE AllergyID = @AllergyID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AllergyID", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        allergy = new Allergy((int)reader["AllergyID"], reader["PatientName"].ToString(), reader["Allergen"].ToString(), (int)reader["SeverityLevel"]);
                    }
                }
                return allergy;
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        // Update a Trainer
        public void Update(Allergy allergy)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Allergy SET PatientName = @PatientName, Allergen = @Allergen, SeverityLevel = @SeverityLevel WHERE AllergyID = @AllergyID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PrescriptionId", allergy.AllergyID);
                    cmd.Parameters.AddWithValue("@PatientName", allergy.PatientName);
                    cmd.Parameters.AddWithValue("@MedicationName", allergy.Allergen);
                    cmd.Parameters.AddWithValue("@Dosage", allergy.SeverityLevel);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        // Delete a Trainer by ID
        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Allergy WHERE AllergyID = @AllergyID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AllergyID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        // List all Trainers
        public List<Allergy> ListAll()
        {
            try
            {
                List<Allergy> allergies = new List<Allergy>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT AllergyID, PatientName, Allergen, SeverityLevel FROM Allergy";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Allergy allergy = new Allergy((int)reader["AllergyID"], reader["PatientName"].ToString(), reader["Allergen"].ToString(), (int)reader["SeverityLevel"]);
                        allergies.Add(allergy);
                    }
                }
                return allergies;
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        public Allergy FindMostSevere()
        {
            try
            {
                Allergy allergy = null;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT AllergyID, PatientName, Allergen, SeverityLevel FROM Allergy WHERE SeverityLevel = (SELECT MAX(SeverityLevel) FROM Allergy)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        allergy = new Allergy((int)reader["AllergyID"], reader["PatientName"].ToString(), reader["Allergen"].ToString(), (int)reader["SeverityLevel"]);
                    }
                }
                return allergy;
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }


        public Allergy FindSecondMin()
        {
            try
            {
                Allergy allergy = null;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT AllergyID, PatientName, Allergen, SeverityLevel FROM Allergy WHERE SeverityLevel = (SELECT MIN(SeverityLevel) FROM Allergy WHERE SeverityLevel > (SELECT MIN(SeverityLevel) FROM Allergy));";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        allergy = new Allergy((int)reader["AllergyID"], reader["PatientName"].ToString(), reader["Allergen"].ToString(), (int)reader["SeverityLevel"]);
                    }
                }
                return allergy;
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }

        public List<Allergy> SortByAllergen()
        {
            try
            {
                List<Allergy> allergies = new List<Allergy>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT AllergyID, PatientName, Allergen, SeverityLevel FROM Allergy ORDER BY Allergen";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Allergy allergy = new Allergy((int)reader["AllergyId"], reader["PatientName"].ToString(), reader["Allergen"].ToString(), (int)reader["SeverityLevel"]);
                        allergies.Add(allergy);
                    }
                }
                return allergies;
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }
    }
}

