using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCategorizer_ObjectOrientedProgrammingExercise
{
    class Movie
    {
        //privateFields
        private string title;
        private string category;
        //PublicProperties
        public string Title
        {
            get //referenced when we call this property from an object
            {
                return title;
            }
            set //used when we give the property its value
            {
                title = value;
            }
        }
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }
        //OVERLOADED CONSTRUCTOR
        public Movie(string _title, string _category)
        {
            title = _title; //setting our field equal to the value coming from where we instantiate our object
            category = _category;
        }
        //DEFAULT CONSTRUCTOR
        public Movie() { }
        //METHODS
        public void PrintMovieInfo()
        {
            Console.WriteLine($"{title} is a movie of category: {category}.");
        }
    }
}
