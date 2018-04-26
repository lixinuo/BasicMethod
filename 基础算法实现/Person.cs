using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础算法实现
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}-{3}", ID, Name, Age, Gender == true ? "男" : "女");
        }
    }

    public class LitePerson
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class Children
    {
        public int ChildID { get; set; }
        public int ParentID { get; set; }
        public string ChildName { get; set; }
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", ChildID, ChildName, ParentID);
        }
    }
}
