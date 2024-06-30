using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Models;
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
                while (true)
                {
                    Console.WriteLine("Какви операции искате да извършите? ");
                    Console.WriteLine("Добавяне (създаване) на нов ученик (1).\n Премахване (изтриване) на ученик (2). " +
                        "\n Обновяване (заместване) на ученик (3).\n Извеждане на списък с всички класове и ученици (4).");
                    string n = Console.ReadLine();
                    if (n == "1")
                    {
                        PerformCreateOperation(context);
                    }
                    else if (n == "2")
                    {
                        PerformDeleteOperation(context);
                    }
                    else if (n == "3")
                    {
                        PerformUpdateOperation(context);
                    }
                    else if (n == "4")
                    {
                        PerformReadOperation(context);
                    }
                    else if (n == "5")
                    {
                        PerformReadTeachersOperation(context);
                    }
                    else if (n == "6")
                    {
                        PerformAddNewTeacher(context);
                    }
                    else if (n == "7")
                    {
                        PerformDeleteTeacher(context);
                    }
                    else if (n == "exit")
                    {
                        return;
                    }
                    else Console.WriteLine("Невалидна команда!");
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
            Console.Write("Въведете името на новия ученик: ");
            var firstName = Console.ReadLine();
            Console.Write("Въведете фамилията на новия ученик: ");
            var lastName = Console.ReadLine();
            Console.Write("Въведете класа на ученика (1, 2, 3, 4, 5, 6, or 7): ");
            int classId;
            while (!int.TryParse(Console.ReadLine(), out classId) || classId < 1 || classId > 7)
            {
                Console.Write("Невалиден клас. Въведете клас от 1.-7.: ");
            }
            Console.Write("Въведете годината на раждане на ученика: ");
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                Console.Write("Невалидна година. Въведете правилната година: ");
            }

            Console.Write("Въведете месец на раждане на ученика: ");
            int birthMonth;
            while (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12)
            {
                Console.Write("Невалиден месец. Въведете правилният месец (1-12): ");
            }

            Console.Write("Въведете деня на раждане на ученика: ");
            int birthDay;
            while (!int.TryParse(Console.ReadLine(), out birthDay) || birthDay < 1 || birthDay > DateTime.DaysInMonth(birthYear, birthMonth))
            {
                Console.Write("Невалиден ден. Въведете правилния ден (1-31): ");
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
            

            Console.WriteLine($"Ученикът: {firstName} {lastName} от {classId}A беше добавен успешно.");
        }
        static void PerformDeleteOperation(SchoolContext context)
        {
            while (true)
            {
                Console.Write("Въведете първото име на ученика за изтриване: ");
                var firstName = Console.ReadLine();
                Console.Write("Въведете фамилното име на ученика за изтриване: ");
                var lastName = Console.ReadLine();

                var studentsToDelete = context.Students
                                              .Where(s => s.FirstName == firstName && s.LastName == lastName)
                                              .ToList();
            
                if (studentsToDelete.Count == 1)
                {
                    var studentToDelete = studentsToDelete.First();
                    context.Students.Remove(studentToDelete);
                    context.SaveChanges();
                    Console.WriteLine($"Ученикът {firstName} {lastName} беше изтрит успешно."); break;
                }
                else if (studentsToDelete.Count > 1)
                {
                    Console.WriteLine($"Намерени са няколко ученици с името {firstName} {lastName}. Моля, въведете ID-то на ученика за изтриване:");
                    foreach (var student in studentsToDelete)
                    {
                        Console.WriteLine($"ID: {student.StudentId}, Име: {student.FirstName} {student.LastName}, Клас: {student.ClassID}, Дата на раждане: {student.DateOfBirth.ToShortDateString()}");
                    }
                    Console.Write("Въведете ID-то на ученика: ");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        var studentToDelete = studentsToDelete.SingleOrDefault(s => s.StudentId == studentId);
                        if (studentToDelete != null)
                        {
                            context.Students.Remove(studentToDelete);
                            context.SaveChanges();
                            Console.WriteLine($"Ученикът с ID {studentId} беше изтрит успешно."); break;
                        }
                        else
                        {
                            Console.WriteLine("Невалидно ID. Изтриването не беше извършено.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невалидно ID. Изтриването не беше извършено.");
                    }
                }
                else
                {
                    Console.WriteLine("Не е намерен ученик с това име.");
                }
            }
        }
        static void PerformUpdateOperation(SchoolContext context)
        {
            while (true)
            {
                Console.Write("Въведете първото име на ученика за обновяване: ");
                var firstName = Console.ReadLine();
                Console.Write("Въведете фамилното име на ученика за обновяване: ");
                var lastName = Console.ReadLine();

                var studentsToUpdate = context.Students
                                              .Where(s => s.FirstName == firstName && s.LastName == lastName)
                                              .ToList();

                if (studentsToUpdate.Count == 1)
                {
                    var studentToUpdate = studentsToUpdate.First();
                    UpdateStudentInformation(context, studentToUpdate); break;
                }
                else if (studentsToUpdate.Count > 1)
                {
                    Console.WriteLine($"Намерени са няколко ученици с името {firstName} {lastName}. Моля, въведете ID-то на ученика за обновяване:");
                    foreach (var student in studentsToUpdate)
                    {
                        Console.WriteLine($"ID: {student.StudentId}, Име: {student.FirstName} {student.LastName}, Клас: {student.ClassID}, Дата на раждане: {student.DateOfBirth.ToShortDateString()}");
                    }

                    Console.Write("Въведете ID-то на ученика: ");
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        var studentToUpdate = studentsToUpdate.SingleOrDefault(s => s.StudentId == studentId);
                        if (studentToUpdate != null)
                        {
                            UpdateStudentInformation(context, studentToUpdate); break;
                        }
                        else
                        {
                            Console.WriteLine("Невалидно ID. Обновяването не беше извършено.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невалидно ID. Обновяването не беше извършено.");
                    }
                }
                else
                {
                    Console.WriteLine("Не е намерен ученик с това име.");
                }
            }
        }

        static void UpdateStudentInformation(SchoolContext context, Student student)
        {
            Console.Write("Въведете новото първо име: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Въведете новата фамилия: ");
            student.LastName = Console.ReadLine();
            Console.Write("Въведете новия клас на ученика (1, 2, 3, 4, 5, 6, or 7): ");
            int classId;
            while (!int.TryParse(Console.ReadLine(), out classId) || classId < 1 || classId > 7)
            {
                Console.Write("Невалиден клас. Въведете клас от 1 до 7: ");
            }
            student.ClassID = classId;

            Console.Write("Въведете новата година на раждане на ученика: ");
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                Console.Write("Невалидна година. Въведете правилната година: ");
            }

            Console.Write("Въведете новия месец на раждане на ученика: ");
            int birthMonth;
            while (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12)
            {
                Console.Write("Невалиден месец. Въведете правилния месец (1-12): ");
            }

            Console.Write("Въведете новия ден на раждане на ученика: ");
            int birthDay;
            while (!int.TryParse(Console.ReadLine(), out birthDay) || birthDay < 1 || birthDay > DateTime.DaysInMonth(birthYear, birthMonth))
            {
                Console.Write("Невалиден ден. Въведете правилния ден (1-31): ");
            }

            student.DateOfBirth = new DateTime(birthYear, birthMonth, birthDay);

            context.SaveChanges();
            Console.WriteLine($"Информацията за ученика {student.FirstName} {student.LastName} беше обновена успешно.");
        }
        static void PerformReadOperation(SchoolContext context)
        {
            Console.WriteLine("Извеждане на списък с всички ученици");
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("1. Покажи всички ученици");
            Console.WriteLine("2. Покажи ученици от определен клас");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
            {
                Console.WriteLine("Невалидна опция. Моля, въведете 1 или 2:");
            }

            List<Student> students;

            if (option == 1)
            {
                students = context.Students.OrderBy(s => s.StudentId).ToList();
            }
            else
            {
                Console.Write("Въведете класа (1-7): ");
                int classId;
                while (!int.TryParse(Console.ReadLine(), out classId) || classId < 1 || classId > 7)
                {
                    Console.Write("Невалиден клас. Моля, въведете клас от 1 до 7: ");
                }

                students = context.Students.Where(s => s.ClassID == classId).OrderBy(s => s.StudentId).ToList();
            }

            // Define column widths
            int idWidth = 10;
            int firstNameWidth = 15;
            int lastNameWidth = 15;
            int classIdWidth = 10;
            int dateOfBirthWidth = 15;

            // Print table header
            PrintLineStudents(idWidth, firstNameWidth, lastNameWidth, classIdWidth, dateOfBirthWidth);
            PrintRowStudents("ID", "Първо име", "Фамилия", "Клас", "Дата на раждане", idWidth, firstNameWidth, lastNameWidth, classIdWidth, dateOfBirthWidth);
            PrintLineStudents(idWidth, firstNameWidth, lastNameWidth, classIdWidth, dateOfBirthWidth);

            // Print students in table format
            foreach (var student in students)
            {
                PrintRowStudents(student.StudentId.ToString(), student.FirstName, student.LastName, student.ClassID.ToString(), student.DateOfBirth.ToShortDateString(), idWidth, firstNameWidth, lastNameWidth, classIdWidth, dateOfBirthWidth);
            }
            PrintLineStudents(idWidth, firstNameWidth, lastNameWidth, classIdWidth, dateOfBirthWidth);
        }
        static void PerformReadTeachersOperation(SchoolContext context)
        {
            Console.WriteLine("Извеждане на списък с всички учители");

            var teachers = context.Teachers.OrderBy(t => t.TeacherId).ToList();

            // Define column widths
            int idWidth = 10;
            int firstNameWidth = 15;
            int lastNameWidth = 15;
            int subjectWidth = 15;

            // Print table header
            PrintLineTeachers(idWidth, firstNameWidth, lastNameWidth, subjectWidth);
            PrintRowTeachers("ID", "Първо име", "Фамилия", "Предмет", idWidth, firstNameWidth, lastNameWidth, subjectWidth);
            PrintLineTeachers(idWidth, firstNameWidth, lastNameWidth, subjectWidth);

            // Print teachers in table format
            foreach (var teacher in teachers)
            {
                PrintRowTeachers(teacher.TeacherId.ToString(), teacher.FirstName, teacher.LastName, teacher.Subject.Replace("Физическо Възпитание и Спорт", "ФВС").Replace("Български Език и Лтература", "БЕЛ").Replace("Информационни Технологии", "ИТ"), idWidth, firstNameWidth, lastNameWidth, subjectWidth);
            }
            PrintLineTeachers(idWidth, firstNameWidth, lastNameWidth, subjectWidth);
        }
        static void PerformAddNewTeacher(SchoolContext context)
        {
            Console.WriteLine("Добавяне на нов учител");

            // Въвеждане на информация за новия учител
            Console.Write("Въведете име на учителя: ");
            string firstName = Console.ReadLine();

            Console.Write("Въведете фамилия на учителя: ");
            string lastName = Console.ReadLine();

            Console.Write("Въведете предмет на учителя: ");
            string subject = Console.ReadLine();
            // Създаване на нов обект Teacher и добавяне в базата данни
            Teacher newTeacher = new Teacher
            {
                FirstName = firstName,
                LastName = lastName,
                Subject = subject,
            };

            context.Teachers.Add(newTeacher);
            context.SaveChanges();

            Console.WriteLine("Новият учител е добавен успешно.");
        }
        static void PerformDeleteTeacher(SchoolContext context)
        {
            Console.WriteLine("Изтриване на учител по име и фамилия");

            Console.Write("Въведете първо име на учителя за изтриване: ");
            string firstNameToDelete = Console.ReadLine();

            Console.Write("Въведете фамилия на учителя за изтриване: ");
            string lastNameToDelete = Console.ReadLine();

            var teacherToDelete = context.Teachers
                .FirstOrDefault(t => t.FirstName == firstNameToDelete && t.LastName == lastNameToDelete);

            if (teacherToDelete == null)
            {
                Console.WriteLine($"Учител с име '{firstNameToDelete} {lastNameToDelete}' не е намерен.");
            }
            else
            {
                // Related records will be deleted automatically due to cascade delete
                context.Teachers.Remove(teacherToDelete);
                context.SaveChanges();
                Console.WriteLine($"Учител с име '{firstNameToDelete} {lastNameToDelete}' е изтрит успешно.");
            }
        }


        static void PrintLineTeachers(int idWidth, int firstNameWidth, int lastNameWidth, int subjectWidth)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', idWidth + firstNameWidth + lastNameWidth + subjectWidth + 11));
            Console.ResetColor();
        }

        static void PrintRowTeachers(string id, string firstName, string lastName, string subject, int idWidth, int firstNameWidth, int lastNameWidth, int subjectWidth)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(id.PadRight(idWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(firstName.PadRight(firstNameWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(lastName.PadRight(lastNameWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(subject.PadRight(subjectWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" |");
            Console.ResetColor();
        }

        static void PrintLineStudents(int idWidth, int firstNameWidth, int lastNameWidth, int classIdWidth, int dateOfBirthWidth)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', idWidth + firstNameWidth + lastNameWidth + classIdWidth + dateOfBirthWidth + 17));
            Console.ResetColor();
        }

        static void PrintRowStudents(string id, string firstName, string lastName, string classId, string dateOfBirth, int idWidth, int firstNameWidth, int lastNameWidth, int classIdWidth, int dateOfBirthWidth)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(id.PadRight(idWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(firstName.PadRight(firstNameWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(lastName.PadRight(lastNameWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(classId.PadRight(classIdWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" | ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(dateOfBirth.PadRight(dateOfBirthWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" |");
            Console.ResetColor();
        }

    }
}
