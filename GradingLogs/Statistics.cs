namespace GradingLogs
{
    public class Statistics
    {
        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0D;
            Count = 0;
        }

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public char Letter
        {
            get
            {

                switch (Average)
                {
                    case var d when d >= 5:
                        return 'A';
                    case var d when d >= 4:
                        return 'B';
                    case var d when d >= 3:
                        return 'C';
                    case var d when d >= 2:
                        return 'D';
                    case var d when d > 1:
                        return 'E';
                    default:
                        return 'F';
                }
            }
        }

        public void Add(double number)
        {
            Sum += number;
            Count++;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }
}