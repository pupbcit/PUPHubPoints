using PUPHubModels;
using System;
using System.Collections.Generic;
using System.Net;

namespace PointsDataLayer
{
    public class InMemoryData
    {
        private List<Student> Students;
        private List<StudentPoint> StudentPoints;
        private const int memoryDefaultPoints = 100;

        public InMemoryData()
        {
            Students = new List<Student>();
            StudentPoints = new List<StudentPoint>();
            PopulateStudentList();
            PopulateStudentPointList();
        }

        private void PopulateStudentPointList()
        {
            var studentPoint1 = new StudentPoint
            {
                Student = GetStudent("2022-00215-BN-0"),
                Point = memoryDefaultPoints
            };

            var studentPoint2 = new StudentPoint
            {
                Student = GetStudent("2022-00216-BN-0"),
                Point = memoryDefaultPoints
            };

            var studentPoint3 = new StudentPoint
            {
                Student = GetStudent("2022-00221-BN-0"),
                Point = memoryDefaultPoints
            };

            var studentPoint4 = new StudentPoint
            {
                Student = GetStudent("2022-00450-BN-0"),
                Point = memoryDefaultPoints
            };

            var studentPoint5 = new StudentPoint
            {
                Student = GetStudent("2022-00505-BN-0"),
                Point = memoryDefaultPoints
            };


            StudentPoints.Add(studentPoint1);
            StudentPoints.Add(studentPoint2);
            StudentPoints.Add(studentPoint3);
            StudentPoints.Add(studentPoint4);
            StudentPoints.Add(studentPoint5);
        }

        private void PopulateStudentList()
        {
            Student sampleStudent1 = new Student
            {
                StudentNumber = "2022-00215-BN-0",
                FirstName = "Andrei",
                LastName = "Capili"
            };

            Student sampleStudent2 = new Student
            {
                StudentNumber = "2022-00216-BN-0",
                FirstName = "Loise Jordan",
                LastName = "Pelaez"
            };

            Student sampleStudent3 = new Student
            {
                StudentNumber = "2022-00221-BN-0",
                FirstName = "James Miguel",
                LastName = "Rasay"
            };

            Student sampleStudent4 = new Student
            {
                StudentNumber = "2022-00450-BN-0",
                FirstName = "Sebastian Kirk",
                LastName = "Fullon"
            };

            Student sampleStudent5 = new Student
            {
                StudentNumber = "2022-00505-BN-0",
                FirstName = "Dan Jandel",
                LastName = "De Ramos"
            };

            Students.Add(sampleStudent1);
            Students.Add(sampleStudent2);
            Students.Add(sampleStudent3);
            Students.Add(sampleStudent4);
            Students.Add(sampleStudent5);
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public List<StudentPoint> GetStudentPoints()
        {
            return StudentPoints;
        }

        private Student GetStudent(string studentNumber)
        {
            Student foundStudent = new Student();

            foreach (var student in Students)
            {
                if (student.StudentNumber == studentNumber)
                {
                    foundStudent = student;
                }
            }

            return foundStudent;
        }
    }
}
