namespace GradingLogs
{
    public class StudentSaveInFile : StudentBase
    {
        private List<double> grades;
        public string pathToFile;
        public StudentSaveInFile(string? name) : base(name)
        {
            grades = new List<double>();
            pathToFile = $"../../../{Name}.txt";
        }
        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText(pathToFile))
            {
                writer.WriteLine(grade);
                grades.Add(grade);
                if (GradeAdded != null) GradeAdded(this, new EventArgs());
            }
        }
        public override Statistics GetStatistic()
        {
            var stats = new Statistics();
            using (var reader = File.OpenText(pathToFile))
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