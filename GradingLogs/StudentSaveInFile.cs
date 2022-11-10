namespace GradingLogs
{
    public class StudentSaveInFile: StudentBase
    {
        private List<double> grades;
        public StudentSaveInFile(string? name) : base(name) => grades = new List<double>();

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
                using (var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    grades.Add(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
        }

        public override Statistics GetStatistic()
        {
            var stats = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    stats.Add(number);
                    line = reader.ReadLine();
                }

            }
            return stats;
        }
    }
}