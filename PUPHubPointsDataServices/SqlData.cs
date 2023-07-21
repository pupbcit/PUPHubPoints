using PointsDataLayer;
using PUPHubModels;
using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsDataServices
{
    public class SqlData : IStudentPointsData, IRedeeemableServiceData, IRedeemableProductData
    {
        static string connectionString
        = "Data Source =localhost; Initial Catalog = PUPHubPoints; Integrated Security = True;"; //Local Connection
        //= "Server=tcp:4.193.106.92,1433;Database=PUPHubPoints;User Id=sa;Password=PUPHUB123!;"; //Server Connection
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

		public StudentPoint GetStudentPoints(string studentNumber)
		{
			var selectStatement = "SELECT StudentNumber, Points FROM StudentPoint WHERE StudentNumber = @StudentNumber";
			SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
			selectCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
			sqlConnection.Open();
			SqlDataReader reader = selectCommand.ExecuteReader();

			var studentPoint = new StudentPoint();

			while (reader.Read())
			{
                studentPoint.Student = studentDataService.GetStudent(reader["StudentNumber"].ToString());
                studentPoint.Point = Convert.ToInt16(reader["Points"]);
			}

			sqlConnection.Close();
            return studentPoint;
		}

		public void SaveStudentPoints(List<StudentPoint> studentPoints)
        {

        }

        public int AddStudentPoints(StudentPoint studentPoint)
        {
			int success;
			var insertStatement = "INSERT INTO StudentPoint VALUES (@StudentNumber, @Points, @CreatedDate, @ModifiedDate)";

			SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

			insertCommand.Parameters.AddWithValue("@StudentNumber", studentPoint.Student.StudentNumber);
			insertCommand.Parameters.AddWithValue("@Points", studentPoint.Point);
			insertCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
			insertCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
			sqlConnection.Open();

			success = insertCommand.ExecuteNonQuery();

			sqlConnection.Close();

			return success;
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

        public List<RedeemableService> GetServices()
        {
            var selectStatement = "SELECT ServiceName, RequiredPoints FROM RedeemableService";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var redeemableServices = new List<RedeemableService>();

            while (reader.Read())
            {
                redeemableServices.Add(new RedeemableService
                {
                    ServiceName = reader["ServiceName"].ToString(),
                    RequiredPoints = Convert.ToInt16(reader["RequiredPoints"])
                });
            }

            sqlConnection.Close();
            return redeemableServices;
        }

        public List<RedeemableProduct> GetProducts()
        {
            var selectStatement = "SELECT ProductName, RedeemableQty, RequiredPoints FROM RedeemableProduct";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var redeemableServices = new List<RedeemableProduct>();

            while (reader.Read())
            {
                redeemableServices.Add(new RedeemableProduct
                {
                    ProductName = reader["ProductName"].ToString(),
                    RedeemableQty = Convert.ToInt16(reader["RedeemableQty"]),
                    RequiredPoints = Convert.ToInt16(reader["RequiredPoints"])
                });
            }

            sqlConnection.Close();
            return redeemableServices;
        }

        public RedeemableService GetService(string serviceName)
        {
            var selectStatement = "SELECT ServiceName, RequiredPoints FROM RedeemableService WHERE ServiceName = @ServiceName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ServiceName", serviceName);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var redeemableService = new RedeemableService();

            while (reader.Read())
            {
                redeemableService.ServiceName = reader["ServiceName"].ToString();
                redeemableService.RequiredPoints = Convert.ToInt16(reader["RequiredPoints"]);
            }

            sqlConnection.Close();
            return redeemableService;
        }

        public int GetServicePoints(string serviceName)
        {
            var selectStatement = "SELECT RequiredPoints FROM RedeemableService WHERE ServiceName = @ServiceName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ServiceName", serviceName);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var requiredPoints = -1;

            while (reader.Read())
            {
                requiredPoints = Convert.ToInt16(reader["RequiredPoints"]);
            }

            sqlConnection.Close();
            return requiredPoints;
        }

        public RedeemableProduct GetProduct(string productName)
        {
            var selectStatement = "SELECT ProductName, RedeemableQty, RequiredPoints FROM RedeemableProduct WHERE ProductName = @ProductName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ProductName", productName);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var redeemableProduct = new RedeemableProduct();

            while (reader.Read())
            {
                redeemableProduct.ProductName = reader["ProductName"].ToString();
                redeemableProduct.RedeemableQty = Convert.ToInt16(reader["RedeemableQty"]);
                redeemableProduct.RequiredPoints = Convert.ToInt16(reader["RequiredPoints"]);
            }

            sqlConnection.Close();
            return redeemableProduct;
        }

        public int GetProductPoints(string productName)
        {
            var selectStatement = "SELECT RequiredPoints FROM RedeemableProduct WHERE ProductName = @ProductName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@ProductName", productName);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var requiredPoints = -1;

            while (reader.Read())
            {
                requiredPoints = Convert.ToInt16(reader["RequiredPoints"]);
            }

            sqlConnection.Close();
            return requiredPoints;
        }

        public int AddService(RedeemableService redeemableService)
        {
            int success;
            var insertStatement = "INSERT INTO RedeemableService VALUES (@ServiceName, @RequiredPoints)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@ServiceName", redeemableService.ServiceName);
            insertCommand.Parameters.AddWithValue("@RequiredPoints", redeemableService.RequiredPoints);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public void UpdateService(RedeemableService redeemableService)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE RedeemableService SET ServiceName = @ServiceName, RequiredPoints = @RequiredPoints WHERE ServiceName = @ServiceName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@ServiceName", redeemableService.ServiceName);
            updateCommand.Parameters.AddWithValue("@RequiredPoints", redeemableService.RequiredPoints);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void DeleteService(RedeemableService redeemableService)
        {
            sqlConnection.Open();

            var deleteStatement = $"DELETE FROM RedeemableService WHERE ServiceName = @ServiceName";
            SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@ServiceName", redeemableService.ServiceName);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public int AddProduct(RedeemableProduct redeemableProduct)
        {
            int success;
            var insertStatement = "INSERT INTO RedeemableProduct VALUES (@ProductName, @RedeemableQty, @RequiredPoints)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@ProductName", redeemableProduct.ProductName);
            insertCommand.Parameters.AddWithValue("@RedeemableQty", redeemableProduct.RedeemableQty);
            insertCommand.Parameters.AddWithValue("@RequiredPoints", redeemableProduct.RequiredPoints);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public void UpdateProduct(RedeemableProduct redeemableProduct)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE RedeemableProduct SET ProductName = @ProductName, RedeemableQty = @RedeemableQty, " +
                $"RequiredPoints = @RequiredPoints WHERE ProductName = @ProductName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@ProductName", redeemableProduct.ProductName);
            updateCommand.Parameters.AddWithValue("@RedeemableQty", redeemableProduct.RedeemableQty);
            updateCommand.Parameters.AddWithValue("@RequiredPoints", redeemableProduct.RequiredPoints);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void DeleteProduct(RedeemableProduct redeemableProduct)
        {
            sqlConnection.Open();

            var deleteStatement = $"DELETE FROM RedeemableProduct WHERE ProductName = @ProductName";
            SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@ProductName", redeemableProduct.ProductName);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
