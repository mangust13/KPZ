﻿using Lab_03.Data;
using Lab_03.Models;
using System;
using System.Linq;

namespace Lab_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Використовуємо контекст з папки Data
            using (var context = new SportComplexContext())
            {
                // Логіка меню
                while (true)
                {
                    Console.WriteLine("\nChoose an operation:");
                    Console.WriteLine("1. Add a client");
                    Console.WriteLine("2. Update a client");
                    Console.WriteLine("3. Delete a client");
                    Console.WriteLine("4. Show all clients");
                    Console.WriteLine("5. Exit");
                    Console.Write("Your choice: ");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddClient(context);
                            break;
                        case "2":
                            UpdateClient(context);
                            break;
                        case "3":
                            DeleteClient(context);
                            break;
                        case "4":
                            ShowAllClients(context);
                            break;
                        case "5":
                            Console.WriteLine("Program terminated.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }
        }

        static void AddClient(SportComplexContext context)
        {
            // Зчитуємо ім'я клієнта
            Console.Write("Enter the full name of the client: ");
            var fullName = Console.ReadLine();

            // Зчитуємо стать клієнта
            Console.Write("Enter the gender of the client (1 for male, 0 for female, leave empty if not specified): ");
            var genderInput = Console.ReadLine();
            bool? gender = string.IsNullOrEmpty(genderInput) ? (bool?)null : genderInput == "1";

            // Зчитуємо телефонний номер клієнта
            Console.Write("Enter the phone number of the client: ");
            var phoneNumber = Console.ReadLine();

            // Створюємо новий об'єкт клієнта
            var newClient = new Client
            {
                client_full_name = fullName,
                client_gender = gender,
                client_phone_number = phoneNumber
            };

            // Додаємо нового клієнта в базу даних
            context.Clients.Add(newClient);

            // Зберігаємо зміни в базі даних
            context.SaveChanges();

            Console.WriteLine("Client successfully added.");
        }

        static void UpdateClient(SportComplexContext context)
        {
            Console.Write("Enter the ID of the client to update: ");
            if (int.TryParse(Console.ReadLine(), out int clientId))
            {
                // Знаходимо клієнта за ID
                var client = context.Clients.FirstOrDefault(c => c.client_id == clientId);

                if (client != null)
                {
                    // Зчитуємо нові дані для оновлення
                    Console.Write("Enter the new full name of the client (leave empty to keep current): ");
                    var newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                        client.client_full_name = newName;

                    Console.Write("Enter the new gender of the client (1 for male, 0 for female, leave empty to keep current): ");
                    var genderInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(genderInput))
                        client.client_gender = genderInput == "1";

                    Console.Write("Enter the new phone number of the client (leave empty to keep current): ");
                    var newPhoneNumber = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newPhoneNumber))
                        client.client_phone_number = newPhoneNumber;

                    // Зберігаємо зміни
                    context.SaveChanges();
                    Console.WriteLine("Client data successfully updated.");
                }
                else
                {
                    Console.WriteLine("Client with the given ID was not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID entered.");
            }
        }

        static void DeleteClient(SportComplexContext context)
        {
            Console.Write("Enter the ID of the client to delete: ");
            if (int.TryParse(Console.ReadLine(), out int clientId))
            {
                // Знаходимо клієнта за ID
                var client = context.Clients.FirstOrDefault(c => c.client_id == clientId);

                if (client != null)
                {
                    // Видаляємо клієнта
                    context.Clients.Remove(client);
                    context.SaveChanges();
                    Console.WriteLine("Client successfully deleted.");
                }
                else
                {
                    Console.WriteLine("Client with the given ID was not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID entered.");
            }
        }


        static void ShowAllClients(SportComplexContext context)
        {
            // Отримуємо список всіх клієнтів
            var clients = context.Clients.ToList();

            if (clients.Any())
            {
                Console.WriteLine("List of clients:");
                foreach (var client in clients)
                {
                    string gender = client.client_gender.HasValue
                        ? (client.client_gender.Value ? "Male" : "Female")
                        : "Not specified";

                    Console.WriteLine($"ID: {client.client_id}, Name: {client.client_full_name}, Gender: {gender}, Phone: {client.client_phone_number}");
                }
            }
            else
            {
                Console.WriteLine("No clients found.");
            }
        }

    }
}