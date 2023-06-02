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

namespace ShoolProgram_Anayatov.Pages.AddInfoPages
{
    /// <summary>
    /// Логика взаимодействия для PageAddProduct.xaml
    /// </summary>
    public partial class PageAddProduct : Page
    {
        public PageAddProduct()
        {
            InitializeComponent();

            CmbTypeOfProduct.DisplayMemberPath = "NameType";
            CmbTypeOfProduct.SelectedValuePath = "id";
            CmbTypeOfProduct.ItemsSource = Connection.DBConnect.TypeOfProduct.ToList();

            CmbStatus.DisplayMemberPath = "NameStatus";
            CmbStatus.SelectedValuePath = "id";
            CmbStatus.ItemsSource = Connection.DBConnect.StatusProduct.ToList();
          

            CmbProvider.DisplayMemberPath = "Name";
            CmbProvider.SelectedValuePath = "id";
            CmbProvider.ItemsSource = Connection.DBConnect.Provider.ToList();

            CmbUnit.DisplayMemberPath = "NameUnit";
            CmbUnit.SelectedValuePath = "id";
            CmbUnit.ItemsSource = Connection.DBConnect.Unit.ToList();
         
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbNameProduct.Text == "" || TxbPurchasePrice.Text == "" || TxbPurchaseVolue.Text == "" ||
                CmbUnit.Text == "" || CmbProvider.Text == "" || CmbTypeOfProduct.Text == "" || CmbStatus.Text == "")
            {
                MessageBox.Show("Поля пусты",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    Product product = new Product()
                    {
                        NameProduct = TxbNameProduct.Text,
                        PurchasePrice = TxbPurchasePrice.Text,
                        PurchaseVolume = TxbPurchaseVolue.Text,
                        Unit = CmbUnit.SelectedItem as Unit,
                        Provider = CmbProvider.SelectedItem as Provider,
                        TypeOfProduct = CmbTypeOfProduct.SelectedItem as TypeOfProduct,
                        StatusProduct = CmbStatus.SelectedItem as StatusProduct,
                    };



                    Connection.DBConnect.Product.Add(product);

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

        private void TxbPurchaseVolue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void TxbPurchasePrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }
    }
}
