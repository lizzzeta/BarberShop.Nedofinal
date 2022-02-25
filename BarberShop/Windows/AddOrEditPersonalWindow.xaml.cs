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
using System.Windows.Shapes;
using BarberShop.EF;


namespace BarberShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditPersonalWindow.xaml
    /// </summary>
    public partial class AddOrEditPersonalWindow : Window
    {
        private Employee editEmployee = null;

        public AddOrEditPersonalWindow()
        {
            InitializeComponent();

            cbSpec.ItemsSource = ClassEntities.context.Specialization.ToList();
            cbSpec.DisplayMemberPath = "NameSpec";
        }

        public AddOrEditPersonalWindow(Employee employee)
        {
            InitializeComponent();

            cbSpec.ItemsSource = ClassEntities.context.Specialization.ToList();
            cbSpec.DisplayMemberPath = "NameSpec";

            editEmployee = employee;
        }

        private void AddPersonal()
        {
            if (editEmployee == null) 
            { 
                Employee employee = new Employee();
                employee.LName = tbLName.Text.Trim();
                employee.FName = tbFName.Text.Trim();
                employee.Email = tbEmail.Text.Trim();
                employee.Phone = tbPhone.Text.Trim();
                employee.SpecID = (cbSpec.SelectedItem as Specialization).ID;
                employee.Login = tbLogin.Text.Trim();
                employee.Password = tbPassword.Text.Trim();

                ClassEntities.context.Employee.Add(employee);
                ClassEntities.context.SaveChanges();
            }
            else
            {
                var entitiy = ClassEntities.context.Employee.Find(editEmployee.ID);


                entitiy.LName = tbLName.Text.Trim();
                entitiy.FName = tbFName.Text.Trim();
                entitiy.Email = tbEmail.Text.Trim();
                entitiy.Phone = tbPhone.Text.Trim();
                entitiy.SpecID = (cbSpec.SelectedItem as Specialization).ID;
                entitiy.Login = tbLogin.Text.Trim();
                entitiy.Password = tbPassword.Text.Trim();

                ClassEntities.context.SaveChanges();
            }
        }


        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPersonal();

            this.Close();
        }
    }
}
