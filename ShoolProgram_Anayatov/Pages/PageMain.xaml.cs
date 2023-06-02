using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.IdentityModel.Protocols;
using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShoolProgram_Anayatov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        
        public SeriesCollection SeriesCollection { get; set; }
        public PageMain()
        {
            InitializeComponent();

            

            SeriesCollection = new SeriesCollection

            {
            new LineSeries
            {
                Title = "Покупка",
                Values = new ChartValues<double> { 554, 255, 655, 1342, 123, 120, 100, 95, 577, 525, 584, 1025, 57, 69, 78, 99, 65 }
            },
            new LineSeries
            {
                Title = "Продажа",
                Values = new ChartValues<double> { 577, 333, 684, 1225, 114, 140, 90, 555, 550, 510, 994, 66, 71, 80, 108, 78, 85 }
            }

            
        };

            // присваиваем набор данных графику
            DataContext = this;
        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {
           List<Series> list = new List<Series>();
        }

        private void CartesianChart_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
