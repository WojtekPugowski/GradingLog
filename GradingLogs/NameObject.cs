using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingLogs
{
    public class NameObject
    {

        //private string name;
        //public string Name 
        //{
        //    get => name;

        //    set 
        //    {
        //        if (!(value.Count() <= 0 && value.Count() >= 20))
        //        {
        //            name = value;
        //        }
        //    } 
        //}

        public string Name { get; set; }
        public NameObject(string name)
        {
            this.Name = name;
        }
    }
}
