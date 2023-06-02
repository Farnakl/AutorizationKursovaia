using Microsoft.Graph;
using Newtonsoft.Json;
using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
            
    
        }

        private Task BtnLogin_ClickAsync(object sender, RoutedEventArgs e)
        {
            return Task.CompletedTask;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageTable());
        }
    }
}
