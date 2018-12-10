using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        public static double a = -1.0;//левая, правая границы
        public static double b = 1.0;//левая, правая границы
        public static int N = 6;//число узлов
        public static double step = (Math.Abs(a) + Math.Abs(b)) / (N-1); //шаг
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
