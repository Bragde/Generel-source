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
            //Move all elements after index one step to the left
            for (int i = index; i < count - 1; i++) list[i] = list[i + 1];
            count--;
            //Decrease collection if there are to many empty elements
            if (length - count > buffer) Reduce();
            return temp;
        }
    }
}
