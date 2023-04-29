namespace PointsDataLayer
{
    public class InMemoryData //sample only
    {
        private static string studentNumber = "2011-00066-BN-0";
        private static int points = 95;

        public static string GetStudentNumber()
        {
            return studentNumber;
        }

        public static int GetPoints()
        {
            return points;
        }

        public static void UsePoints(int pointsToUse)
        {
            points -= pointsToUse;
        }
    }
}
