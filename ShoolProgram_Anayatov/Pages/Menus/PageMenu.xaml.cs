using ShoolProgram_Anayatov.Classes;
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

namespace ShoolProgram_Anayatov.Pages.Menus
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void GoToGridPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageTable());
        }

        private void GoToTablePage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageTableTeachers());
        }

        private void BtnRegist_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageTableProgress());
        }

        private void GoToProvidersPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageProviders());
        }

        private void BtnAnaliz_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageMain());
        }
    }
}
