using PointsDataLayer;
using PUPHubModels;

namespace PointsBusinessRules
{
	public class StudentRulesService
    {
        StudentDataService studentDataService;

        public StudentRulesService()
        {
            studentDataService = new StudentDataService();
        }

        public bool IsStudentExists(string studentNumber)
        {
            var result = studentDataService.GetStudent(studentNumber);

            return result.StudentNumber != null;
        }

        public Student GetStudent(string studentNumber)
        {
            return studentDataService.GetStudent(studentNumber);
        }

        //creating student account for now, but should get from other modules
        public void CreateStudent(Student student)
        {
            studentDataService.CreateStudent(student);
        }
    }
}
