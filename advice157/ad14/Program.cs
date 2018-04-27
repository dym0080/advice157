using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ad14
{
    /// <summary>
    /// 浅拷贝
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Employee mike = new Employee() { IDCode = "NB123", Age = 30, Department = new Department() { Name = "Dept1" } };
            Employee rose = mike.Clone() as Employee;
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

    class Employee:ICloneable
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
    }
    
    class Department
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

}
