using ShoolProgram_Anayatov.Classes;
using ShoolProgram_Anayatov.Modeks;
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
    /// Логика взаимодействия для PageEditStudent.xaml
    /// </summary>
    public partial class PageEditStudent : Page
    {
        public PageEditStudent(Employees employees)
        {
            InitializeComponent();

            TxbAddresFact.Text = employees.ResidentialAddress.ToString();
            TxbAddresReg.Text = employees.RegistrationAddress.ToString();
            TxbINN.Text = employees.TIN.ToString();
            TxbPassport.Text = employees.Passport.ToString();
            TxbFamilyStatus.Text = employees.FamilyStatus.Name.ToString();
            TxbEducation.Text = employees.Education.EducationName.ToString();
       
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
