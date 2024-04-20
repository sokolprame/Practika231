using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static Practika.Model.Model.CarModel;
using static Practika.Model.Model.Client_Model;
using static Practika.Model.Model.Detail_Model;
using static Practika.Model.Model.Employer_Model;
using static Practika.Model.Model.Order_Model;
using static Practika.Model.Model.Ysluge_Model;

namespace Practika.Model.Model
{
    internal class DataManager
    {
        private string connectionString = @"Server=DESKTOP-RTM981H\SQLEXPRESS;Database=AutoZona;Integrated Security=True;";
        public ObservableCollection<OrderModel> GetOrders()
        {
            ObservableCollection<OrderModel> orders = new ObservableCollection<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Orders";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orders.Add(new OrderModel
                        {
                            id_ordes = (int)reader["id_ordes"],
                            ID_YSLUGE = (int)reader["ID_YSLUGE"],
                            id_clients = (int)reader["id_clients"],
                            id_car = (int)reader["id_car"],
                            nomer_car = (int)reader["nomer_car"],
                            date = (DateTime)reader["date"],
                            sum = (decimal)reader["sum"],
                            status = reader["status"].ToString()
                        });
                    }
                }
            }
            return orders;
        }
        private int GenerateUniqueId()
        {
            // Генерируем новый GUID и преобразуем его в строку
            string guid = Guid.NewGuid().ToString();

            // Получаем 8 символов из строки GUID для использования как уникальный идентификатор
            int uniqueId = Math.Abs(guid.GetHashCode());

            return uniqueId;
        }

        public void AddOrder(OrderModel order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Orders (id_ordes, ID_YSLUGE, id_sotrudnika ,id_clients, id_car, nomer_car, date, sum, status) VALUES (@id_ordes, @ID_YSLUGE, @id_clients, @id_car, @nomer_car, @date, @sum, @status)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_ordes", order.id_ordes);
                    command.Parameters.AddWithValue("@ID_YSLUGE", order.ID_YSLUGE);
                    command.Parameters.AddWithValue("@id_sotrudnika", order.id_sotrudnika);
                    command.Parameters.AddWithValue("@id_clients", order.id_clients);
                    command.Parameters.AddWithValue("@id_car", order.id_car);
                    command.Parameters.AddWithValue("@nomer_car", order.nomer_car);
                    command.Parameters.AddWithValue("@date", order.date);
                    command.Parameters.AddWithValue("@sum", order.sum);
                    command.Parameters.AddWithValue("@status", order.status);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditOrder(OrderModel order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Orders SET ID_YSLUGE = @ID_YSLUGE, id_clients = @id_clients, id_car = @id_car, nomer_car = @nomer_car, date = @date, sum = @sum, status = @status WHERE id_ordes = @id_ordes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_YSLUGE", order.ID_YSLUGE);
                    command.Parameters.AddWithValue("@id_clients", order.id_clients);
                    command.Parameters.AddWithValue("@id_car", order.id_car);
                    command.Parameters.AddWithValue("@nomer_car", order.nomer_car);
                    command.Parameters.AddWithValue("@date", order.date);
                    command.Parameters.AddWithValue("@sum", order.sum);
                    command.Parameters.AddWithValue("@status", order.status);
                    command.Parameters.AddWithValue("@id_ordes", order.id_ordes);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Orders WHERE id_ordes = @id_ordes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_ordes", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Clients methods...

        public ObservableCollection<ClientModel> GetClients()
        {
            ObservableCollection<ClientModel> clients = new ObservableCollection<ClientModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Clients";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clients.Add(new ClientModel
                        {
                            id_clients = (int)reader["id_clients"],
                            Id_car = (int)reader["Id_car"],
                            nomer_car = reader["nomer_car"].ToString(),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Data = (DateTime)reader["Data"],
                            phone = reader["phone"].ToString()
                        });
                    }
                }
            }
            return clients;
        }

        public void AddClient(ClientModel client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Clients (Id_car, nomer_car, Name, Surname, Data, phone) VALUES (@Id_car, @nomer_car, @Name, @Surname, @Data, @phone)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_car", client.Id_car);
                    command.Parameters.AddWithValue("@nomer_car", client.nomer_car);
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@Surname", client.Surname);
                    command.Parameters.AddWithValue("@Data", client.Data);
                    command.Parameters.AddWithValue("@phone", client.phone);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Cars methods...

        public ObservableCollection<CarModel> GetCars()
        {
            ObservableCollection<CarModel> cars = new ObservableCollection<CarModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cars.Add(new CarModel
                        {
                            Id_car = (int)reader["Id_car"],
                            nomer_car = (int)reader["nomer_car"],
                            mark = reader["mark"].ToString(),
                            year = (int)reader["year"],
                            body = reader["body"].ToString(),
                            type = reader["type"].ToString()
                        });
                    }
                }
            }
            return cars;
        }

        public void AddCar(CarModel car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Cars (nomer_car, mark, year, body, type) VALUES (@nomer_car, @mark, @year, @body, @type)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nomer_car", car.nomer_car);
                    command.Parameters.AddWithValue("@mark", car.mark);
                    command.Parameters.AddWithValue("@year", car.year);
                    command.Parameters.AddWithValue("@body", car.body);
                    command.Parameters.AddWithValue("@type", car.type);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Details methods...

        public ObservableCollection<DetailModel> GetDetails()
        {
            ObservableCollection<DetailModel> details = new ObservableCollection<DetailModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Details";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        details.Add(new DetailModel
                        {
                            Id = (int)reader["Id"],
                            type = reader["type"].ToString()
                        });
                    }
                }
            }
            return details;
        }

        public void AddDetail(DetailModel detail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Details (type) VALUES (@type)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@type", detail.type);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ... [предыдущий код]

        public ObservableCollection<EmployerModel> GetEmployers()
        {
            ObservableCollection<EmployerModel> employers = new ObservableCollection<EmployerModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployerModel employer = new EmployerModel
                        {
                            Id_sotrudnika = (int)reader["Id_sotrudnika"],
                            name = reader["name"].ToString(),
                            surname = reader["surname"].ToString(),
                            role = reader["role"].ToString(),
                            wage = (decimal)reader["wage"]
                        };
                        employers.Add(employer);
                    }
                }
            }
            return employers;
        }

        // Методы для работы с таблицей Ysluge
        public ObservableCollection<YslugeModel> GetYsluge()
        {
            ObservableCollection<YslugeModel> ysluges = new ObservableCollection<YslugeModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Ysluge";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        YslugeModel ysluge = new YslugeModel
                        {
                            ID_YSLUGE = (int)reader["ID_YSLUGE"],
                            name = reader["name"].ToString(),
                            prise = (decimal)reader["prise"],
                            Depriction = reader["Depriction"].ToString()
                        };
                        ysluges.Add(ysluge);
                    }
                }
            }
            return ysluges;
        }

        // ... [предыдущий код]

        public void EditClient(ClientModel client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Clients SET Id_car = @Id_car, nomer_car = @nomer_car, Name = @Name, Surname = @Surname, Data = @Data, phone = @phone WHERE id_clients = @id_clients";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_car", client.Id_car);
                    command.Parameters.AddWithValue("@nomer_car", client.nomer_car);
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@Surname", client.Surname);
                    command.Parameters.AddWithValue("@Data", client.Data);
                    command.Parameters.AddWithValue("@phone", client.phone);
                    command.Parameters.AddWithValue("@id_clients", client.id_clients);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Clients WHERE id_clients = @id_clients";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id_clients", clientId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditCar(CarModel car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Cars SET nomer_car = @nomer_car, mark = @mark, year = @year, body = @body, type = @type WHERE Id_car = @Id_car";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nomer_car", car.nomer_car);
                    command.Parameters.AddWithValue("@mark", car.mark);
                    command.Parameters.AddWithValue("@year", car.year);
                    command.Parameters.AddWithValue("@body", car.body);
                    command.Parameters.AddWithValue("@type", car.type);
                    command.Parameters.AddWithValue("@Id_car", car.Id_car);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCar(int carId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Cars WHERE Id_car = @Id_car";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_car", carId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditDetail(DetailModel detail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Details SET type = @type WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@type", detail.type);
                    command.Parameters.AddWithValue("@Id", detail.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDetail(int detailId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Details WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", detailId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditEmployer(EmployerModel employer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Employer SET name = @name, surname = @surname, role = @role, wage = @wage WHERE Id_sotrudnika = @Id_sotrudnika";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", employer.name);
                    command.Parameters.AddWithValue("@surname", employer.surname);
                    command.Parameters.AddWithValue("@role", employer.role);
                    command.Parameters.AddWithValue("@wage", employer.wage);
                    command.Parameters.AddWithValue("@Id_sotrudnika", employer.Id_sotrudnika);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployer(int employerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employer WHERE Id_sotrudnika = @Id_sotrudnika";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_sotrudnika", employerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditYsluge(YslugeModel ysluge)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Ysluge SET name = @name, prise = @prise, Depriction = @Depriction WHERE ID_YSLUGE = @ID_YSLUGE";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", ysluge.name);
                    command.Parameters.AddWithValue("@prise", ysluge.prise);
                    command.Parameters.AddWithValue("@Depriction", ysluge.Depriction);
                    command.Parameters.AddWithValue("@ID_YSLUGE", ysluge.ID_YSLUGE);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteYsluge(int yslugeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Ysluge WHERE ID_YSLUGE = @ID_YSLUGE";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_YSLUGE", yslugeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // ... [предыдущий код]

    }
}
