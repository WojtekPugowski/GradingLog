using GradingLogs;
using System;

namespace GradingLogs.Test
{
    public class StudentTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var stud = new StudentSaveInMemory("Wojtek");
            stud.AddGrade(0.5);
            stud.AddGrade(5.5);

            //act
            var result = stud.GetStatistic();

            //assert
            Assert.Equal(0.5, result.Low);
            Assert.Equal(5.5, result.High);
            Assert.Equal(3.0, result.Average);

        }
    }
}