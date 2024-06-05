using Microsoft.EntityFrameworkCore;
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

namespace passports
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public List<User> DatabaseUsers { get; private set; }
        public static User currentUser;

        public Authorization()
        {
            InitializeComponent();
        }



        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var pass = passInputTextBox.Password;

            using(DataContext context = new DataContext())
            {
                
                bool foundUser = context.Users.Any(user => user.Login == login && user.Pass == pass);


                if (foundUser) 
                {
                    currentUser = context.Users.Find(login);
                    WorkSpace workSpace = new WorkSpace();
                    workSpace.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }

        private void btnToReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
