using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proftest.Model
{
    [Serializable]
    public class Question
    {
   
        public string Quest { get; set; }

     public   List<string> answers;

      public  string Right { get; set; }


    }
}
