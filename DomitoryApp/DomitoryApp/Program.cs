using System;
using Npgsql;

namespace DormitoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Username=elizavetazhitnik;Password=;Database=Campus";
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            conn.Open();

            string connectionString2 = "Host=localhost;Username=elizavetazhitnik;Password=;Database=Students";
            NpgsqlConnection conn2 = new NpgsqlConnection(connectionString);
            conn2.Open();

            Console.WriteLine("Добро пожаловать в систему общежитий!");

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Выбрать общежитие");
                Console.WriteLine("2. Найти комнату, в которой живет студент");
                Console.WriteLine("3. Найти студента по комнате");
                Console.WriteLine("4. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("выбор 1");
                        SelectDormitory(conn);
                        break;
                    case "2":
                        Console.WriteLine("выбор 2");
                        FindStudentByName(conn2);
                        break;
                    case "3":
                        Console.WriteLine("выбор 3");
                        FindStudentsByRoom(conn2);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Пожалуйста, выберите существующее действие.");
                        break;
                }
            }
        }

        static void SelectDormitory(NpgsqlConnection conn)
        {
            Console.WriteLine("Введите название общежития:");
            string domitory_number = Console.ReadLine();

            using var cmd = new NpgsqlCommand("SELECT * FROM Campus WHERE domitory_number = @domitory_number", conn);
            cmd.Parameters.AddWithValue("domitory_number", domitory_number);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"Общежитие {domitory_number} выбрано.");
                Console.WriteLine("//потом сюда добавится расселенка по комнатам");
            }
            else
            {
                Console.WriteLine("Общежитие с таким названием не найдено.");
            }
        }



        static void FindStudentByName(NpgsqlConnection conn2)
        {
            Console.WriteLine("Введите название общежития:");
            string dormitory_number = Console.ReadLine();

            using var cmd = new NpgsqlCommand("SELECT * FROM students WHERE dormitory_number = @dormitory_number", conn2);
            cmd.Parameters.AddWithValue("dormitory_number", dormitory_number);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"Общежитие {dormitory_number} выбрано.");
            }
            else
            {
                Console.WriteLine("Общежитие с таким названием не найдено.");
                return;
            }
            reader.Close();

            Console.WriteLine("Введите имя студента:");
            string std_name = Console.ReadLine();

            using var cmd2 = new NpgsqlCommand("SELECT room FROM students WHERE std_name = @std_name AND dormitory_number = @dormitory_number", conn2);
            cmd2.Parameters.AddWithValue("std_name", std_name);
            cmd2.Parameters.AddWithValue("dormitory_number", dormitory_number);
            using var reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                string room = reader2.GetString(0);
                Console.WriteLine($"Студент {std_name} живет в комнате номер {room}.");
            }
            else
            {
                Console.WriteLine($"Студент с именем {std_name} не найден.");
            }
        }


        static void FindStudentsByRoom(NpgsqlConnection conn2)
        {
            Console.WriteLine("Введите название общежития:");
            string dormitory_number = Console.ReadLine();

            using var cmd = new NpgsqlCommand("SELECT * FROM students WHERE dormitory_number = @dormitory_number", conn2);
            cmd.Parameters.AddWithValue("dormitory_number", dormitory_number);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine($"Общежитие {dormitory_number} выбрано.");
            }
            else
            {
                Console.WriteLine("Общежитие с таким названием не найдено.");
                return;
            }
            reader.Close();

            Console.WriteLine("Введите номер комнаты:");
            string room = Console.ReadLine();

            using var cmd2 = new NpgsqlCommand("SELECT std_name FROM students WHERE room = @room AND dormitory_number = @dormitory_number", conn2);
            cmd2.Parameters.AddWithValue("room", room);
            cmd2.Parameters.AddWithValue("dormitory_number", dormitory_number);
            using var reader2 = cmd2.ExecuteReader();

            bool foundAny = false;
            while (reader2.Read())
            {
                string std_name = reader2.GetString(0);
                Console.WriteLine($"В комнате {room} общежития №{dormitory_number} живет {std_name}.");
                foundAny = true;
            }
            if (!foundAny)
            {
                Console.WriteLine($"Студенты в комнате {room} общежития №{dormitory_number} не найдены.");
            }
        }
    }
}