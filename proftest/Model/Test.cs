using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace proftest.Model
{
    [Serializable]
    public class Test
    {
        public string Name { get; set; }

     


        public List<proftest.Model.Question> Questions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }

       public void Add(Question q)
        {
             Questions.Add(q);
        }
    }
}
