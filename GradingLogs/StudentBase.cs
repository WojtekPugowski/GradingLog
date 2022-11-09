using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingLogs
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class StudentBase : NameObject, IStudent
    {

    }
}
