using MovieClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace search
{
    public class LinearSearcher<T>
    {
        public static int LinearSearch(T[] arr, T key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (Comparison<T>.Equals(arr[i], key)) return i;
            }
            return -1;
        }

    }

    public class BinarySearch<T> where T : IComparable<T>
    {
        public static int Search(T[] arr, T key)
        {
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                // Found the key, return its position
                if (Comparison<T>.Equals(arr[mid], key)) return mid;
                // If the middle element is less than the key, search in the right hal
                if ((key.CompareTo(arr[mid])) > 0) left = mid + 1;
                else right = mid - 1; // Otherwise, search in the left half
            }
            return -1; // negative index signals not found
        }
    }

    public class SearchBYTitle
    {
        public static MovieList search(MovieList Searchlist, string ThingToFind)
        {
            string[] titles = new string[Searchlist.Count];
            for (int i = 0; i < Searchlist.Count; i++)
                {
                    titles[i] = Searchlist.Movies[i].Title;
                }

            int index = LinearSearcher<string>.LinearSearch(titles, ThingToFind);
            if (index == -1)
            {
                MessageBox.Show("Could Not Find Movie");
                throw new Exception("search not found");
            }
            MovieList returnlist = new MovieList();
            returnlist.Add(Searchlist.Movies[index]);
            return returnlist;

        }
    }
}
