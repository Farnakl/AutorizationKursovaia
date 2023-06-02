using Microsoft.Graph;
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

namespace ShoolProgram_Anayatov.Pages.EditInfoPages
{
    /// <summary>
    /// Логика взаимодействия для PageEditEmployees.xaml
    /// </summary>
    public partial class PageEditEmployees : Page
    {

        private int employeesId;
        public PageEditEmployees(Employees employees)
        {
            InitializeComponent();

            CmbJobTitle.DisplayMemberPath = "Name";
            CmbJobTitle.SelectedValuePath = "id";
            CmbJobTitle.ItemsSource = Connection.DBConnect.JobTitle.ToList();
            CmbJobTitle.Text = employees.JobTitle.Name.ToString();

            CmbFamilyStatus.DisplayMemberPath = "Name";
            CmbFamilyStatus.SelectedValuePath = "id";
            CmbFamilyStatus.ItemsSource = Connection.DBConnect.FamilyStatus.ToList();
            CmbFamilyStatus.Text = employees.FamilyStatus.Name.ToString();

            CmbEducation.DisplayMemberPath = "EducationName";
            CmbEducation.SelectedValuePath = "id";
            CmbEducation.ItemsSource = Connection.DBConnect.Education.ToList();
            CmbEducation.Text = employees.Education.EducationName.ToString();

            TxbName.Text = employees.Name.ToString();
            TxbPassport.Text = employees.Passport.ToString();
            TxbRegAddres.Text = employees.RegistrationAddress.ToString();
            TxbResAddres.Text = employees.ResidentialAddress.ToString();
            TxbTelephone.Text = employees.Telephone.ToString();
            TxbTIN.Text = employees.TIN.ToString();
            DatOfBirth.Text = employees.DateOfBirth.ToString();

            employeesId = employees.id;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == "" || CmbFamilyStatus.Text == "" || CmbJobTitle.Text == "" ||
                DatOfBirth.Text == "" || CmbEducation.Text == "" || TxbPassport.Text == "" ||
                TxbRegAddres.Text == "" || TxbResAddres.Text == ""
                || TxbTelephone.Text == "" || TxbTIN.Text == "")
            {
                MessageBox.Show("Поля пусты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                Anayatov_magazineEntities context = new Anayatov_magazineEntities();
                var employees = context.Employees.Where(c => c.id == employeesId).FirstOrDefault();

                employees.Name = TxbName.Text;
                employees.idFamilyStatus = (CmbFamilyStatus.SelectedItem as FamilyStatus).id;
                employees.DateOfBirth = DateTime.Parse(DatOfBirth.Text);
                employees.idEducation = (CmbEducation.SelectedItem as Education).id;
                employees.idJobTitle = (CmbJobTitle.SelectedItem as JobTitle).id;
                employees.Passport= TxbPassport.Text;
                employees.Telephone = TxbTelephone.Text;
                employees.TIN = TxbTIN.Text;
                employees.RegistrationAddress = TxbRegAddres.Text;
                employees.ResidentialAddress = TxbResAddres.Text;


                context.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                Navigation.frameView.GoBack();

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

        private void TxbTIN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void TxbPassport_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }
    }
}
