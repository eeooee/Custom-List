using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomList<int> sumList;
            sumList = new CustomList<int>();
            CustomList<int> myList;
            myList = new CustomList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(0, 0);
            string message = myList.ToString();
            Console.WriteLine("List One \n {0}", message);
            CustomList<int> otherList;
            otherList = new CustomList<int>();
            otherList.Add(6);
            otherList.Add(5);
            otherList.Add(4);
            otherList.Add(3);
            otherList.Add(2);
            otherList.Add(1);
            otherList.Add(0);
            message = otherList.ToString();
            Console.WriteLine("List Two \n {0}", message);
            sumList = otherList - myList;
            message = sumList.ToString();
            Console.WriteLine("List two minus list one \n {0}", message);
            sumList = myList + otherList;
            message = sumList.ToString();
            Console.WriteLine("List one plus list two \n {0}", message);
            sumList = otherList.Zip(otherList, myList);
            message = sumList.ToString();
            Console.WriteLine("List one and list two zipped \n {0}", message);
            sumList.Sort();
            message = sumList.ToString();
            Console.WriteLine("Sorted List \n {0}", message);
            Console.ReadLine();

        }
    }
}
