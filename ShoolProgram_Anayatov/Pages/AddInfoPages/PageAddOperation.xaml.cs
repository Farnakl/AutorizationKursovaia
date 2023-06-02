using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace ShoolProgram_Anayatov.Pages.AddInfoPage
{
    /// <summary>
    /// Логика взаимодействия для PageAddOperation.xaml
    /// </summary>
    public partial class PageAddOperation : Page
    {
        public PageAddOperation()
        {
            InitializeComponent();

            CmbProduct.DisplayMemberPath = "NameProduct";
            CmbProduct.SelectedValuePath = "id";
            CmbProduct.ItemsSource = Connection.DBConnect.Product.ToList();

            CmbEmployeers.DisplayMemberPath = "Name";
            CmbEmployeers.SelectedValuePath = "id";
            CmbEmployeers.ItemsSource = Connection.DBConnect.Employees.ToList();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
                
            if (TxbQuantity.Text == "" || CmbProduct.Text == "" || CmbEmployeers.Text == "" ||
                DatPurchase.Text == "")
            {
                MessageBox.Show("Поля пусты",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            { 
                    try
                    {
                        Operation operation = new Operation()
                        {
                            Quantity = TxbQuantity.Text,
                            DateOfsale = DateTime.Parse(DatPurchase.Text),
                            Product = CmbProduct.SelectedItem as Product,
                            Employees = CmbEmployeers.SelectedItem as Employees

                        };

                       


                        Connection.DBConnect.Operation.Add(operation);
                       
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

        private void TxbQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }
    }
}
