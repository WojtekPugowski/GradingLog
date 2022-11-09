namespace GradingLogs
{
    public class StudentSaveInFile: StudentBase
    {
        private string? studentName;

        public StudentSaveInFile(string? studentName) : base
        {
            this.studentName = studentName;
        }
    }
}