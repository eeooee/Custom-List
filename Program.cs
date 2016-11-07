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
            Console.WriteLine(message);
            CustomList<int> otherList;
            otherList = new CustomList<int>();
            otherList.Add(5);
            otherList.Add(9);
            otherList.Add(9);
            otherList.Add(3);
            otherList.Add(9);
            otherList.Add(1);
            otherList.Add(0);
            //sumList = myList - otherList;
            message = otherList.ToString();
            Console.WriteLine(message);
            sumList = otherList.Zip( otherList, myList);

            message = sumList.ToString();
            Console.WriteLine(message);
            sumList.Sort();
            message = sumList.ToString();
            Console.WriteLine(message);
            Console.ReadLine();

        }
    }
}
