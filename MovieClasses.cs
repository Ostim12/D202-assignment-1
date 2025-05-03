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

namespace MovieClasses
{
    public class Movie
    {
        public string? ID { get; set; } 
        public string? Title { get; set; } 
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public string? ReleaseYear { get; set; }
        public bool? Availability { get; set; } //is available 
        private DataStructuers.Queue<Customer> Waitlist {  get; set; }

        public Movie() 
        {
            Waitlist = new DataStructuers.Queue<Customer> (10); // max of 10 customers can be in the wait list at once
        }



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

        public void Add(Movie movie)
        {
            Movies.Add(movie);
        }
    }


}
