using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClasses
{
    public class Movie
    {
        public string? ID { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public int? ReleaseYear { get; set; }
        public bool? Availability { get; set; }
    }


    public class MovieCollection : LinkedList<Movie>
    {
        public String Name { get; set; }

        public MovieCollection(string name)
        {
            Name = name;
        }
    }

    public class MovieList
    {
        public Movie[]? Movies { get; set; }
    }


}
