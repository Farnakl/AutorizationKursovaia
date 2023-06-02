using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
using ShoolProgram_Anayatov.Pages.EditInfoPages;
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

namespace ShoolProgram_Anayatov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowProviderInfo.xaml
    /// </summary>
    public partial class ShowProviderInfo : Page
    {
        public ShowProviderInfo(Provider provider)
        {
            InitializeComponent();
         
            TxbBankAccont.Text = provider.CheckingAccount.ToString();
            TxbDatePurchase.Text = provider.PurchaseDate.ToString();
            TxbEmail.Text = provider.Email.ToString();
            TxbINN.Text = provider.TIN.ToString();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }
    }
}
