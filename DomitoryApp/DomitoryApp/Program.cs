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
                Console.WriteLine("2. Найти комнату по студенту");
                Console.WriteLine("3. Найти студента по имени");
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
            }
            else
            {
                Console.WriteLine("Общежитие с таким названием не найдено.");
            }
        }

        static void FindStudentByName(NpgsqlConnection conn2)
        {
            Console.WriteLine("Введите имя студента:");
            string std_name = Console.ReadLine();

            using var cmd = new NpgsqlCommand("SELECT room FROM students WHERE std_name = @std_name", conn2);
            cmd.Parameters.AddWithValue("std_name", std_name);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string room = reader.GetString(0);
                Console.WriteLine($"Студент {std_name} живет в комнате номер {room}.");
            }
            else
            {
                Console.WriteLine($"Студент с именем {std_name} не найден.");
            }
        }
    }
}