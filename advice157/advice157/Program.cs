using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace advice157
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0,1,2,3,4,5,6};
            ArrayList list1 = ArrayList.Adapter(arr);

            List<int> list2 = arr.ToList<int>();
    }
}
