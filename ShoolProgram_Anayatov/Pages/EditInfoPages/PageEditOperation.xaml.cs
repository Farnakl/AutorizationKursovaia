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
    /// Логика взаимодействия для PageEditOperation.xaml
    /// </summary>
    public partial class PageEditOperation : Page
    {

        private int operationId;
        public PageEditOperation(Operation operation)
        {
            InitializeComponent();
            TxbQuantity.Text = operation.Quantity.ToString();

            CmbEmployeers.DisplayMemberPath = "Name";
            CmbEmployeers.SelectedValuePath = "id";
            CmbEmployeers.ItemsSource = Connection.DBConnect.Employees.ToList();
            CmbEmployeers.Text = operation.Employees.Name.ToString();

            CmbProduct.DisplayMemberPath = "NameProduct";
            CmbProduct.SelectedValuePath = "id";
            CmbProduct.ItemsSource = Connection.DBConnect.Product.ToList();
            CmbProduct.Text = operation.Product.NameProduct.ToString();

            DatPurchase.Text = operation.DateOfsale.ToString();

            operationId = operation.id;
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
                
                    Anayatov_magazineEntities context = new Anayatov_magazineEntities();
                    var operation = context.Operation.Where(c => c.id == operationId).FirstOrDefault();

                    operation.Quantity = TxbQuantity.Text;
                    operation.idProduct = (CmbProduct.SelectedItem as Product).id;
                    operation.DateOfsale = DateTime.Parse(DatPurchase.Text);
                    operation.idEmployees = (CmbEmployeers.SelectedItem as Employees).id;
                    
                    context.SaveChanges();
                    MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
               
                    Navigation.frameView.GoBack();
                
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
