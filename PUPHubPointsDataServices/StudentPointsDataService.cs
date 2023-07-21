using PUPHubModels;
using PUPHubPointsDataServices;
using System.Collections.Generic;

namespace PointsDataLayer
{
    public class StudentPointsDataService
    {

        IStudentPointsData _studentPointsData;

        public StudentPointsDataService(IStudentPointsData studentPointsData)
        {
            _studentPointsData = studentPointsData;
        }

        public List<StudentPoint> GetStudentPoints()
        {
            return _studentPointsData.GetStudentPoints();
        }

        public StudentPoint GetStudentPoint(string studentNumber)
        {
            return _studentPointsData.GetStudentPoints(studentNumber);
        }

        public void UpdatePoints(StudentPoint studentPoint)
        {
            _studentPointsData.UpdateStudentPoint(studentPoint);
        }

        public int AddStudentPoint(StudentPoint studentPoint)
        {
            return _studentPointsData.AddStudentPoints(studentPoint);
        }
    }
}
