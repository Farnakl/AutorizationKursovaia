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

namespace ShoolProgram_Anayatov.Pages.AddInfoPages
{
    /// <summary>
    /// Логика взаимодействия для PageAddProviders.xaml
    /// </summary>
    public partial class PageAddProviders : Page
    {
        public PageAddProviders()
        {
            InitializeComponent();

            CmbStatusProvider.DisplayMemberPath = "Name";
            CmbStatusProvider.SelectedValuePath = "id";
            CmbStatusProvider.ItemsSource = Connection.DBConnect.StatusProvider.ToList();

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
                try
                {
                    Provider provider = new Provider()
                    {
                        Telephone = TxbTelephone.Text,
                        PurchaseDate = DateTime.Parse(DatDatePurchase.Text),
                        StatusProvider = CmbStatusProvider.SelectedItem as StatusProvider,
                        TIN = TxbINN.Text,
                        Email = TxbEmail.Text,
                        CheckingAccount = TxbBankAccont.Text,
                        Address = TxbAddress.Text,
                        Name = TxbName.Text,
                    };




                    Connection.DBConnect.Provider.Add(provider);

                    Connection.DBConnect.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Navigation.frameView.GoBack();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                        "Критическая ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }

            }

        }
            private void BtnBack_Click(object sender, RoutedEventArgs e)
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
