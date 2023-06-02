using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Pages;
using ShoolProgram_Anayatov.Pages.Autorization;
using ShoolProgram_Anayatov.Pages.Menus;
using System;
using System.Collections.Generic;
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

namespace ShoolProgram_Anayatov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Navigation.frameView = MainFrame;
            MainFrame.Navigate(new PageAutorizationMain());
            Navigation2.frameView = MenuFrame;
        }
    }
}
