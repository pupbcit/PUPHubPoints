using PUPHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsModels
{
    public class StudentPointsTransaction
    {
        public StudentPoint AvailableStudentPoints { get; set; }
        public DateTime TransactionDateTime { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
