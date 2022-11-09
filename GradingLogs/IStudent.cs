namespace GradingLogs
{
    public interface IStudent
    {
        string Name { get; }
        void AddGrade(double grade);
        Statistics GetStatistic();
        event GradeAddedDelegate GradeAdded;
    }
}