using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ad22_2
{
    class Program
    {
        static List<Person> list = new List<Person>()
        {
            new Person() {Name="Rose",Age=17 },
            new Person() {Name="Mike",Age=19 },
            new Person() {Name="Lily",Age=20 }
        };

        static AutoResetEvent autoSet = new AutoResetEvent(false);
        static object sycObj = new object();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                // 确保等待t2开始之后才运行下面的代码
                autoSet.WaitOne();
                lock (sycObj)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine("t1:" + item.Name);
                        Thread.Sleep(5000);
                    }
                }
                
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                // 通知t1可以执行代码
                autoSet.Set();
                // 沉睡1秒后是为了确保删除操作在t1的迭代过程中
                Thread.Sleep(5000);
                lock (sycObj)
                {
                    list.RemoveAt(2);
                    Console.WriteLine("删除成功！");
                }
                
            });
            t2.Start();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
