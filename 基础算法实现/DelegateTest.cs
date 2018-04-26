using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础算法实现
{
    public class DelegateTest
    {
        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好，" + name);
        }

        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning," + name);
        }

        public delegate void GreetingDelegate(string name);

        public class GreetingManage
        {
            public event GreetingDelegate onGreeting;
            public void ProcessGreeting(string name)
            {
                if (onGreeting != null)
                {
                    onGreeting(name);
                }
            }
        }
    }
}
