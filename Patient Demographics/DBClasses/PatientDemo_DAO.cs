using Patient_Demographics.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DBClasses
{
    public interface IPatientDemo_DAO
    {
        Patient GetPatient(int id);
        void SavePatient(Patient patient);
        List<Patient> GetPatients();

    }
    public class PatientDemo_DAO : IPatientDemo_DAO
    {
        string connectionString = @"Data Source=money-pc\SQLEXPRESS;Initial Catalog=PatientDemo;Integrated Security=true";

        public Patient GetPatient(int id)
        {
            string queryString = "SELECT ID, Data from dbo.PatientInfo WHERE ID = @ID ";
            int paramValue = id;
            Patient patient = new Patient();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", paramValue);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        patient.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        var xml = reader.GetString(reader.GetOrdinal("Data"));
                        patient = DeserializeXMLFileToPatient(xml);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                return patient;
            }
        }

        public List<Patient> GetPatients()
        {
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT ID, Data from dbo.PatientInfo ";



            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            List<Patient> patients = new List<Patient>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);


                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Patient patient = new Patient();
                        patient.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                        var xmlData = reader.GetString(reader.GetOrdinal("Data"));
                        patient = DeserializeXMLFileToPatient(xmlData);
                        patients.Add(patient);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return patients;
        }

        public void SavePatient(Patient patient)
        {
            if (PatientExits(patient))
            {
                UpdatePatient(patient);
            }
            else
            {
                InsertPatient(patient);
            }
        }


        private void InsertPatient(Patient patient)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT IDENT_CURRENT( 'PatientInfo' )";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    var id =command.ExecuteScalar();
                    int identity = Convert.ToInt32(id);
                    patient.ID = identity == 0 ? 0 : identity + 1;
                    string queryString = "Insert into  dbo.PatientInfo (Data) Values ( @Data)";
                    
                    
                    // Create the Command and Parameter objects.
                    command = new SqlCommand(queryString, connection);
                    
                    command.Parameters.AddWithValue("@Data", PatientToXML(patient));
                    command.CommandType = CommandType.Text;
                    
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdatePatient(Patient patient)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = "Update dbo.PatientInfo  set Data= @Data where ID=@ID";
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);

                    
                    command.Parameters.AddWithValue("@Data", PatientToXML(patient));
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool PatientExits(Patient patient)
        {
            bool exists = false;
            if (patient.ID == 0)
            {
                return exists;
            }
            Patient p = GetPatient(patient.ID);
            if (p.ID == patient.ID)
            {
                exists = true;
            }
            return exists;
        }

        private string PatientToXML(Patient patient)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Patient));

            var xml = string.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, patient);
                    xml = sww.ToString(); // Your XML
                }
            }
            return xml;
        }

        public static Patient DeserializeXMLFileToPatient(string xml)
        {
            Patient patient = new Patient();
            if (string.IsNullOrEmpty(xml)) return patient;

            try
            {
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(xml);
                writer.Flush();
                stream.Position = 0;


                StreamReader xmlStream = new StreamReader(stream);
                XmlSerializer serializer = new XmlSerializer(typeof(Patient));
                patient = (Patient)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {

            }
            return patient;
        }
    }
}
