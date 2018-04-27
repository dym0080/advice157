using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ad14_2
{
    /// <summary>
    /// 深、浅拷贝
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Employee mike = new Employee() { IDCode = "NB123", Age = 30, Department = new Department() { Name = "Dept1" } };
            Employee rose = mike.DeepClone() as Employee;
            Console.WriteLine(rose.IDCode);
            Console.WriteLine(rose.Age);
            Console.WriteLine(rose.Department);
            Console.WriteLine("开始改变mike的值");
            mike.IDCode = "NB456";
            mike.Age = 60;
            mike.Department.Name = "Dept2";
            Console.WriteLine(rose.IDCode);
            Console.WriteLine(rose.Age);
            Console.WriteLine(rose.Department);
            Console.Read();
        }
    }

    [Serializable]
    class Employee : ICloneable
    {
        public string IDCode { get; set; }
        public int Age { get; set; }

        public Department Department { get; set; }

        /// <summary>
        /// ICloneable 成员实现
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns></returns>
        public Employee DeepClone()
        {
            using(Stream objectStream=new MemoryStream())
            {
                IFormatter fromatter = new BinaryFormatter();
                fromatter.Serialize(objectStream, this);
                objectStream.Seek(0, SeekOrigin.Begin);
                return fromatter.Deserialize(objectStream) as Employee;
            }
        }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public Employee ShallowClone()
        {
            return Clone() as Employee;
        }
    }

    [Serializable]
    class Department
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
