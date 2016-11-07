using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>, IComparable<T> where T : IComparable
    {
        int count;
        int size;
        static int startingSize = 10;
        public T[] list;
        //similar to the use of dthe default (for the type) equality operator 
        public static Comparer<T> Default { get; }
        int positiveOffset = 1;
        int negativeOffset = -1;
        int neutralOffset = 0;


        public CustomList()
        {
            size = startingSize - 1;
            count = 0;
            list = new T[startingSize];
        }

        public void Add(T item, int index)
        {
            CheckSize();
            T[] temp = new T[size];
            temp = Copy(0, index, positiveOffset, temp);
            temp[index] = item;
            count++;
            temp = Copy(index + 1, size, negativeOffset, temp);
            list = temp;
        }

        //adds an item to the end of the array
        //doubles the size of the array if it's not big enough
        public void Add(T item)
        {
            CheckSize();
            list[count] = item;
            count++;
        }

        private T[] IncreaseSize()
        {
            T[] temp = new T[size * 2];
            //if the array is not large enough, its size is double
            //copy all elements into new array

            Copy(0, count, 0, temp);

            size = size * 2;
            return temp;
        }

        private T[] Copy(int from, int to, int offset, T[] temp)
        {
            for (int i = from; i < to; i++)
            {
                temp[i] = list[i + offset];
            }
            return temp;

        }


        private void CheckSize()
        {
            if (size == count)
            {
                list = IncreaseSize();
            }
        }
        //sets index to null then copies subsequent entries to 
        //fill in hole
        public void RemoveAt(int index)
        {

            T[] temp = list;
            temp[index] = default(T);
            count--;
            temp = Copy(index, count, positiveOffset, temp);
            list = temp;
        }

        //sets item at end of list to default value 
        public void Remove()
        {
            list[count - 1] = default(T);
        }
        

        public static CustomList<T> operator +(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> temp = firstList;
            for (int i = 0; i < secondList.count; i++)
            {
                temp.Add(secondList.list[i]);
            }
            return temp;
        }

        //subtraction operator will remove duplicates and return the new list
        public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> temp;
            for (int i = 0; i < firstList.count; i++)
            {
                for (int j = 0; j < secondList.count; j++)
                {
                    if (AreEquals(firstList.list[i], secondList.list[j]))
                    {
                        secondList.RemoveAt(j);
                    }
                }
            }
            temp = firstList + secondList;
            return temp;

        }

        //dynamic means that the type will not be known until runtime
        public CustomList<T> Zip(dynamic firstList, dynamic secondList)
        {
            CustomList<T> temp = new CustomList<T>();

            for (int i = 0; i < firstList.count; i++)
            {
                temp.Add(firstList.list[i] + secondList.list[i]);
            }
            for (int i = firstList.count; i < secondList.count; i++)
            {
                temp.Add(secondList.list[i]);
            }
            return temp;
        }

        public override string ToString()
        {
            string message = "\t" + count + " items in list.\n";
            for (int i = 0; i < count; i++)
            {
                message = message + list[i] + "\n";

            }
            message += "\tDone.";
            return message;
        }

        //implementing bubble sort because i'm familiar with exactly how it works
        public void Sort()
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        Swap(j, j + 1);
                    }

                }
            }
        }

        //bubble sort requires swap helper method
        private void Swap(int indexOfFirst, int indexOfSecond)
        {
            T temp = list[indexOfFirst];
            list[indexOfFirst] = list[indexOfSecond];
            list[indexOfSecond] = temp;



        }

        public T this[int i]
        {
            get
            {
                // This indexer is very simple, and just returns or sets
                // the corresponding element from the internal array.
                return list[i];
            }
            set
            {
                list[i] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return list[i];

            }
        }

        public static bool AreEquals<T>(T firstItem, T secondItem)
        {
            //i use the default comparer for the object to check equality
            return EqualityComparer<T>.Default.Equals(firstItem, secondItem);
        }

        public IEnumerator<T> GetEnumerator()
        {

            for (int i = 0; i < count; i++)
            {
                yield return list[i];

            }
        }

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }
}
