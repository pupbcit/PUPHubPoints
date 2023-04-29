using PointsDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsBusinessRules
{
    public class StudentNumberRules
    {
        public static bool ValidateStudentNumber(string studentNumber)
        {
            return studentNumber.Equals(InMemoryData.GetStudentNumber()) ? true : false; //ternary operators
        }
    }
}
