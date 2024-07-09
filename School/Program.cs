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

            using (var context = serviceProvider.GetService<SchoolContext>())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                      School Management System"); Console.WriteLine(); Console.ForegroundColor= ConsoleColor.Cyan;
                while (true)
                {
                    ShowStartMessage();
                    Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Въведете операция: "); Console.ForegroundColor = ConsoleColor.Red;
                    string n = Console.ReadLine(); Console.ResetColor();


                    if (n == "1")       PerformCreateOperation(context);
                    else if (n == "2")  PerformDeleteOperation(context);
                    else if (n == "3")  PerformUpdateOperation(context);
                    else if (n == "4")  PerformReadOperation(context);
                    else if (n == "5")  PerformAddNewTeacher(context);
                    else if (n == "6")  PerformDeleteTeacher(context);
                    else if (n == "7")  PerformReadTeachersOperation(context);
                    else if (n == "exit")   return;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("Невалидна команда!");
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

        static void ShowStartMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Какви операции искате да извършите?"); Console.WriteLine();
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("+-------------------------------+-------------------------------+");

            // Заглавна редица
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("     ОПЕРАЦИИ ЗА УЧЕНИЦИ       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("      ОПЕРАЦИИ ЗА УЧИТЕЛИ      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");

            Console.WriteLine("+-------------------------------+-------------------------------+");
            Thread.Sleep(500);
            // Редици с опции
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 1. Добавяне на нов ученик     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 5. Добавяне на нов учител     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");
            Thread.Sleep(500);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 2. Премахване на ученик       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 6. Премахване на учител       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");
            Thread.Sleep(500);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 3. Обновяване на ученик       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 7. Списък с всички учители    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");
            Thread.Sleep(500);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 4. Списък с всички ученици    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ----------------------------- ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");

            Console.WriteLine("+-------------------------------+-------------------------------+");
            Thread.Sleep(500);
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("                      Изход: напишете 'exit'.                  ");
            Console.ResetColor();
            Console.WriteLine("|");
            Console.WriteLine("+-------------------------------+-------------------------------+");
        }

        static void PerformCreateOperation(SchoolContext context)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете името на новия ученик: "); Console.ForegroundColor = ConsoleColor.Red;
            var firstName = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете фамилията на новия ученик: "); Console.ForegroundColor = ConsoleColor.Red;
            var lastName = Console.ReadLine();Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете класа на ученика (1, 2, 3, 4, 5, 6, or 7): "); Console.ForegroundColor = ConsoleColor.Red;
            int classId;
            while (!int.TryParse(Console.ReadLine(), out classId) || classId < 1 || classId > 7)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалиден клас. Въведете клас от 1.-7.: "); Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете годината на раждане на ученика: "); Console.ForegroundColor = ConsoleColor.Red;
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалидна година. Въведете правилната година: "); Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете месец на раждане на ученика: "); Console.ForegroundColor = ConsoleColor.Red;
            int birthMonth;
            while (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалиден месец. Въведете правилният месец (1-12): "); Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете деня на раждане на ученика: "); Console.ForegroundColor = ConsoleColor.Red;
            int birthDay;
            while (!int.TryParse(Console.ReadLine(), out birthDay) || birthDay < 1 || birthDay > DateTime.DaysInMonth(birthYear, birthMonth))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалиден ден. Въведете правилния ден (1-31): "); Console.ForegroundColor = ConsoleColor.Red;
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ученикът: {firstName} {lastName} от {classId}A беше добавен успешно."); Console.ResetColor(); Console.WriteLine();
        }
        static void PerformDeleteOperation(SchoolContext context)
        {
            Console.WriteLine();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Въведете първото име на ученика за изтриване: "); Console.ForegroundColor = ConsoleColor.Red;
                var firstName = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Въведете фамилното име на ученика за изтриване: "); Console.ForegroundColor = ConsoleColor.Red;
                var lastName = Console.ReadLine();

                var studentsToDelete = context.Students
                                              .Where(s => s.FirstName == firstName && s.LastName == lastName)
                                              .ToList();
            
                if (studentsToDelete.Count == 1)
                {
                    var studentToDelete = studentsToDelete.First();
                    context.Students.Remove(studentToDelete);
                    context.SaveChanges(); Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Ученикът {firstName} {lastName} беше изтрит успешно."); break;
                }
                else if (studentsToDelete.Count > 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Намерени са няколко ученици с името {firstName} {lastName}. Моля, въведете ID-то на ученика за изтриване:");
                    foreach (var student in studentsToDelete)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"ID: {student.StudentId}, Име: {student.FirstName} {student.LastName}, Клас: {student.ClassID}A, Дата на раждане: {student.DateOfBirth.ToShortDateString()}");
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Въведете ID-то на ученика: "); Console.ForegroundColor = ConsoleColor.Red;
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        var studentToDelete = studentsToDelete.SingleOrDefault(s => s.StudentId == studentId);
                        if (studentToDelete != null)
                        {
                            context.Students.Remove(studentToDelete);
                            context.SaveChanges();Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Ученикът с ID {studentId} беше изтрит успешно."); break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Невалидно ID. Изтриването не беше извършено.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Невалидно ID. Изтриването не беше извършено.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Не е намерен ученик с това име.");
                }
            }
            Console.ResetColor();Console.WriteLine();
        }
        static void PerformUpdateOperation(SchoolContext context)
        {
            Console.WriteLine();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Въведете първото име на ученика за обновяване: "); Console.ForegroundColor = ConsoleColor.Red;
                var firstName = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Въведете фамилното име на ученика за обновяване: "); Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Намерени са няколко ученици с името {firstName} {lastName}. Моля, въведете ID-то на ученика за обновяване:");
                    foreach (var student in studentsToUpdate)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"ID: {student.StudentId}, Име: {student.FirstName} {student.LastName}, Клас: {student.ClassID}, Дата на раждане: {student.DateOfBirth.ToShortDateString()}");
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Въведете ID-то на ученика: "); Console.ForegroundColor = ConsoleColor.Red;
                    if (int.TryParse(Console.ReadLine(), out int studentId))
                    {
                        var studentToUpdate = studentsToUpdate.SingleOrDefault(s => s.StudentId == studentId);
                        if (studentToUpdate != null)
                        {
                            UpdateStudentInformation(context, studentToUpdate); break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Невалидно ID. Обновяването не беше извършено.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Невалидно ID. Обновяването не беше извършено.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Не е намерен ученик с това име.");
                }
            }
            Console.WriteLine();
        }

        static void UpdateStudentInformation(SchoolContext context, Student student)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете новото първо име: "); Console.ForegroundColor = ConsoleColor.Red;
            student.FirstName = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете новата фамилия: "); Console.ForegroundColor = ConsoleColor.Red;
            student.LastName = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете новия клас на ученика (1, 2, 3, 4, 5, 6, or 7): "); Console.ForegroundColor = ConsoleColor.Red;
            int classId;
            while (!int.TryParse(Console.ReadLine(), out classId) || classId < 1 || classId > 7)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалиден клас. Въведете клас от 1 до 7: "); Console.ForegroundColor = ConsoleColor.Red;
            }
            student.ClassID = classId;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете новата година на раждане на ученика: "); Console.ForegroundColor = ConsoleColor.Red;
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалидна година. Въведете правилната година: "); Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете новия месец на раждане на ученика: ");
            int birthMonth;
            while (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалиден месец. Въведете правилния месец (1-12): "); Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете новия ден на раждане на ученика: "); Console.ForegroundColor = ConsoleColor.Red;
            int birthDay;
            while (!int.TryParse(Console.ReadLine(), out birthDay) || birthDay < 1 || birthDay > DateTime.DaysInMonth(birthYear, birthMonth))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Невалиден ден. Въведете правилния ден (1-31): "); Console.ForegroundColor = ConsoleColor.Red;
            }

            student.DateOfBirth = new DateTime(birthYear, birthMonth, birthDay);

            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Информацията за ученика {student.FirstName} {student.LastName} беше обновена успешно.");
            Console.WriteLine();
        }
        static void PerformReadOperation(SchoolContext context)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Извеждане на списък с всички ученици");
            Console.WriteLine("Изберете опция:"); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Покажи всички ученици");
            Console.WriteLine("2. Покажи ученици от определен клас"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете опция: "); Console.ForegroundColor = ConsoleColor.Red;
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Невалидна опция. Моля, въведете 1 или 2:"); Console.ForegroundColor = ConsoleColor.Red;
            }

            List<Student> students;

            if (option == 1)
            {
                students = context.Students.OrderBy(s => s.StudentId).ToList();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Въведете класа (1-7): "); Console.ForegroundColor = ConsoleColor.Red;
                int classId;
                while (!int.TryParse(Console.ReadLine(), out classId) || classId < 1 || classId > 7)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Невалиден клас. Моля, въведете клас от 1 до 7: "); Console.ForegroundColor = ConsoleColor.Red;
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

            foreach (var student in students)
            {
                PrintRowStudents(student.StudentId.ToString(), student.FirstName, student.LastName, student.ClassID.ToString(), student.DateOfBirth.ToShortDateString(), idWidth, firstNameWidth, lastNameWidth, classIdWidth, dateOfBirthWidth);
            }
            PrintLineStudents(idWidth, firstNameWidth, lastNameWidth, classIdWidth, dateOfBirthWidth);
            Console.WriteLine();
        }
        static void PerformReadTeachersOperation(SchoolContext context)
        {
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Cyan;
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

            foreach (var teacher in teachers)
            {
                PrintRowTeachers(teacher.TeacherId.ToString(), teacher.FirstName, teacher.LastName, teacher.Subject.Replace("Физическо Възпитание и Спорт", "ФВС").Replace("Български Език и Лтература", "БЕЛ").Replace("Информационни Технологии", "ИТ"), idWidth, firstNameWidth, lastNameWidth, subjectWidth);
            }
            PrintLineTeachers(idWidth, firstNameWidth, lastNameWidth, subjectWidth); Console.WriteLine();
        }
        static void PerformAddNewTeacher(SchoolContext context)
        {
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Добавяне на нов учител");

            Console.Write("Въведете име на учителя: "); Console.ForegroundColor = ConsoleColor.Red;
            string firstName = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете фамилия на учителя: "); Console.ForegroundColor = ConsoleColor.Red;
            string lastName = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете предмет на учителя: "); Console.ForegroundColor = ConsoleColor.Red;
            string subject = Console.ReadLine();
            Teacher newTeacher = new Teacher
            {
                FirstName = firstName,
                LastName = lastName,
                Subject = subject,
            };

            context.Teachers.Add(newTeacher);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Новият учител е добавен успешно.");
        }
        static void PerformDeleteTeacher(SchoolContext context)
        {
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Изтриване на учител по име и фамилия");
            Console.Write("Въведете първо име на учителя за изтриване: "); Console.ForegroundColor = ConsoleColor.Red;
            string firstNameToDelete = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Въведете фамилия на учителя за изтриване: "); Console.ForegroundColor = ConsoleColor.Red;
            string lastNameToDelete = Console.ReadLine();
            var teacherToDelete = context.Teachers
                .FirstOrDefault(t => t.FirstName == firstNameToDelete && t.LastName == lastNameToDelete);
            if (teacherToDelete == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Учител с име '{firstNameToDelete} {lastNameToDelete}' не е намерен.");
            }
            else
            {
                context.Teachers.Remove(teacherToDelete);
                context.SaveChanges(); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Учител с име '{firstNameToDelete} {lastNameToDelete}' е изтрит успешно.");
            }
            Console.WriteLine();
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
