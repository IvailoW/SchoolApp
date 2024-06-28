using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Models;
using System;
using System.IO;
using System.Linq;

namespace SchoolApp
{
    class Program
    {
        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SchoolContext")));
        }
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            using (var context = serviceProvider.GetService<SchoolContext>())
            {
                // CRUD операции
                // Create
                Console.Write("Enter a name for a new Student: ");
                var firstName = Console.ReadLine();
                Console.Write("Enter the last name for the new Student: ");
                var lastName = Console.ReadLine();

                var student = new Student { FirstName = firstName, LastName = lastName, EnrollmentDate = DateTime.Now };
                context.Students.Add(student);
                context.SaveChanges();

                // Read
                Console.WriteLine("Querying for a student");
                var query = from b in context.Students
                            orderby b.FirstName
                            select b;

                foreach (var item in query)
                {
                    Console.WriteLine($"{item.StudentId}: {item.FirstName} {item.LastName}");
                }

                // Update
                Console.Write("Enter the ID of the student to update: ");
                int id = int.Parse(Console.ReadLine());
                var studentToUpdate = context.Students.Find(id);
                if (studentToUpdate != null)
                {
                    Console.Write("Enter the new name: ");
                    studentToUpdate.FirstName = Console.ReadLine();
                    context.SaveChanges();
                }

                // Delete
                Console.Write("Enter the ID of the student to delete: ");
                int deleteId = int.Parse(Console.ReadLine());
                var studentToDelete = context.Students.Find(deleteId);
                if (studentToDelete != null)
                {
                    context.Students.Remove(studentToDelete);
                    context.SaveChanges();
                }
            }
        }

        
    }
}
