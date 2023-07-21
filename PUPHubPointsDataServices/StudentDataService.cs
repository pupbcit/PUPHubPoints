using PUPHubModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsDataLayer
{
    //All STUDENT data will be coming from JsonFile while STUDENTPOINT data will be in SQL DB
    public class StudentDataService
    {
        private InJsonFile jsonFile;
        
        public StudentDataService()
        {
            jsonFile = new InJsonFile();
        }

        public List<Student> GetStudents()
        {
            return jsonFile.GetStudents();
        }

        public Student GetStudent(string studentNumber)
        {
            return jsonFile.GetStudent(studentNumber);
        }

		public void CreateStudent(Student student)
		{
            jsonFile.AddStudent(student);
		}
	}
}
