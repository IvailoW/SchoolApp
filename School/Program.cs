using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Models;
using System;
using System.Configuration;
using System.Linq;


namespace SchoolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Initialize the database context
            using (var context = serviceProvider.GetService<SchoolContext>())
            {
                //context.Update(context);
                
                Console.WriteLine("School Management System");

                // Perform CRUD operations
                //PerformCrudOperations(context);
                while (true)
                {
                    Console.WriteLine("Какви операции искате да извършите? ");
                    Console.WriteLine("Добавяне (създаване) на нов ученик (1).\n Премахване (изтриване) на ученик (2). " +
                        "\n Обновяване (заместване) на ученик (3).\n Извеждане на списък с всички класове и ученици (4).");
                    int n = int.Parse(Console.ReadLine());
                    if (n == 1)
                    { 
                        PerformCreateOperation(context);
                    }
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SchoolContext"].ConnectionString;
            services.AddDbContext<SchoolContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }

        static void PerformCreateOperation(SchoolContext context)
        {
            Console.Write("Enter a name for a new Student: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter the last name for the new Student: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter the class for the new Student (1, 2, 3, 4, 5, 6, or 7): ");
            int classId;
            while (!int.TryParse(Console.ReadLine(), out classId) || classId < 1 || classId > 7)
            {
                Console.Write("Invalid class. Please enter a class between 1 and 7: ");
            }
            Console.Write("Enter the birth year for the new Student: ");
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                Console.Write("Invalid year. Please enter a valid birth year: ");
            }

            Console.Write("Enter the birth month for the new Student: ");
            int birthMonth;
            while (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12)
            {
                Console.Write("Invalid month. Please enter a valid birth month (1-12): ");
            }

            Console.Write("Enter the birth day for the new Student: ");
            int birthDay;
            while (!int.TryParse(Console.ReadLine(), out birthDay) || birthDay < 1 || birthDay > DateTime.DaysInMonth(birthYear, birthMonth))
            {
                Console.Write("Invalid day. Please enter a valid birth day: ");
            }

            var dateOfBirth = new DateTime(birthYear, birthMonth, birthDay);

            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                ClassID = classId,
                DateOfBirth = dateOfBirth
            };

            context.Students.Add(student);
            context.SaveChanges();
            

            Console.WriteLine($"Student {firstName} {lastName} added successfully.");
        }
        /*// Read

        Console.WriteLine("Querying for a student");
            var students = context.Students.OrderBy(s => s.StudentId).ToList();

            foreach (var item in students)
            {
                Console.WriteLine($"{item.StudentId}: {item.FirstName} {item.LastName}");
            }

           // Update
            Console.Write("Enter the ID of the student to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var studentToUpdate = context.Students.Find(id);
                if (studentToUpdate != null)
                {
                    Console.Write("Enter the new name: ");
                    studentToUpdate.FirstName = Console.ReadLine();
                    context.SaveChanges();
                }
            }

            // Delete
            Console.Write("Enter the ID of the student to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                var studentToDelete = context.Students.Find(deleteId);
                if (studentToDelete != null)
                {
                    context.Students.Remove(studentToDelete);
                    context.SaveChanges();
                }
            } */

    }
}
