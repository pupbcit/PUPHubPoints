using PointsDataLayer;
using PUPHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsBusinessRules
{
    public class StudentRulesService
    {
        StudentDataService studentDataService;

        public StudentRulesService()
        {
            studentDataService = new StudentDataService(DataSource.JsonFile);
        }

        public bool IsStudentExists(string studentNumber)
        {
            var result = studentDataService.GetStudent(studentNumber);

            return result != null;
        }

        public Student GetStudent(string studentNumber)
        {
            return studentDataService.GetStudent(studentNumber);
        }
    }
}
