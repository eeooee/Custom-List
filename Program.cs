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

            CustomList<int> differenceList;
            CustomList<int> zipList;
            sumList = new CustomList<int>();
            CustomList<int> myList;
            myList = new CustomList<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);
            string message = myList.ToString();
            Console.WriteLine("List One \n {0}", message);
            CustomList<int> otherList;
            otherList = new CustomList<int>();
            otherList.Add(12);
            otherList.Add(11);
            otherList.Add(10);
            otherList.Add(9);
            otherList.Add(8);
            otherList.Add(7);
            otherList.Add(6);
            message = otherList.ToString();
            Console.WriteLine("List Two \n {0}", message);
            differenceList = otherList - myList;
            message = differenceList.ToString();
            Console.WriteLine("List two minus list one \n {0}", message);
            sumList = myList + otherList;
            message = sumList.ToString();
            Console.WriteLine("List one plus list two \n {0}", message);
            zipList = otherList.Zip(otherList, myList);
            message = zipList.ToString();
            Console.WriteLine("List one and list two zipped \n {0}", message);
            zipList.Sort();
            message = sumList.ToString();
            Console.WriteLine("Sorted List \n {0}", message);
            Console.ReadLine();

        }
    }
}
