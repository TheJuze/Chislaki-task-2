using System;

namespace WindowsFormsApplication1
{
    class Equation
    {
        public static double GetFunctionValue(double x)//Исходная функция
        {
            double value = x * x+1-Math.Acos(x);
            return value;
        }
    }
}
