namespace GradingLogs
{
    public class StudentSaveInMemory : StudentBase, IStudent
    {
        private List<double> grades;
        public StudentSaveInMemory(string? name) : base(name) => grades = new List<double>();

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
        }

        public override Statistics GetStatistic()
        {
            var stats = new Statistics();
            for (int i = 0; i < grades.Count; i++)
            {
                stats.Add(grades[i]);
            }
            return stats;
        }
    }
}