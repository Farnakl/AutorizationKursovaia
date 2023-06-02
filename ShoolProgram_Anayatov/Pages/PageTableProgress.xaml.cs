using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
using ShoolProgram_Anayatov.Pages.AddInfoPage;
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
    /// Логика взаимодействия для PageTableProgress.xaml
    /// </summary>
    public partial class PageTableProgress : Page
    {
        public PageTableProgress()
        {
            InitializeComponent();
            DataGridOperation.ItemsSource = null;
            DataGridOperation.ItemsSource = Connection.DBConnect.Operation.ToList();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Refresh();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (TxbSearch.Text != "")
                {
                    string searchString = TxbSearch.Text.ToLower();

                    var itemsList = Connection.DBConnect.Operation.ToList();

                    //Ищем совпадения в таблице
                    var searchResults = itemsList.Where(item => item.Employees.Name.ToLower().Contains(searchString)).ToList();

                    //Заполняем таблицу записями, где есть совпадения
                    DataGridOperation.ItemsSource = searchResults.ToList();
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
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TxbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxbSearch.Text = "";
        }

        private void BtnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < DataGridOperation.SelectedItems.Count; i++)
                {
                    Operation operations = DataGridOperation.SelectedItems[i] as Operation;
                    Connection.DBConnect.Operation.Remove(operations);
                }

                Connection.DBConnect.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information
                );
                DataGridOperation.ItemsSource = null;
                DataGridOperation.ItemsSource = Connection.DBConnect.Operation.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageEditOperation((sender as Button).DataContext as Operation));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageAddOperation());
        }
    }
}
