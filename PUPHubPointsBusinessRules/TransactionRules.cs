using PUPHubModels;
using PUPHubPointsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUPHubPointsBusinessRules
{
    public class TransactionRules
    {
        public TransactionRules()
        {

        }

        public void SaveStudentPointsTransaction(StudentPointsTransaction studentPointsTransaction)
        {

        }

        public List<StudentPointsTransaction> GetAllStudentPointsTransactions()
        {
            return null;
        }

        public List<StudentPointsTransaction> GetAllStudentPointsTransaction(Student student)
        {
            return null;
        }

        public List<StudentPointsTransaction> GetAllStudentPointsTransaction(Student student, DateTime transactionDateFrom, DateTime transactionDateTo)
        {
            return null;
        }

        public List<StudentPointsTransaction> GetAllStudentPointsTransaction(Student student, TransactionType transactionType)
        {
            return null;
        }

    }
}
