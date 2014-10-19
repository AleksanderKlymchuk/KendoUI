using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoUI.Models;

namespace KendoUI.Controllers
{
    public class GridController : Controller
    {
        private KendoUIContext db = new KendoUIContext();
        //
        // GET: /Grid/
        public ActionResult Index()
        {
            List<Movie> MovieList = new List<Movie>();
            MovieList.Add(new Movie(1,"Action","Bad news","2014"));
            MovieList.Add(new Movie(2, "Horror", "Terry", "2011"));
            MovieList.Add(new Movie(3, "Action", "Braking Bad", "2012"));
            MovieList.Add(new Movie(4, "Drama", "Just do", "2009"));
            MovieList.Add(new Movie(5, "Drama", "Be happy", "2008"));
            MovieList.Add(new Movie(6, "Thriller", "The last of art", "2007"));
            MovieList.Add(new Movie(7, "Action", "Dark Country", "2014"));
            MovieList.Add(new Movie(8, "Family", "Far til fire", "2011"));
            MovieList.Add(new Movie(9, "Action", "Jack from New York", "2013"));
            return View(db.Movies.ToList());
        }
	}
}