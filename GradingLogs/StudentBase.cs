using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingLogs
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public abstract class StudentBase : NameObject, IStudent
    {
        public StudentBase(string name) : base(name) { }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistic();
    }
}
