using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BubbleSort<T> where T : IComparable<T>
    {
        public BubbleSort() { }

        public T[] Sort(T[] values)
        {
            int n = values.Length;
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (values[i].CompareTo(values[i + 1]) > 0) // Ascending order
                    {
                        Swap(values, i, i + 1);
                        swapped = true;
                    }
                }
                n--; // Largest element is correctly placed, reduce search space
            }
            while (swapped);

            return values;
        }

        private void Swap(T[] values, int i, int j)
        {
            T temp = values[i];
            values[i] = values[j];
            values[j] = temp;
        }
    }

    public class MergeSort<T> where T : IComparable<T>
    {
        public MergeSort() { }

        // Array A[] has the items to sort; array B[] is a work array.
        public void Sort(T[] A)
        {
            T[] B = new T[A.Length];
            int n = A.Length;
            CopyArray(A, 0, n, B);           // one time copy of A[] to B[]
            TopDownSplitMerge(A, 0, n, B);   // sort data from B[] into A[]
        }

        // Split A[] into 2 runs, sort both runs into B[], merge both runs from B[] to A[]
        // iBegin is inclusive; iEnd is exclusive (A[iEnd] is not in the set).
       private void TopDownSplitMerge(T[] B,int iBegin,int iEnd, T[] A)
        {
            if (iEnd - iBegin <= 1)                     // if run size == 1
                return;                                 //   consider it sorted
                                                        // split the run longer than 1 item into halves
            int iMiddle = (iEnd + iBegin) / 2;              // iMiddle = mid point
                                                        // recursively sort both runs from array A[] into B[]
            TopDownSplitMerge(A, iBegin, iMiddle, B);  // sort the left  run
            TopDownSplitMerge(A, iMiddle, iEnd, B);  // sort the right run
                                                     // merge the resulting runs from array B[] into A[]
            TopDownMerge(B, iBegin, iMiddle, iEnd, A);
        }

        //  Left source half is A[ iBegin:iMiddle-1].
        // Right source half is A[iMiddle:iEnd-1   ].
        // Result is            B[ iBegin:iEnd-1   ].
        private void TopDownMerge(T[] B,int iBegin,int iMiddle,int iEnd,T[] A)
        {
            int i = iBegin, j = iMiddle;

            // While there are elements in the left or right runs...
            for (int k = iBegin; k < iEnd; k++)
            {
                // If left run head exists and is <= existing right run head.
                if (i < iMiddle && (j >= iEnd || A[i].CompareTo(A[j]) < 0))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
        }

        void CopyArray(T[] A,int iBegin,int iEnd,T[] B)
        {
            for (int k = iBegin; k < iEnd; k++)
                B[k] = A[k];
        }
    }
}
