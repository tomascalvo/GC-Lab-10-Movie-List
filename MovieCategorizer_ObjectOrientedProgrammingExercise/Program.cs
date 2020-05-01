using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MovieCategorizer_ObjectOrientedProgrammingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Welcome to Movie Categorizer. \n");
            Thread.Sleep(1000);
            Console.WriteLine("Let's make a list of movies. I'll start.\n");
            Thread.Sleep(2000);
            List<Movie> movies = GenerateMovieList();
            List<string> categories = GenerateGenreList(movies);
            PrintAllMoviesByGenre(categories, movies);
            ChooseGenre(categories, movies);
            Console.WriteLine("Thanks for categorizing movies with me!");
        }

        public static List<Movie> GenerateMovieList()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie("The Shawshank Redemption", "drama"));
            movies.Add(new Movie("Jaws", "horror"));
            movies.Add(new Movie("Poltergeist", "horror"));
            movies.Add(new Movie("Birth", "drama"));
            movies.Add(new Movie("Snow White", "animation"));
            movies.Add(new Movie("The Incredibles", "animation"));
            movies.Add(new Movie("Ad Astra", "scifi"));
            movies.Add(new Movie("Oblivion", "scifi"));
            movies.Add(new Movie("Annihiliation", "scifi"));
            movies.Add(new Movie("Arrival", "scifi"));
            return movies;
        }

        public static List<string> GenerateGenreList( List<Movie> movies)
        {
            List<string> genres = new List<string>();
            foreach (Movie movie in movies)
            {
                if (!genres.Contains(movie.Category))
                genres.Add(movie.Category);
            }
            //DIAGNOSTIC
            //foreach (string genre in genres)
            //{
            //Console.WriteLine($"\"{genre}\" has been added to the genre list.");
            //}
            return genres;
        }

        public static void PrintAllMoviesWithinAGenre(string category, List<Movie> movies)
        {
            bool emptyGenre = true;
            foreach (Movie movie in movies)
            {
                if (movie.Category.Equals(category))
                {
                    Console.WriteLine(category.ToUpper());
                    emptyGenre = false;
                    break;
                }
            }
            foreach (Movie movie in movies)
            {
                if (movie.Category.Equals(category))
                {
                    Console.WriteLine(movie.Title);
                }
            }
            if (!emptyGenre)
            {
                Console.WriteLine("");
                Thread.Sleep(200);
            }
        }

        public static void PrintAllMoviesByGenre(List<string> categories, List<Movie> movies)
        {
            foreach (string category in categories)
            {
                PrintAllMoviesWithinAGenre(category, movies);
            }
        }

        public static void AddMovieToList(List<Movie> movies, string title, string category)
        {
            movies.Add(new Movie(title, category));
        }

        public static void ChooseGenre(List<string> genres, List<Movie> movies)
        {
            bool loop = true;
            int counter = 0;
            while (loop)
            {
                Console.Write($"So what kind of movie do you feel like watching? ");
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                foreach (string genre in genres)
                {
                    Console.Write($"{myTI.ToTitleCase(genre)}? ");
                }
                Console.Write("As long as there's no subtitles. ");
                Regex re = new Regex(@"\w");
                string selection = Console.ReadLine().ToLower().Trim();
                bool valid = false;
                while (!valid)
                {
                    foreach (string genre in genres)
                    {
                        if (!re.IsMatch(selection))
                        {
                            Console.WriteLine("Invalid entry. Please enter a word.");
                            valid = false;
                        }
                        else if (selection == genre)
                        {
                            valid = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry. I don't have that genre.");
                            valid = false;
                        }
                    }
                }
                foreach (string genre in genres)
                {
                    if (selection == genre)
                    {
                        Console.WriteLine($"I could go for {genre}. Here's what I've got:\n");
                        PrintAllMoviesWithinAGenre(genre, movies);
                        Thread.Sleep(2000);
                        Console.WriteLine($"Still feeling {genre}, or would you rather switch genre altogether? y/n");
                        string response = Console.ReadLine().ToLower().Trim();
                        if (response == "y")
                        {
                            loop = true;
                            counter++;
                            break;
                        }
                        else if (response == "n")
                        {
                            loop = false;
                            break;
                        }
                        else
                        {
                            throw new Exception ("New genre? y/n, please.");
                            loop = true;
                        }
                    }
                }
                if (counter > 3)
                {
                    Console.WriteLine("Thanks for categorizing movies with me!");
                    Thread.Sleep(4000);
                    AskToFillMovieList(movies);
                }
            }
        }

        public static void AskToFillMovieList(List<Movie> movies)
        {
            Console.WriteLine("Would you like to add more movies to my list? y/n");
            bool loop = true;
            while (loop)
            {
                string yNResponse = Console.ReadLine().ToLower();
                if (yNResponse == "y")
                {
                    Console.Write("Yes! ");
                    Console.WriteLine("What's the title of your movie?");
                    string titleResponse = Console.ReadLine();
                    Console.WriteLine("Never heard of it. What's the genre of that one?");
                    string categoryResponse = Console.ReadLine();
                    AddMovieToList(movies, titleResponse, categoryResponse);
                    Console.WriteLine($"Okay, I've added \"{titleResponse} to the {categoryResponse} list. Are you sure that's a real movie?");
                    loop = false;
                }
                else if (yNResponse == "n")
                {
                    Console.WriteLine("That's okay. I have an expansive personal collection.");
                    loop = false;
                } else
                {
                    Console.WriteLine("Excuse me?");
                    loop = true;
                }

            }
        }

    }
}
