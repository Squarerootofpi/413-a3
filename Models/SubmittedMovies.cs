using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _413assignment3.Models
{
    /// <summary>
    /// This is the class for data.
    /// </summary>
    public class SubmittedMovies
    {
        private static List<Movie> movies = new List<Movie>();

        public static IEnumerable<Movie> Movies => movies;

        public static void AddMovie(Movie movie)
        {
            Debug.WriteLine("here!!! Adding movie", movie);
            movies.Add(movie);
        }
    }
}

