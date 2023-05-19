using PUPHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsDataLayer
{
    public class StudentPointDataService
    {
        private List<StudentPoint> StudentPoints { get; set; }

        private DataSource dataSource;
        private InMemoryData memoryData = new InMemoryData();
        private InJsonFile jsonFile = new InJsonFile();

        public StudentPointDataService()
        {
            StudentPoints = new List<StudentPoint>();
            dataSource = DataSource.InMemory;

            StudentPoints = memoryData.GetStudentPoints();
        }

        public StudentPointDataService(DataSource source)
        {
            StudentPoints = new List<StudentPoint>();

            dataSource = source;

            switch (dataSource)
            {
                case DataSource.InMemory:
                    StudentPoints = memoryData.GetStudentPoints();
                    break;
                case DataSource.JsonFile:
                    StudentPoints = jsonFile.GetStudentPoints();
                    break;
                case DataSource.Database:
                    break;
                default:
                    break;
            }
        }

        public List<StudentPoint> GetStudentPoints()
        {
            return StudentPoints;
        }

        public StudentPoint GetStudentPoint(string studentNumber)
        {
            StudentPoint foundStudenPoint = new StudentPoint();

            foreach (var studentpoint in StudentPoints)
            {
                if (studentpoint.Student.StudentNumber == studentNumber)
                {
                    foundStudenPoint = studentpoint;
                }
            }

            return foundStudenPoint;
        }

        public void UpdatePoints(StudentPoint studentPoint)
        {
            var studentpoint = StudentPoints.Find(x => x.Student.StudentNumber == studentPoint.Student.StudentNumber);
            var toUpdate = StudentPoints.IndexOf(studentPoint);

            StudentPoints[toUpdate] = studentPoint;

            switch (dataSource)
            {
                case DataSource.InMemory:
                    break;
                case DataSource.JsonFile:
                    jsonFile.SaveStudentPoints(StudentPoints);
                    break;
                case DataSource.Database:
                    break;
                default:
                    break;
            }
        }
    }
}
