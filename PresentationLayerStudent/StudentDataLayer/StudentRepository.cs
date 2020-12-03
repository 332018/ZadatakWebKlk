using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer
{
    public class StudentRepository
    {
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = Constants.connString;

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Studenti";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Student s = new Student();
                    s.Id = sqlDataReader.GetInt32(0);
                    s.Ime = sqlDataReader.GetString(1);
                    s.BrojIndeksa = sqlDataReader.GetString(2);
                    s.Ocena = sqlDataReader.GetDecimal(3);
                    students.Add(s);
                }
            }
            return students;
        }

        public int InsertStudent(Student s)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = Constants.connString;

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format(
                    "INSERT INTO Studenti VALUES ('{0}','{1}',{2})",
                    s.Ime, s.BrojIndeksa, s.Ocena
                    );

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}

