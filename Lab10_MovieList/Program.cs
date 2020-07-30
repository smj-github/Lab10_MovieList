using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab10_MovieList
{
    class Program
    {
        // Create a list to store all unique categories
        public static List<string> categoryList = new List<string>();

        // Create a list of movies
        public static List<Movie> movieList = new List<Movie>
        {
            new Movie("Kung Fu Panda","Animation"),
            new Movie("How to train your Dragon", "Animation"),
            new Movie("Borne Ultimatum","Drama"),
            new Movie("Mission Impossible Fallout","Drama"),            
            new Movie("IT","Horror"),
            new Movie("Annabelle","Horror"),            
            new Movie("Interstellar","SciFi"),
            new Movie("Back to the Future","SciFi")
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Movie List Application!");
            char continueSearch = 'y';

            while (continueSearch == 'y')
            {
                // Extract all the indivdual categories from the movie list and store seperately
                MakeCategoryList();
                // Display list of available movies
                DisplayMovieCategories();
                // Get category number from user
                Console.WriteLine("Please enter a number for the movie category");
                string userOpt = Console.ReadLine();
                int searchOpt;
                // Validate user input
                while (!ValidateUserOption(userOpt, out searchOpt))
                {
                    Console.WriteLine("Invalid Input. Please select a valid category number");
                    userOpt = Console.ReadLine();
                }

                // Get all the movies in the category and display the same
                DisplayMovieList(GetMoviesByCategory(searchOpt));
                // Check if the user wants to continue
                Console.WriteLine("\nWould you like to continue? (Enter y/n)");
                if (Console.ReadLine().ToLower()[0] != 'y')
                {
                    Console.WriteLine("Thanks!");
                    continueSearch = 'n';
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        public static bool ValidateUserOption(string userOption, out int number)
        {
            if (int.TryParse(userOption, out number))
            {
                if ((number > 0) && (number <= categoryList.Count))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        public static List<Movie> GetMoviesByCategory(int categoryNumber)
        {
            string categoryName = categoryList[categoryNumber - 1];
            List<Movie> moviesbyCategory = new List<Movie>();

            foreach(Movie m in movieList)
            {
                if(m.Category == categoryName)
                {
                    moviesbyCategory.Add(m);
                }
            }
            return moviesbyCategory;
        }

        public static void MakeCategoryList()
        {
            foreach(Movie m in movieList)
            {
                if (!categoryList.Contains(m.Category))
                {
                    categoryList.Add(m.Category);
                }
            }
        }
        public static void DisplayMovieList(List<Movie> movieList)
        {
            Console.WriteLine("Movies in this category are: \n");

            // sort list
            List<Movie> SortedList = movieList.OrderBy(m => m.Title).ToList();

            foreach (Movie m in SortedList)
            {
                Console.WriteLine(m.Title);
            }
        }

        public static void DisplayMovieCategories()
        {
            for (int i = 0; i < categoryList.Count; i++)
            {
                Console.WriteLine(i+1 + ": " + categoryList[i]);
            }
        }
    }
}
