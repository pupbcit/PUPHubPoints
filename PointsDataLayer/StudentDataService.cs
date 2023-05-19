using PUPHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsDataLayer
{
    public class StudentDataService
    {
        private List<Student> Students { get; set; }

        private DataSource dataSource;
        private InMemoryData memoryData = new InMemoryData();
        private InJsonFile jsonFile = new InJsonFile();
        
        public StudentDataService()
        {
            Students = new List<Student>();
            dataSource = DataSource.InMemory;

            Students = memoryData.GetStudents();
        }

        public StudentDataService(DataSource source)
        {
            Students = new List<Student>();

            dataSource = source;

            switch (dataSource)
            {
                case DataSource.InMemory:
                    Students = memoryData.GetStudents();
                    break;
                case DataSource.JsonFile:
                    Students = jsonFile.GetStudents();
                    break;
                case DataSource.Database:
                    break;
                default:
                    break;
            }
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public Student GetStudent(string studentNumber)
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
