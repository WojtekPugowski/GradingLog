namespace GradingLogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudent student;

            Console.WriteLine("Input student name:");
            var studentName = Console.ReadLine();
            Console.WriteLine("Choose letter 'F' to write to file or letter 'M' to save in memory");
            var choose = Console.ReadLine();
            choose = choose.ToUpper();
            var chooseLetter = char.Parse(choose);

            if (chooseLetter != null)
            {
                switch (chooseLetter)
                {
                    case 'F':
                        student = new StudentSaveInMemory(studentName);
                        EnterGrade(student);
                        break;
                    case 'M':
                        student = new StudentSaveInFile(studentName);
                        EnterGrade(student);
                        break;
                    default:
                        Console.WriteLine("Wrong choose");
                        break;

                }
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Input grade for {student.Name}");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    switch (input)
                    {
                        case "1+":
                            input = "1.5";
                            break;
                        case "2+":
                            input = "2.5";
                            break;
                        case "3+":
                            input = "3.5";
                            break;
                        case "4+":
                            input = "4.5";
                            break;
                        case "5+":
                            input = "5.5";
                            break;
                        case "2-":
                            input = "1.75";
                            break;
                        case "3-":
                            input = "2.75";
                            break;
                        case "4-":
                            input = "3.75";
                            break;
                        case "5-":
                            input = "4.75";
                            break;
                        case "6-":
                            input = "5.75";
                            break;
                    }

                    var grade = double.Parse(input);
                    if (grade > 0 && grade > 6)
                    {
                        student.AddGrade(grade);
                    }
                    else 
                    {
                        throw new ArgumentException("Input number is too small or too large");
                    }
                }

                catch(FormatException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}