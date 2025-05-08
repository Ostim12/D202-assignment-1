using MovieClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace D202_assignment_1
{
    public class SortListOfMoviesByTitle
    {
        private MovieList _ListOfMovies;
        private String[] _Titles;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListOfMovies"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static MovieList SortByTitle(MovieList ListOfMovies) 
        {
            if (ListOfMovies == null) { throw new Exception(message: "Inputed list is empty"); }
            ListOfMovies = ListOfMovies;

            string[] Titles = new string[ListOfMovies.Movies.Count];

            for (int i = 0; i < Titles.Length; i++)
            {
                Titles[i] = ListOfMovies.Movies[i].Title;
            }

            ListOfMovies = Sort(Titles, ListOfMovies);

            ListOfMovies.IsSortedByID = false;
            return ListOfMovies;

        }

        private static MovieList Sort(string[] values, MovieList movielist) // bubble sort
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
                        Swap(values, movielist.Movies ,i, i + 1);
                        swapped = true;
                    }
                }
                n--; // Largest element is correctly placed, reduce search space
            }
            while (swapped);

            return movielist;
        }

        private static void Swap(string[] values, List<Movie> Movies, int i, int j)
        {
            string temp = values[i];
            Movie tempMovie = Movies[i];
            values[i] = values[j];
            Movies[i] = Movies[j];
            values[j] = temp;
            Movies[j] = tempMovie;
        }


    }

    public class SortListOfMoviesByID
    {
        public static MovieList SortByID(MovieList ListOfMovies) 
        {
            if (ListOfMovies == null) { throw new Exception(message: "Inputed list is empty"); }

            string[] IDs = new string[ListOfMovies.Movies.Count];

            for (int i = 0; i < IDs.Length; i++)
            {
                IDs[i] = ListOfMovies.Movies[i].ID;
            }

            ListOfMovies = Sort(IDs, ListOfMovies);
            ListOfMovies.IsSortedByID = true;
            return ListOfMovies;
        }

        private static MovieList Sort(string[] IDs, MovieList Movies) // selection sort
        {
            int n = IDs.Length;
            for (int i = 0; i < n - 1; i++)
            {

                // Assume the current position holds
                // the minimum element
                int min_idx = i;

                // Iterate through the unsorted portion
                // to find the actual minimum
                for (int j = i + 1; j < n; j++)
                {
                    if (IDs[j].CompareTo(IDs[min_idx]) < 0)
                    {

                        // Update min_idx if a smaller element
                        // is found
                        min_idx = j;
                    }
                }

                // Move minimum element to its
                // correct position
                string temp = IDs[i];
                Movie tempMovie = Movies.Movies[i];
                IDs[i] = IDs[min_idx];
                Movies.Movies[i] = Movies.Movies[min_idx];
                IDs[min_idx] = temp;
                Movies.Movies[min_idx] = tempMovie;
            }
            return Movies;
        }
    }
}
