using PointsDataLayer;
using PUPHubModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsDataServices
{
    public class SqlData : IStudentPointsData
    {
        static string connectionString
        = "Data Source =localhost; Initial Catalog = PUPHubPoints; Integrated Security = True;";
        //= "Server=tcp://,1433;Database=PUPPoints;User Id=sa;Password=indaleenq727!;";
        static SqlConnection sqlConnection;

        public StudentDataService studentDataService = new StudentDataService();

        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);    
        }

        public List<StudentPoint> GetStudentPoints()
        {
            var selectStatement = "SELECT StudentNumber, Points FROM StudentPoint";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var studentPoints = new List<StudentPoint>();

            while (reader.Read())
            {
                studentPoints.Add(new StudentPoint
                {
                    Student = studentDataService.GetStudent(reader["StudentNumber"].ToString()),
                    Point = Convert.ToInt16(reader["Points"])
                });
            }

            sqlConnection.Close();
            return studentPoints;
        }

        public void SaveStudentPoints(List<StudentPoint> studentPoints)
        {

        }

        public void UpdateStudentPoint(StudentPoint studentPoint)
        {

            sqlConnection.Open();

            var updateStatement = $"UPDATE StudentPoint SET Points = @Points WHERE StudentNumber = @StudentNumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Points", studentPoint.Point);
            updateCommand.Parameters.AddWithValue("@StudentNumber", studentPoint.Student.StudentNumber);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
