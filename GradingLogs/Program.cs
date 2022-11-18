using System.Globalization;

namespace GradingLogs
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStudent? student = null;
            Console.WriteLine("Input student name:");
            var studentName = Console.ReadLine();
            if (studentName?.Length <=0)
            {
                Console.WriteLine("You have to input student's name");
                return;
            }
            Console.WriteLine("Choose letter:");
            Console.WriteLine("F - write to file");
            Console.WriteLine("M - to save in memory");
            var choose = Console.ReadLine();
            var chooseLetter = choose.ToUpper();

            if (chooseLetter != null)
            {
                switch (chooseLetter)
                {
                    case "M":
                        student = new StudentSaveInMemory(studentName);
                        break;
                    case "F":
                        student = new StudentSaveInFile(studentName);
                        break;
                    default:
                        Console.WriteLine("Wrong choose");
                        break;
                }
            }
            EnterGrade(student);
            Statistics? stats = student.GetStatistic();
            Console.WriteLine();
            Console.WriteLine($"Statistics for student {student.Name}:");
            Console.WriteLine($"High grade: {stats.High}");
            Console.WriteLine($"Low grade: {stats.Low}");
            Console.WriteLine($"Average: {stats.Average:N2}");
            Console.WriteLine($"Letter grade: {stats.Letter}");
        }
        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Input grade for {student.Name} or choose letter 'Q' to see stats.");
                var input = Console.ReadLine();
                input = input.ToUpper();

                if (input == "Q")
                {
                    break;
                }
                try
                {
                    input = PartialGradesInput(input);
                    var provider = CultureInfo.CreateSpecificCulture("pl-PL");
                    double grade = double.Parse(input, provider);
                    if (grade > 0D && grade <= 6D)
                    {
                        student.AddGrade(grade);
                    }
                    else 
                    {
                        throw new ArgumentException("Input number is too small or too large. Choose number from 1 to 6.");
                    }
                }
                catch (FormatException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static string PartialGradesInput(string input)
        {
            switch (input)
            {
                case "1+" or "+1":
                    input = "1,5";
                    break;
                case "2+" or "+2":
                    input = "2,5";
                    break;
                case "3+" or "+3":
                    input = "3,5";
                    break;
                case "4+" or "+4":
                    input = "4,5";
                    break;
                case "5+" or "+5":
                    input = "5,5";
                    break;
                case "2-" or "-2":
                    input = "1,75";
                    break;
                case "3-" or "-3":
                    input = "2,75";
                    break;
                case "4-" or "-4":
                    input = "3,75";
                    break;
                case "5-" or "-5":
                    input = "4,75";
                    break;
                case "6-" or "-6":
                    input = "5,75";
                    break;
            }

            return input;
        }
    }
}