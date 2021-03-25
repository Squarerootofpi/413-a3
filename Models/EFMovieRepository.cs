using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413assignment3.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext _context;

        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> Movies => (_context.Movies);

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            Movie objmovie = _context.Movies.Where(m => m.MovieId == movie.MovieId).FirstOrDefault();
            //update values
            objmovie.Title = movie.Title;
            objmovie.Rating = movie.Rating;
            objmovie.Year = movie.Year;
            objmovie.Edited = movie.Edited;
            objmovie.Director = movie.Director;
            objmovie.LentTo = movie.LentTo;
            objmovie.Notes = movie.Notes;

            _context.SaveChanges();
        }


        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
