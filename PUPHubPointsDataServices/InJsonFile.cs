using PUPHubModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PointsDataLayer
{
	public class InJsonFile
    {
        private List<Student> Students;

        private string _jsonStudentFileName;

        public InJsonFile()
        {
            Students = new List<Student>();

            _jsonStudentFileName =
                $"{AppDomain.CurrentDomain.BaseDirectory}/Data/students.json";

            PopulateStudentList();
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public Student GetStudent(string studentNumber)
        {
            return Students.Where(x => x.StudentNumber == studentNumber).FirstOrDefault();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            SaveStudentToFile();
        }

        private void SaveStudentToFile()
        {
            using (var outputStream = File.OpenWrite(_jsonStudentFileName))
            {
                JsonSerializer.Serialize<List<Student>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , Students);
            }
        }

        private void PopulateStudentList()
        {
            GetStudentsFromFile();
        }

        private void GetStudentsFromFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonStudentFileName))
            {
                this.Students = JsonSerializer.Deserialize<List<Student>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions 
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }
    }
}
