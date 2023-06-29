using PUPHubModels;
using PUPHubPointsDataServices;
using System.Collections.Generic;

namespace PointsDataLayer
{
    public class StudentPointsDataService
    {
        private List<StudentPoint> StudentPoints { get; set; }

        private DataSource dataSource;
        private InMemoryData memoryData = new InMemoryData();
        private InJsonFile jsonFile = new InJsonFile();

        IStudentPointsData _studentPointsData;

        public StudentPointsDataService(IStudentPointsData studentPointsData)
        {
            _studentPointsData = studentPointsData;

            StudentPoints = new List<StudentPoint>();

            StudentPoints = studentPointsData.GetStudentPoints();
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
            _studentPointsData.UpdateStudentPoint(studentPoint);
        }

    }
}
