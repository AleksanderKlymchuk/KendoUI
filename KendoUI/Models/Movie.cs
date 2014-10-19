using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUI.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
       
         public Movie()
        {



        }
      
       
        public Movie(int id,string genre,string title,string year)
        {

            this.ID = id;
            this.Genre = genre;
            this.Title = title;
            this.Year = year;
        }


    }
}