using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=pharmacyDatabase;Trusted_Connection=True;";

        public static async Task dbSelectItemsAmount(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Список товаров и его количество: ");
                    Console.WriteLine("{0}\t{1}\t", reader.GetName(0), reader.GetName(1));
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}\t{reader[1]}");
                    }
                }
                else
                    Console.WriteLine("Данных нет");
            }
        }
        public static async Task dbSelectItems(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Данные из таблицы Items: ");
                    Console.WriteLine("{0}\t{1}\t", reader.GetName(0), reader.GetName(1));
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}\t{reader[1]}");
                    }
                }
                else
                    Console.WriteLine("Данных нет");
            }
        }

        public static async Task dbSelectAphotecary(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Данные из таблицы Aphotecary: ");
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
                    }
                }
                else
                    Console.WriteLine("Данных нет");
            }
        }

        public static async Task dbSelectStorage(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Данные из таблицы Storage: ");
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
                    }
                }
                else
                    Console.WriteLine("Данных нет");
            }
        }

        public static async Task dbSelectLot(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Данные из таблицы Lot: ");
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
                    }
                }
                else
                    Console.WriteLine("Данных нет");
            }
        }

        public static async Task dbExec(string query)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand();
                command.CommandText = query;
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
            }
            Console.WriteLine("Запрос " + query + " выполнен");
        }
        static async Task Main(string[] args)
        {
            /*//запросы на создание всех таблиц
            string createTableItems = "CREATE TABLE Items (ItemId INT PRIMARY KEY IDENTITY, Name NVARCHAR(100) NOT NULL)";
            string createTableAphotecary = "CREATE TABLE Aphotecary (AphtId INT PRIMARY KEY IDENTITY, Name NVARCHAR(100) NOT NULL," +
                " Adress NVARCHAR (100) NOT NULL, Phone VARCHAR (11) NULL)";
            string createTableStorage = "CREATE TABLE Storage (StorageId INT PRIMARY KEY IDENTITY, " +
                "AphtId int FOREIGN KEY REFERENCES Aphotecary(AphtId) ON DELETE CASCADE," +
                "Name NVARCHAR(100) NOT NULL)";
            string createTableLot = "CREATE TABLE Lot (LotId INT PRIMARY KEY IDENTITY, " +
                "ItemId int FOREIGN KEY REFERENCES Items(ItemId) ON DELETE CASCADE, " +
                "StorageId int FOREIGN KEY REFERENCES Storage(StorageId) ON DELETE CASCADE, " +
                "Amount INT)";

            //запросы на заполнение данных в таблицах
            string insertIntoItems = "INSERT INTO Items (Name) VALUES ('Item1'), ('Item2'), ('Item3')";
            string selectFromItems = "select * from Items";

            string insertIntoAphotecary = "INSERT INTO Aphotecary (Name, Adress, Phone) VALUES ('Apht1', 'Kirov', '89635534072')," +
                "('Apht2', 'Moscow', '89094470981'), ('Apht3', 'Vladimir', '89740016971')";
            string selectFromAphotecary = "select * from Aphotecary";

            string insertIntoStorage = "INSERT INTO Storage (Name, AphtId) VALUES ('Storage1', 1), ('Storage2', 2), ('Storage3', 3)";
            string selectFromStorage = "select * from Storage";

            string insertIntoLot = "INSERT INTO Lot (ItemId, StorageId, Amount) VALUES (1, 1, 1000), (2, 1, 20), (3, 2, 100)";
            string selectFromLot = "select * from Lot";*/

            Console.WriteLine("Выберите действие:\n1. Создать товар\n2. Удалить товар\n3. Создать аптеку\n4. Удалить аптеку\n" +
                "5. Создать склад\n6. Удалить склад\n7. Создать партию\n8. Удалить партию\n9. Вывести весь список товаров из выбранной аптеки");
            int k = Convert.ToInt32(Console.ReadLine());
            string query, itemName, aphtName, aphtAdress, aphtPhone, storageName, aphtId, storageId, itemId, amount, lotId;
            switch (k)
            {
                case 1:
                    Console.WriteLine("Введите наименование товара: ");
                    itemName = Console.ReadLine();
                    query = "INSERT INTO Items(Name) VALUES('" + itemName + "')";
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Товар успешно добавлен в таблицу Items");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при добавлении товара: " + ex.ToString());
                    }
                    break;

                case 2:
                    Console.WriteLine("Введите имя товара который хотите удалить:  ");
                    itemName = Console.ReadLine();
                    query = "DELETE FROM Items WHERE ItemId = (SELECT ItemId from Items where Name = "+ itemName+")";
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Товар успешно удален из таблицы Items");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при удалении товара: " + ex.ToString());
                    }
                    break;

                case 3:
                    Console.WriteLine("Введите название аптеки: ");
                    aphtName = Console.ReadLine();
                    Console.WriteLine("Введите адрес аптеки: ");
                    aphtAdress = Console.ReadLine();
                    Console.WriteLine("Введите телефон аптеки (можно оставить пустым): ");
                    aphtPhone = Console.ReadLine();
                    query = "INSERT INTO Aphotecary(Name, Adress, Phone) VALUES('" + aphtName + "', '" + aphtAdress +"', '"+ aphtPhone +"')";
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Аптека успешно добавлена в таблицу Aphotecary");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при добавлении аптеки: " + ex.ToString());
                    }
                    break;

                case 4:
                    Console.WriteLine("Введите имя аптеки которую хотите удалить:  ");
                    aphtName = Console.ReadLine();
                    query = "DELETE FROM Aphotecary WHERE AphtId = (SELECT AphtId from Aphotecary where Name = " + aphtName + ")";
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Аптека успешно удалена из таблицы Aphotecary");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при удалении аптеки: " + ex.ToString());
                    }
                    break;

                case 5:
                    Console.WriteLine("Введите наименование склада: ");
                    storageName = Console.ReadLine();
                    Console.WriteLine("Введите ID аптеки: ");
                    aphtId = Console.ReadLine();
                    query = "INSERT INTO Storage(Name, AphtId) VALUES('" + storageName + "', '"+ aphtId + "')";
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Склад успешно добавлен в таблицу Storage");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при добавлении склада: " + ex.ToString());
                    }
                    break;

                case 6:
                    Console.WriteLine("Введите имя склада который хотите удалить:  ");
                    storageName = Console.ReadLine();
                    query = "DELETE FROM Storage WHERE StorageId = (SELECT StorageId from Storage where Name = " + storageName + ")";
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Склад успешно удален из таблицы Storage");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при удалении склада: " + ex.ToString());
                    }
                    break;

                case 7:
                    Console.WriteLine("Введите ID товара: ");
                    itemId = Console.ReadLine();
                    Console.WriteLine("Введите ID склада: ");
                    storageId = Console.ReadLine();
                    Console.WriteLine("Введите количество в партии: ");
                    amount = Console.ReadLine();
                    query = "INSERT INTO Lot (ItemId, StorageId, Amount) VALUES ('"+ itemId+"', '"+ storageId+ "', '"+ amount +"')";
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Партия успешно добавлена в таблицу Lot");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при добавлении партии: " + ex.ToString());
                    }
                    break;

                case 8:
                    Console.WriteLine("Введите ID партии которую хотите удалить:  ");
                    lotId = Console.ReadLine();
                    query = "DELETE FROM Lot WHERE LotId = " + lotId;
                    try
                    {
                        await dbExec(query);
                        Console.WriteLine("Партия успешно удалена из таблицы Lot");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при удалении партии: " + ex.ToString());
                    }
                    break;

                case 9:
                    Console.WriteLine("Введите наименование аптеки:  ");
                    aphtName = Console.ReadLine();
                    query = "Select ItemId, Amount FROM Lot " +
                        "    WHERE StorageId = (SELECT StorageId from Storage " +
                        "    where AphtId = (Select AphtId from Aphotecary where Name = '" + aphtName + "'))";
                    try
                    {
                        await dbSelectItemsAmount(query);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при выводе списка товаров " + ex.ToString());
                    }
                    break;
            }
        }
    }
}
