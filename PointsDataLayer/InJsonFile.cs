using PUPHubModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PointsDataLayer
{
    public class InJsonFile
    {
        private List<Student> Students;
        private List<StudentPoint> StudentPoints;

        private string _jsonStudentPointsFileName;
        private string _jsonStudentFileName;

        public InJsonFile()
        {
            Students = new List<Student>();
            StudentPoints = new List<StudentPoint>();

            _jsonStudentPointsFileName = 
                $"{AppDomain.CurrentDomain.BaseDirectory}/Data/studentpoints.json";

            _jsonStudentFileName =
                $"{AppDomain.CurrentDomain.BaseDirectory}/Data/students.json";

            PopulateStudentList();
            PopulateStudentPointList();
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public List<StudentPoint> GetStudentPoints()
        {
            return StudentPoints;
        }

        public void SaveStudentPoints(List<StudentPoint> studentPoints)
        {
            StudentPoints = studentPoints;
            SaveStudentPointToFile();
        }

        private void SaveStudentPointToFile()
        {
            using (var outputStream = File.OpenWrite(_jsonStudentPointsFileName))
            {
                JsonSerializer.Serialize<List<StudentPoint>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , StudentPoints);
            }
        }

        private void PopulateStudentPointList()
        {
            GetStudentPointsFromFile();
        }

        private void PopulateStudentList()
        {
            GetStudentsFromFile();
        }

        private void GetStudentPointsFromFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonStudentPointsFileName))
            {
                this.StudentPoints = JsonSerializer.Deserialize<List<StudentPoint>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }
        private void GetStudentsFromFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonStudentFileName))
            {
                this.Students = JsonSerializer.Deserialize<List<Student>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }
    }
}
