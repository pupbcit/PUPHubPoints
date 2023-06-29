using PUPHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsDataServices
{
    public interface IStudentPointsData
    {
        List<StudentPoint> GetStudentPoints();
        void SaveStudentPoints(List<StudentPoint> studentPoints);

        void UpdateStudentPoint(StudentPoint studentPoint);
    }
}
