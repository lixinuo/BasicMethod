using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 基础算法实现.DelegateTest;

namespace 基础算法实现
{
    class Program
    {
        static void Main(string[] args)
        {
            //GreetingManage gm = new GreetingManage();
            //gm.onGreeting += EnglishGreeting;
            //gm.onGreeting += ChineseGreeting;
            //gm.ProcessGreeting("lixin"); 

            //BubbleSortDome();

            //Func<string, string> convertMethod = UppercaseString;
            //string name = "Lixin";
            //Console.WriteLine(convertMethod(name));
            
            WhereDemo();
            SelectDemo();
            OrderByDemo();
            JoinDemo();
            GroupByDemo();
            PagedListDemo();

            Console.ReadLine();
        }

        static void WhereDemo()
        {
            Console.WriteLine("-----------1:List------------");
            List<Person> personList = GetPersonList();
            List<Person> maleList = personList.Where(p => p.Gender == true && p.Age > 20).ToList();
            maleList.ForEach(m => Console.WriteLine(m.ToString()));
        }

        static void SelectDemo()
        {
            Console.WriteLine("-----------2:List------------");
            List<Person> personList = GetPersonList();
            var liteList = personList.Where(p => p.Gender == true).Select(p => new LitePerson() { Name = p.Name }).ToList();
            liteList.ForEach(p => Console.WriteLine(p.ToString()));
        }

        static void OrderByDemo()
        {
            Console.WriteLine("-----------3:List------------");
            List<Person> personList = GetPersonList();
            //单条件升序排序
            Console.WriteLine("Order by Age ascending:");
            List<Person> orderedList = personList.OrderBy(p => p.Age).ToList();
            orderedList.ForEach(p => Console.WriteLine(p.ToString()));
            //单条件降序排序
            Console.WriteLine("Order by Age descending:");
            orderedList = personList.OrderByDescending(p => p.Age).ToList();
            orderedList.ForEach(p => Console.WriteLine(p.ToString()));
            //多条件综合排序
            Console.WriteLine("Order by Age ascending and ID descending");
            orderedList = personList.OrderBy(p => p.Age).ThenByDescending(p => p.ID).ToList();
            orderedList.ForEach(p => Console.WriteLine(p.ToString()));
        }

        static void JoinDemo()
        {
            Console.WriteLine("-----------4:List------------");
            List<Person> personList = GetPersonList();
            List<Children> childrenList = GetChildrenList();
            //连接查询
            var joinedList = personList.Join(childrenList, p => p.ID, c => c.ParentID, (p, c) => new
            {
                ParentID = p.ID,
                ChildID = c.ChildID,
                ParentName = p.Name,
                ChildrenName = c.ChildName
            }).ToList();
            joinedList.ForEach(p => Console.WriteLine(p.ToString()));
        }

        static void GroupByDemo()
        {
            Console.WriteLine("-----------5:List------------");
            List<Person> personList = GetPersonList();
            IEnumerable<IGrouping<bool, Person>> groups = personList.GroupBy(p => p.Gender);
            IList<IGrouping<bool, Person>> groupList = groups.ToList();

            foreach (IGrouping<bool, Person> group in groupList)
            {
                Console.WriteLine("Group:{0}", group.Key ? "男" : "女");
                foreach (Person p in group)
                {
                    Console.WriteLine(p.ToString());
                }
            }

            Console.WriteLine("-----------6:List------------");
            var annoyGroups = personList.GroupBy(p => p.Name).ToList();
            foreach (var group in annoyGroups)
            {
                Console.WriteLine("Group:{0}", group.Key);
                foreach (Person p in group)
                {
                    Console.WriteLine(p.ToString());
                }
            } 
        }

