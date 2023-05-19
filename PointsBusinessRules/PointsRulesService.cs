using System;
using System.Collections.Generic;
using PointsDataLayer;
using PUPHubModels;

namespace PointsBusinessRules
{
    public class PointsRulesService
    {
        private StudentPointDataService studentPointDataService;

        public PointsRulesService()
        {
            studentPointDataService = new StudentPointDataService(DataSource.JsonFile);
        }

        public List<StudentPoint> GetStudentPoints()
        {
            return studentPointDataService.GetStudentPoints();
        }

        public StudentPoint GetStudentPoint(Student student)
        {
            var studentPoints = GetStudentPoints();
            var foundStudentPoint = new StudentPoint();

            foreach (var studentPoint in studentPoints)
            {
                if (studentPoint.Student.StudentNumber == student.StudentNumber)
                {
                    foundStudentPoint = studentPoint;
                    break;
                }
            }

            return foundStudentPoint;
        }

        public int UseStudentPoints(Student student, int points)
        {
            var studentPoint = studentPointDataService.GetStudentPoint(student.StudentNumber);
            var newPoints = 0;

            if (studentPoint.Point >= points)
            {
                studentPoint.Point = studentPoint.Point - points;
                studentPointDataService.UpdatePoints(studentPoint);
                newPoints = studentPoint.Point;
            }
            else
            {
                newPoints = -1;
            }

            return newPoints;
        }

        public int AddStudentPoints(Student student, int points)
        {
            var studentPoint = studentPointDataService.GetStudentPoint(student.StudentNumber);

            studentPoint.Point = studentPoint.Point + points;
            studentPointDataService.UpdatePoints(studentPoint);
            
            return studentPoint.Point;
        }

        public bool IsPointsSufficient(Student student, int points)
        {
            var studentPoint = studentPointDataService.GetStudentPoint(student.StudentNumber);

            return studentPoint.Point >= points;
        }

        public int GetCurrentPoint(Student student)
        {
            var studentPoint = GetStudentPoint(student);

            return studentPoint != null ? studentPoint.Point : -1;
        }
    }
}
