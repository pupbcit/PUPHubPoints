using System;
using PointsDataLayer;

namespace PointsBusinessRules
{
    public class PointsRules
    {
        public static bool UsePoints(int pointsToUse)
        {
            bool success = false;

            if (pointsToUse <= InMemoryData.GetPoints())
            {
                InMemoryData.UsePoints(pointsToUse);
                success = true;
                
            }
            else
            {
                success = false;
            }

            return success;
        }

        public static int GetCurrentPoints() 
        {
            return InMemoryData.GetPoints();
        }
    }
}
