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
    /// Логика взаимодействия для PageTableTeachers.xaml
    /// </summary>
    public partial class PageTableTeachers : Page
    {
        public PageTableTeachers()
        {
            InitializeComponent();
            DataGridEmployees.ItemsSource = null;
            DataGridEmployees.ItemsSource = Connection.DBConnect.Employees.ToList();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Refresh();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }
        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {

            Navigation.frameView.Navigate(new PageEditStudent ((sender as Button).DataContext as Employees));
        }


        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (TxbSearch.Text != "")
                {
                    string searchString = TxbSearch.Text.ToLower();

                    var itemsList = Connection.DBConnect.Employees.ToList();

                    //Ищем совпадения в таблице 
                    var searchResults = itemsList.Where(item => item.Name.ToLower().Contains(searchString)).ToList();

                    //Заполняем таблицу записями, где есть совпадения
                    DataGridEmployees.ItemsSource = searchResults.ToList();
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
            try
            {
                for (int i = 0; i < DataGridEmployees.SelectedItems.Count; i++)
                {
                    Employees employees = DataGridEmployees.SelectedItems[i] as Employees;
                    Connection.DBConnect.Employees.Remove(employees);
                }

                Connection.DBConnect.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information
                );
                DataGridEmployees.ItemsSource = null;
                DataGridEmployees.ItemsSource = Connection.DBConnect.Employees.ToList();
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageAddEmploees());
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageEditEmployees((sender as Button).DataContext as Employees));
        }
    }

}
