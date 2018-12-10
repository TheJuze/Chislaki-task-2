using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Chart myChart = new Chart();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            double[] A = new double[Program.N];
            A[0] = Program.a;
            for (int j = 1; j < Program.N; j++)
            {
                A[j] = A[j - 1] + Program.step;
            }
            //
            double[] X = new double[Program.N];
            double dx = Program.b - Program.a;
            for (int j = 0; j < Program.N; j++)
            {
                double d = Math.Cos((2.0 * j + 1.0) / (2.0 * Program.N + 2.0) * Math.PI);
                X[j] = (dx *d  + Program.b + Program.a) / 2.0;
            }
            //кладем его на форму и растягиваем на все окно.
            myChart.Parent = this;
            myChart.Dock = DockStyle.Fill;
            //добавляем в Chart область для рисования графиков, их может быть
            //много, поэтому даем ей имя.
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
            myChart.ChartAreas.Add(new ChartArea("Pogreshnost"));
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
           Series mySeriesOfPoint = new Series("FUNCTION");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";
            //
            Series lagranjSeries = new Series("LagranjFunction");
            lagranjSeries.ChartType = SeriesChartType.Line;
            lagranjSeries.ChartArea = "Math functions";
            //
            Series lagranjSeries1 = new Series("LagranjFunction1");
            lagranjSeries1.ChartType = SeriesChartType.Line;
            lagranjSeries1.ChartArea = "Math functions";
            //
            Series greh = new Series("Greh");
            greh.ChartType = SeriesChartType.Line;
            greh.ChartArea = "Pogreshnost";
            //
            Series sins = new Series("Sins");
            sins.ChartType = SeriesChartType.Line;
            sins.ChartArea = "Pogreshnost";
            for (double x = Program.a; x <= Program.b; x +=0.0001)
            {
                mySeriesOfPoint.Points.AddXY(x, Equation.GetFunctionValue(x));
                lagranjSeries.Points.AddXY(x, Polynom.LagranjPolynom(x,A));
                lagranjSeries1.Points.AddXY(x, Polynom.LagranjPolynom(x,X));
                greh.Points.AddXY(x,Math.Abs( Equation.GetFunctionValue(x) - Polynom.LagranjPolynom(x, A)));
                sins.Points.AddXY(x,Math.Abs(Equation.GetFunctionValue(x) - Polynom.LagranjPolynom(x, X)) );
            }
            //Добавляем созданный набор точек в Chart
            myChart.Series.Add(mySeriesOfPoint);
            myChart.Series.Add(lagranjSeries);
            myChart.Series.Add(lagranjSeries1);
            myChart.Series.Add(greh);
            myChart.Series.Add(sins);

        }
    }
}
