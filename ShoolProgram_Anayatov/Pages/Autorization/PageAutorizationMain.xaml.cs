using Microsoft.Graph;
using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
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

namespace ShoolProgram_Anayatov.Pages.Autorization
{
    /// <summary>
    /// Логика взаимодействия для PageAutorizationMain.xaml
    /// </summary>
    public partial class PageAutorizationMain : Page
    {
        public PageAutorizationMain()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = Connection.DBConnect.User.FirstOrDefault(
                        x => x.Login == TxbLogin.Text && x.Password == PsbPassword.Password
                    );

                if (data != null)
                {
                    switch (data.id)
                    {
                        case 1:
                            MessageBox.Show($"Добро пожаловать, {data.Login}! Ваша роль {data.JobTitle.Name}.");
                            Navigation.frameView.Navigate(new PageLogin());
                            Navigation2.frameView.Navigate(new PageMenu());
                            break;
                        case 3: MessageBox.Show($"Добро пожаловать, {data.Login}! Ваша роль {data.JobTitle.Name}."); break;
                    }
                }
                else MessageBox.Show("У вас нет учетной записи.");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая работа", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
