using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace passports
{
    public class DataContext: DbContext
    {
        string connectionString = "Data Source = passProgramData.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<ClientsPassp> ClientsPassps { get; set; }

        public static void CreateTableClientsPassps()
        {
            string connectionString = "Data Source = passProgramData.db";
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "Create table clientsPassps(passNumber INTEGER NOT NULL PRIMARY KEY UNIQUE," +
                    "passSeria INTEGER NOT NULL, passFam TEXT NOT NULL, passName TEXT NOT NULL,dateOfStart TEXT NOT NULL, dateOfEnd TEXT NOT NULL)";
                command.ExecuteNonQuery();
            }
        }

    }

    
}
