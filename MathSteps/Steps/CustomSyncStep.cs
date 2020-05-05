using DecisionsFramework.Design.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This is a sync step which behaves like a method step in "SimpleStepCode" but is a 
/// full implementation of our interfaces.  For more advanced steps you should use a 
/// CustomAsyncStep
/// </summary>
namespace MathSteps.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration", "Test Math Steps")]
    class DeviationMethods
    {
        public static bool AbsDev(double today, double yesterday)
        {
            double Sub1 = yesterday - today;
            if (Sub1 < 0)
                Sub1 = Sub1 * (-1);
            double absValue = Sub1;
            double multiplyup = yesterday + (absValue * 8);
            double multiplydown = yesterday - (absValue * 8);
            //if (today > multiplyup)
            //    return true;
            //else if (today < multiplydown)
            //    return true;
            if (today > (yesterday * 8))
                return true;
            else
                return false;
        }
        
        public static bool StdDeviation(float[] numbers, float LastDayPrice)
        {
            float FMean = 0;
            float TempMean = 0;
            float FLastDayPrice = (float)LastDayPrice;
            foreach (var num in numbers)
            {
                TempMean = TempMean + (float)num;
            }
            FMean = TempMean / (numbers.Length); float fval = 0;
            foreach (var item in numbers)
            {
                fval = fval + ((FMean - (float)item) * (FMean - (float)item));
            }
            float f = fval / (numbers.Length);
            float fstdDev = (float)System.Math.Sqrt(f);
            float Less = (4 * fstdDev);
            if ((FLastDayPrice < (FMean - Less)))
                return true;
            else if ((FLastDayPrice > (FMean + Less)))
                return true;
            else
                return false;
        }
    }
}
