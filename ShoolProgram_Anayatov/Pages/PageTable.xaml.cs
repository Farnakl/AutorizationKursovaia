using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
using ShoolProgram_Anayatov.Pages.AddInfoPages;
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
    /// Логика взаимодействия для PageTable.xaml
    /// </summary>
    public partial class PageTable : Page
    {
        public PageTable()
        {
            InitializeComponent();
           
            DataGridProduct.ItemsSource = null;
            DataGridProduct.ItemsSource = Connection.DBConnect.Product.ToList();

        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Refresh();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void DataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageEditStudent((sender as Button).DataContext as Employees));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            

                try
                {
                    if (TxbSearch.Text != "")
                    {
                        string searchString = TxbSearch.Text.ToLower();

                        var itemsList = Connection.DBConnect.Product.ToList();

                        //Ищем совпадения в таблице
                        var searchResults = itemsList.Where(item => item.NameProduct.ToLower().Contains(searchString)).ToList();

                        //Заполняем таблицу записями, где есть совпадения
                        DataGridProduct.ItemsSource = searchResults.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Вы ничего не ввели", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }
                catch (Exception)
                {
                    MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }
        private void BtnDelete1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < DataGridProduct.SelectedItems.Count; i++)
                {
                    Product products = DataGridProduct.SelectedItems[i] as Product;
                    Connection.DBConnect.Product.Remove(products);
                }

                Connection.DBConnect.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information
                );
                DataGridProduct.ItemsSource = null;
                DataGridProduct.ItemsSource = Connection.DBConnect.Product.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }

        private void TxbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxbSearch.Text = "";
        }

        private void DataGridProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageEditProduct((sender as Button).DataContext as Product));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageAddProduct());
        }
    }
}
