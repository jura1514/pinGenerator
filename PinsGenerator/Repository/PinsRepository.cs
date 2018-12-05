using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinsGenerator.Repository
{
    public class PinsRepository : BaseRepository
    {
        public void createTable()
        {
            using (var databaseConnection = new SQLiteConnection(this.DatabaseFilePath))
            {
                databaseConnection.Open();
                SQLiteCommand createTableCmd = databaseConnection.CreateCommand();
                createTableCmd.CommandText = "CREATE TABLE 'pins' (id varchar(4) primary key);";

                createTableCmd.ExecuteNonQuery();

                databaseConnection.Close();
                createTableCmd.Dispose();
            }
        }

        public void dropTable()
        {
            using (var databaseConnection = new SQLiteConnection(this.DatabaseFilePath))
            {
                databaseConnection.Open();
                SQLiteCommand createTableCmd = databaseConnection.CreateCommand();
                createTableCmd.CommandText = "DROP TABLE 'pins';";

                createTableCmd.ExecuteNonQuery();

                databaseConnection.Close();
                createTableCmd.Dispose();
            }
        }

        public bool checkIfTableExists(string tableName)
        {
            using (var databaseConnection = new SQLiteConnection(this.DatabaseFilePath))
            {
                databaseConnection.Open();
                SQLiteCommand findTableCmd = databaseConnection.CreateCommand();
                findTableCmd.CommandText = string.Format("SELECT name FROM sqlite_master WHERE type='table' AND name='{0}'", tableName);

                SQLiteDataReader dataReader = findTableCmd.ExecuteReader();

                bool foundTable = false;

                while (dataReader.Read())
                {
                    foundTable = String.Equals(tableName, dataReader[0].ToString());
                }


                databaseConnection.Close();
                findTableCmd.Dispose();
                dataReader.Dispose();

                return foundTable;
            }
        }

        public ReadOnlyCollection<string> GetAllPins()
        {
            using (var databaseConnection = new SQLiteConnection(this.DatabaseFilePath))
            {
                databaseConnection.Open();
                SQLiteCommand getAllPinsCmd = databaseConnection.CreateCommand();
                getAllPinsCmd.CommandText = "SELECT * FROM 'pins'";

                SQLiteDataReader dataReader = getAllPinsCmd.ExecuteReader();

                List<string> allPins = new List<string>();

                while (dataReader.Read())
                {
                    string pinId = dataReader.GetString(0);
                    allPins.Add(pinId);
                }


                databaseConnection.Close();
                getAllPinsCmd.Dispose();
                dataReader.Dispose();

                return new ReadOnlyCollection<string>(allPins);
            }
        }

        public bool findPin(string newPin)
        {
            using (var databaseConnection = new SQLiteConnection(this.DatabaseFilePath))
            {
                databaseConnection.Open();
                SQLiteCommand findPinCmd = databaseConnection.CreateCommand();
                findPinCmd.CommandText = string.Format("SELECT * FROM 'pins' WHERE id='{0}'", newPin);

                SQLiteDataReader dataReader = findPinCmd.ExecuteReader();

                bool foundPin = false;

                while (dataReader.Read())
                {
                    string pinId = dataReader.GetString(0);
                    if (!string.IsNullOrEmpty(pinId))
                    {
                        foundPin = true;
                    }
                }

                databaseConnection.Close();
                findPinCmd.Dispose();
                dataReader.Dispose();

                return foundPin;
            }
        }

        public void insertPin(string newPin)
        {
            using (var databaseConnection = new SQLiteConnection(this.DatabaseFilePath))
            {
                databaseConnection.Open();
                SQLiteCommand inserPinCmd = databaseConnection.CreateCommand();
                inserPinCmd.CommandText = string.Format("INSERT INTO 'pins' (id) VALUES ('{0}');", newPin);

                inserPinCmd.ExecuteNonQuery();

                databaseConnection.Close();
                inserPinCmd.Dispose();
            }
        }
    }
}
