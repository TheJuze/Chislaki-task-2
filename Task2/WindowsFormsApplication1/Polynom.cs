namespace WindowsFormsApplication1
{
    class Polynom
    {
        public static double LagranjPolynom(double x,double[] X)//p==false - равноудаленные, p==true - по формуле
        {
            double L = 0;
            for (int i = 0; i < Program.N; i++)
            {
                double l = 1;
                for (int k = 0; k < Program.N; k++)//Множители Лагранжа
                {
                    if (k != i)
                    {
                        l = l * (x - X[k]) / (X[i] - X[k]);
                    }
                }
                L += l * Equation.GetFunctionValue(X[i]);
            }
            return L;
        }
    }
}
