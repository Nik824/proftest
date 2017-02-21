using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proftest.Model
{
    [Serializable]
    public  class Admin
    {
        public int Id{get;set;}
        public string Name { get; set; }

        public List<Test> Tests { get; set; }
      
        public Admin()
        {
            Tests = new List<Test>();
        }

        // IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return Tests.GetEnumerator();
        //}
    }
}
