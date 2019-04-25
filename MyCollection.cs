using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning2._5
{
    class MyCollection<T>
    {
        protected int buffer;
        protected T[] list;
        protected int length;
        protected int count;

        public MyCollection()
        {
            buffer = 30;
            count = 0;
            length = 30;
            list = new T[length];
        }

        protected void Expand(int size)
        {
            if (size < 1) return;
            //Expand collection
            T[] temp = new T[length + size];
            //Copy values from old collection
            for (int i = 0; i < count; i++) temp[i] = list[i];
            list = temp;
            length += size;
        }

        protected void Reduce()
        {
            //Create a new smaller collection
            T[] temp = new T[count];
            //Copy values from old collection
            for (int i = 0; i < count; i++) temp[i] = list[i];
            list = temp;
            length = count;
        }

        public void Add(T e)
        {
            //Add elements if needed
            if (count + 1 > length) Expand(1 + buffer);
            list[count++] = e;
        }

        public T Remove(int index)
        {
            T temp = list[index];
            if (index < count)
            {
                //Copy all elements after index one step to the left 
                for (int i = index; i < count; i++) list[i] = list[i + 1];
                count--;
                //Decrease collection if there are to many empty elements
                if (length - count > buffer) Reduce();
            }
            return temp;
        }

        //Returns the count of used elements in the list
        public int Count()
        {
            return count;
        }

        //Returns the value from a given index
        public T GetValue(int index)
        {
            return list[index];
        }

        //Return true if a given value exists in the list
        public bool ValueExists(T e)
        {
            foreach (T item in list)
                if (e.Equals(item)) return true;
            return false;
        }

        //Returns the first index of a given value
        //Returns -1 if the value is not found
        public int FirstIndexOf(T e)
        {
            for (int i = 0; i < count; i++)
                if (list[i].Equals(e)) return i;
            return -1;
        }

        //Adds elements from the passed collection to this collection
        public void AddRange(MyCollection<T> c)
        {
            //Copy passed collection to a new adress
            MyCollection<T> tmp = new MyCollection<T>();
            tmp.length = c.length;
            tmp.count = c.count;
            T[] tmpLst = new T[c.count];
            for (int i = 0; i < c.count; i++) tmpLst[i] = c.list[i];
            tmp.list = tmpLst;
            //Add copied collection to this collection
            for (int i = 0; i < tmp.count; i++)
                Add(tmp.list[i]);
        }

        //Indexmethod to make it possible to use functions like "myCollection.list[i]"
        //from the main program
        public T this[int index]
        {
            get { return list[index]; }
        }
    }
}
