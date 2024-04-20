using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practika.Model.Model.Client_Model;

namespace Practika.ViewModel
{
    internal class ClientsViewModel
    {

        public class ClientViewModel : INotifyPropertyChanged
        {
            private string connectionString = @"Server=DESKTOP-RTM981H\SQLEXPRESS;Database=AutoZona;Integrated Security=True;";

            public event PropertyChangedEventHandler PropertyChanged;

            // Конструктор, свойства и другие методы

            public void SaveClient(ClientModel client)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Clients (Id_car, Name, Surname, Data, phone) VALUES (@Id_car, @Name, @Surname, @Data, @phone)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_car", client.Id_car);
                        command.Parameters.AddWithValue("@Name", client.Name);
                        command.Parameters.AddWithValue("@Surname", client.Surname);
                        command.Parameters.AddWithValue("@Data", client.Data);
                        command.Parameters.AddWithValue("@phone", client.phone);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
