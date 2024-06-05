using Microsoft.Data.Sqlite;
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
    /// Логика взаимодействия для AddPassport.xaml
    /// </summary>
    public partial class AddPassport : Window
    {
        public AddPassport()
        {
            InitializeComponent();
            famLable.Text = Authorization.currentUser.Fam;
            nameLable.Text = Authorization.currentUser.Name;
        }

        private void addDocument_Click(object sender, RoutedEventArgs e)
        {
            AddPassport addPassport = new AddPassport();
            addPassport.Show();
            this.Close();
        }

        private void btnListShow_Click(object sender, RoutedEventArgs e)
        {
            WorkSpace workSpace = new WorkSpace();
            workSpace.Show();
            this.Close();
        }

        private void btnSavePassport_Click(object sender, RoutedEventArgs e)
        {
            string fam = regFamPas.Text;
            string name = regNamePas.Text;
            string dateStart = regStartPas.Text;
            string dateEnd = regEndPas.Text;
            int number = Convert.ToInt32(regNumPas.Text);
            int seria = Convert.ToInt32(regSeriaPas.Text);

            string sqlAddQuery = $"INSERT INTO ClientsPassps (passNumber,passSeria,passFam,passName,dateOfStart,dateOfEnd) VALUES ('{number}','{seria}','{fam}','{name}','{dateStart}','{dateEnd}')";
            string connectionString = "Data Source = passProgramData.db";
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlAddQuery,connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Документ добавлен");
                    
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
