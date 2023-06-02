using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace ShoolProgram_Anayatov.Pages.EditInfoPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditProvider.xaml
    /// </summary>
    public partial class PageEditProvider : Page
    {
        private int providerId;  
        public PageEditProvider(Provider provider)
        {
            InitializeComponent();

            TxbBankAccont.Text = provider.CheckingAccount.ToString();
            TxbEmail.Text = provider.Email.ToString();
            TxbINN.Text = provider.TIN.ToString();
            TxbAddress.Text = provider.Address.ToString();
            TxbName.Text = provider.Name.ToString();
            TxbTelephone.Text = provider.Telephone.ToString();

            CmbStatusProvider.DisplayMemberPath = "Name";
            CmbStatusProvider.SelectedValuePath = "id";
            CmbStatusProvider.ItemsSource = Connection.DBConnect.StatusProvider.ToList();
            CmbStatusProvider.Text = provider.StatusProvider.Name.ToString();

            DatDatePurchase.Text = provider.PurchaseDate.ToString();

            providerId = provider.id;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbTelephone.Text == "" || TxbName.Text == "" || TxbINN.Text == "" ||
                TxbEmail.Text == "" || TxbBankAccont.Text == "" || TxbAddress.Text == ""
                || CmbStatusProvider.Text == "" || DatDatePurchase.Text == "")
            {
                MessageBox.Show("Поля пусты",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                Anayatov_magazineEntities context = new Anayatov_magazineEntities();
                var provider = context.Provider.Where(c => c.id == providerId).FirstOrDefault();

                provider.Telephone = TxbTelephone.Text;
                provider.TIN = TxbINN.Text;
                provider.Address = TxbAddress.Text;
                provider.Email = TxbEmail.Text;
                provider.Name = TxbName.Text;
                provider.CheckingAccount = TxbBankAccont.Text;
                provider.idStatusProvider = (CmbStatusProvider.SelectedItem as StatusProvider).id;
                provider.PurchaseDate = DateTime.Parse(DatDatePurchase.Text);

                context.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Navigation.frameView.GoBack();
            }

        }
             public void BtnBack_Click(object sender, RoutedEventArgs e)
            {
                Navigation.frameView.GoBack();
            }

        private void TxbBankAccont_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void TxbTelephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void TxbINN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }
    }
}
