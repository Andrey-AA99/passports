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
    /// Логика взаимодействия для WorkSpace.xaml
    /// </summary>
    public partial class WorkSpace : Window
    {
        List<ClientsPassp> clientsPassps = getClientsPassps();
        DateTime date2 = DateTime.Now;
        
        public WorkSpace()
        {
            InitializeComponent();
            famLable.Text = Authorization.currentUser.Fam;
            nameLable.Text = Authorization.currentUser.Name;
            listOfPassports.ItemsSource = getClientsPassps();
            for(int i = 0; i < clientsPassps.Count; i++)
            {
                if (Convert.ToDateTime(clientsPassps[i].DateOfEnd) <= date2.Date)
                {
                    MessageBox.Show($"У {clientsPassps[i].PassFam} {clientsPassps[i].PassName} заканчивается срок документа");

                }
                if (Convert.ToDateTime(clientsPassps[i].DateOfEnd) >= date2)
                {
                    
                }
            }
        }

        private void addDocument_Click(object sender, RoutedEventArgs e)
        {
            AddPassport addPassport = new AddPassport();
            addPassport.Show();
            this.Close();
        }

        private void btnListShow_Click(object sender, RoutedEventArgs e)
        {
            listOfPassports.ItemsSource = getClientsPassps();
        }

        public static List<ClientsPassp> getClientsPassps()
        {
            string connectionString = "Data Source = passProgramData.db";
            List<ClientsPassp> listOfPassp = new List<ClientsPassp>();
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM clientsPassps";
                    var reader = command.ExecuteReader();
                    if (reader.HasRows) 
                    {
                        while (reader.Read())
                        {
                            listOfPassp.Add(new ClientsPassp(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                            ));

                        }
                    }
                    else {
                        MessageBox.Show("Нет строк в таблице");
                    }
                    
                }
 
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listOfPassp;
        }

        

    }
}
