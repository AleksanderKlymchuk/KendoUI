using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KendoUI.Models;

namespace KendoUI.Controllers
{
    public class MovieController : ApiController
    {
        private KendoUIContext db = new KendoUIContext();

        // GET api/Movie
        public IQueryable<Movie> GetMovies()
        {

            //List<Movie> MovieList = new List<Movie>();
            //MovieList.Add(new Movie(1, "Action", "Bad news", "2014"));
            //MovieList.Add(new Movie(2, "Horror", "Terry", "2011"));
            //MovieList.Add(new Movie(3, "Action", "Braking Bad", "2012"));
            //MovieList.Add(new Movie(4, "Drama", "Just do", "2009"));
            //MovieList.Add(new Movie(5, "Drama", "Be happy", "2008"));
            //MovieList.Add(new Movie(6, "Thriller", "The last of art", "2007"));
            //MovieList.Add(new Movie(7, "Action", "Dark Country", "2014"));
            //MovieList.Add(new Movie(8, "Family", "Far til fire", "2011"));
            //MovieList.Add(new Movie(9, "Action", "Jack from New York", "2013"));
            
            return db.Movies;
        }

        // GET api/Movie/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT api/Movie/5
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.ID)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Movie
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movie.ID }, movie);
        }

        // DELETE api/Movie/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.ID == id) > 0;
        }
    }
}