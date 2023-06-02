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
using Xceed.Wpf.AvalonDock.Controls;

namespace ShoolProgram_Anayatov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProviders.xaml
    /// </summary>
    public partial class PageProviders : Page
    {
        public PageProviders()
        {
            InitializeComponent();
            DataGridProviders.ItemsSource = null;
            DataGridProviders.ItemsSource = Connection.DBConnect.Provider.ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbSearch.Text != "")
                {
                    string searchString = TxbSearch.Text.ToLower();

                    var itemsList = Connection.DBConnect.Provider.ToList();

                    //Ищем совпадения в таблице
                    var searchResults = itemsList.Where(item => item.Name.ToLower().Contains(searchString)).ToList();

                    //Заполняем таблицу записями, где есть совпадения
                    DataGridProviders.ItemsSource = searchResults.ToList();
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
                for (int i = 0; i < DataGridProviders.SelectedItems.Count; i++)
                {
                    Provider providers = DataGridProviders.SelectedItems[i] as Provider;
                    Connection.DBConnect.Provider.Remove(providers);
                }



                Connection.DBConnect.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information
                );
                DataGridProviders.ItemsSource = null;
                DataGridProviders.ItemsSource = Connection.DBConnect.Provider.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }

        private void BtnShowInfoProviders_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new ShowProviderInfo((sender as Button).DataContext as Provider));
        }

        private void TxbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxbSearch.Text = "";
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageEditProvider((sender as Button).DataContext as Provider));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageAddProviders());
        }
    }
}
