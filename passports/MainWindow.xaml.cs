using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace passports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void CreateUser()
        {
            using(DataContext context = new DataContext())
            {
                var login = loginTextBox.Text;
                var fam = famTextBox.Text;
                var name = nameTextBox.Text;
                var otch = otchTextBox.Text;
                var pass = passInputTextBox.Password;
                var pass_2 = passInputAgainTextBox.Password;

                if(login != null && fam!=null && name!=null && otch!=null && pass!=null)
                {
                    context.Users.Add(new User() { Login = login, Fam = fam, Name = name,Otch = otch, Pass = pass});
                    context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                    Authorization authorization = new Authorization();
                    authorization.Show();
                    this.Close();
                }
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            CreateUser();
        }


    }
}