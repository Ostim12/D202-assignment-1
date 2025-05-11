using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using search;
using DataStructuers;
using D202_assignment_1;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.ExceptionServices;
using System.Collections;
using System.Drawing;

namespace MovieClasses
{
    public class Movie
    {
        public string? ID { get; set; } 
        public string? Title { get; set; } 
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public string? ReleaseYear { get; set; }
        public bool IsAvailable { get; set; } //is available 
        public Waitlist Waitlist {  get; set; }

        public Movie() 
        {
            Waitlist = new Waitlist(10); // max of 10 customers can be in the wait list at once
        }



    }

    public class Waitlist : DataStructuers.Queue<string>
    {
        public bool IsFull { get { return (size == queue.Length); } }
        public bool IsEmpty { get { return !(size >= 1); } }

        public Waitlist(int capacity) : base(capacity)
        {
            queue = new string[capacity];
            size = 0;
        }
        public string[] ShowAll() { return queue; }
    }


    public class MovieCollection : LinkedList<Movie>
    {
        public String CollectionName { get; set; }

        public MovieCollection(string name)
        {
            CollectionName = name;
        }
    }

    public class MovieList
    {
        public List<Movie> Movies
            { get; set; }

        public bool IsSortedByID;

        public int Count { get { return Movies.Count; } }

        public MovieList()
        {
            Movies = new List<Movie>();

        }

        public void Add(Movie movie)
        {
            if (IsIDAllreadyIn(movie.ID))
            {
                throw new Exception("movie with same ID already in list");
            }
            Movies.Add(movie);
            IsSortedByID = false;
        }

        /// <summary>
        /// clears the movie list and sets sorted to false
        /// </summary>
        public void Clear() { Movies.Clear(); IsSortedByID = false; }

        /// <summary>
        /// checks if an id string is in the movie list already
        /// </summary>
        private bool IsIDAllreadyIn(string id)
        {
            foreach (Movie movie in Movies)
            {
                if (movie.ID == id) return true;
            }
            return false;
        }

        /// <summary>
        /// checks all ID in this movie list to see if there are any duplicate IDs
        /// used when Loading from a file
        /// </summary>
        public bool HasDuplicateID()
        {
            string[] IDs = new string[Count];
            for (int i = 0; i < IDs.Length; i++)
            {
                foreach (string id in IDs)
                {
                    if (id == Movies[i].ID)
                    {
                        return true;
                    }
                }
                IDs[i] = Movies[i].ID;
            }
            return false;
        }
    }


}