        static void PagedListDemo()
        {
            Console.WriteLine("-----------7:List------------");
            //第一页
            Console.WriteLine("First Page:");
            var firstPageData = GetPagedListByIndex(1, 5);
            firstPageData.ForEach(p => Console.WriteLine(p.ToString()));
            //第二页
            Console.WriteLine("Second Page:");
            var secondPageData = GetPagedListByIndex(2, 5);
            secondPageData.ForEach(p => Console.WriteLine(p.ToString()));
            //第三页
            Console.WriteLine("Third Page:");
            var thirdPageData = GetPagedListByIndex(3, 5);
            thirdPageData.ForEach(p => Console.WriteLine(p.ToString()));
            //第四页
            Console.WriteLine("Fourth Page:");
            var FourthPageData = GetPagedListByIndex(4, 5);
            FourthPageData.ForEach(p => Console.WriteLine(p.ToString()));

        }

        public static List<Person> GetPagedListByIndex(int pageIndex, int pageSize)
        {
            List<Person> dataList = GetMorePersonList();
            return dataList.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        static List<Person> GetPersonList()
        {
                List<Person> personList = new List<Person>()
            {
                new Person(){ID=1,Name="Edison Chou",Age=25,Gender=true},
                new Person(){ID=2,Name="Edwin Chan",Age=20,Gender=true},
                new Person(){ID=3,Name="Jackie Chan",Age=40,Gender=true},
                new Person(){ID=4,Name="Andy Lau",Age=55,Gender=true},
                new Person(){ID=5,Name="Kelly Chan",Age=45,Gender=false}
            };
                return personList;
        }

        static List<Children> GetChildrenList()
        {
            List<Children> childrenList = new List<Children>()
            {
                new Children(){ChildID=1,ParentID=1,ChildName="Lucas"},
                new Children(){ChildID=2,ParentID=1,ChildName="Louise"},
                new Children(){ChildID=3,ParentID=3,ChildName="Edward"},
                new Children(){ChildID=4,ParentID=4,ChildName="Kevin"},
                new Children(){ChildID=5,ParentID=5,ChildName="Mike"}
            };
            return childrenList;
        }

        static List<Person> GetMorePersonList()
        {
            List<Person> personList = new List<Person>()
            {
                new Person(){ID=1,Name="爱迪生",Age=100,Gender=true},
                new Person(){ID=2,Name="瓦特",Age=120,Gender=true},
                new Person(){ID=3,Name="牛顿",Age =150,Gender=true},
                new Person(){ID=4,Name="图灵",Age=145,Gender=true},
                new Person(){ID=5,Name="香农",Age=120,Gender=true},
                new Person(){ID=6,Name="居里夫人",Age=115,Gender=false},
                new Person(){ID=6,Name="居里夫人2",Age=115,Gender=false},
                new Person(){ID=7,Name="居里夫人3",Age=115,Gender=false},
                new Person(){ID=8,Name="居里夫人4",Age=115,Gender=false},
                new Person(){ID=9,Name="居里夫人5",Age=115,Gender=false},
                new Person(){ID=10,Name="居里夫人6",Age=115,Gender=false},
                new Person(){ID=11,Name="居里夫人7",Age=115,Gender=false},
                new Person(){ID=12,Name="居里夫人8",Age=115,Gender=false},
                new Person(){ID=13,Name="居里夫人9",Age=115,Gender=false},
                new Person(){ID=14,Name="居里夫人10",Age=115,Gender=false},
                new Person(){ID=15,Name="居里夫人11",Age=115,Gender=false},
                new Person(){ID=16,Name="居里夫人12",Age=115,Gender=false},
                new Person(){ID=17,Name="居里夫人13",Age=115,Gender=false},
                new Person(){ID=18,Name="居里夫人14",Age=115,Gender=false}
            };
            return personList;
        }

        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }

        public static void BubbleSortDome()
        {
            int maxSize = 10000;
            int[] array = new int[maxSize];
            Random random = new Random();
            for (int i = 0; i < maxSize; i++)
            {
                array[i] = random.Next(1, 11);
            }
            Console.WriteLine("Before Bubble Sort:");
            BasicClass.PrintArray(array);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            BasicClass.QuickSort(array, 0, maxSize - 1);
            watch.Stop();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("After Bubble Sort");
            BasicClass.PrintArray(array);
            Console.WriteLine("Total Elapsed Milliseconds:{0}ms", watch.ElapsedMilliseconds);
            Console.ReadLine();

        }
    }
}
