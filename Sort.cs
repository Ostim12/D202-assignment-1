using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class BubbleSort<T> where T : IComparable<T>
    {
        public T[] Sort(T[] values)
        {
            do
            {
                buble_Sort(values);
            }
            while (!sorted(values));
            return values;
        }

        private bool sorted(T[] input)
        {
            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i + 1].CompareTo(input[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private T[] buble_Sort(T[] values)
        {
            T temp;
            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i + 1].CompareTo(values[i])>0)
                {
                    temp = values[i];
                    values[i] = values[i + 1];
                    values[i + 1] = temp;

                    Console.WriteLine("swaped " + temp + " " + values[i]);
                }
            }

            return values;
        }
        
    }
}
