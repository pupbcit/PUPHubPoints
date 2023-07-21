using System.Collections.Generic;
using PointsDataLayer;
using PUPHubModels;
using PUPHubPointsDataServices;

namespace PointsBusinessRules
{
    public class PointsRulesService
    {
        private StudentPointsDataService studentPointDataService;
        private StudentRulesService studentRulesService;

        public PointsRulesService()
        {
            studentPointDataService = new StudentPointsDataService(new SqlData());
            studentRulesService = new StudentRulesService();
        }

        public List<StudentPoint> GetStudentPoints()
        {
            return studentPointDataService.GetStudentPoints();
        }

        public StudentPoint GetStudentPoint(string studentNumber)
        {
            return studentPointDataService.GetStudentPoint(studentNumber);
        }

        public StudentPoint UseStudentPoints(string studentNumber, int points)
        {
            //Get student points
            var studentPoint = GetStudentPoint(studentNumber);

            //check if point is enough
            if (studentPoint.Point >= points)
            {
                //less points to the current points
                studentPoint.Point = studentPoint.Point - points;
                studentPointDataService.UpdatePoints(studentPoint);
            }

            return studentPoint;
        }

        public StudentPoint AddStudentPoints(string studentNumber, int points)
        {
            var studentPoint = GetStudentPoint(studentNumber);

            if (studentPoint.Student.StudentNumber != null && points > 0)
            {
                studentPoint.Point = studentPoint.Point + points;
                studentPointDataService.UpdatePoints(studentPoint);
            }

            return studentPoint;
        }

        public int GetCurrentPoint(string studentNumber)
        {
            var studentPoint = GetStudentPoint(studentNumber);

            return studentPoint != null ? studentPoint.Point : -1;
        }

        public int CreateStudentPoints(string studentNumber, int point)
        {
            int result = 0;

            //fail this operation if the student is already registered in the points program
            if (GetStudentPoint(studentNumber).Student == null)
            {
                return result;
            }

            var student = new Student();
			student = studentRulesService.GetStudent(studentNumber); //call get student api
            
            if (student != null)
            {
                result = studentPointDataService.AddStudentPoint(new StudentPoint()
                {
                    Student = student,
                    Point = point
                });
            }

            return result;
        }
    }
}
