using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KendoUI.Models
{
    public class KendoUIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public KendoUIContext() : base("name=KendoUIContext")
        {
        }

        public System.Data.Entity.DbSet<KendoUI.Models.Movie> Movies { get; set; }
   
    }


    //The Entity Framework can automatically create (or drop and re-create) a database for you when the application runs. You can specify that this should be done every time your application runs or only when the model is out of sync with the existing database. You can also write a Seed method that the Entity Framework automatically calls after creating the database in order to populate it with test data.
     
        public class initializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<KendoUIContext>
        {

            protected void Seed(KendoUIContext context)
            {

                List<Movie> MovieList = new List<Movie>();
                MovieList.Add(new Movie(1, "Action", "Bad news", "2014"));
                MovieList.Add(new Movie(2, "Horror", "Terry", "2011"));
                MovieList.Add(new Movie(3, "Action", "Braking Bad", "2012"));
                MovieList.Add(new Movie(4, "Drama", "Just do", "2009"));
                MovieList.Add(new Movie(5, "Drama", "Be happy", "2008"));
                MovieList.Add(new Movie(6, "Thriller", "The last of art", "2007"));
                MovieList.Add(new Movie(7, "Action", "Dark Country", "2014"));
                MovieList.Add(new Movie(8, "Family", "Far til fire", "2011"));
                MovieList.Add(new Movie(9, "Action", "Jack from New York", "2013"));

                MovieList.ForEach(s => context.Movies.Add(s));
                context.SaveChanges();




            }



        }
}
