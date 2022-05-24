﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{

    public class MovieLibrarySystem
    {
        public static MemberCollection allMembers = new MemberCollection(10);
        public static MovieCollection allMovies = new MovieCollection();

        public IMember SearchMember(IMember aMember)
        {
            IMember searchedMember = allMembers.Find(aMember);
            if (searchedMember == null)
            {                
                return null;
            }
            else
            {
                return searchedMember;
            }
        }

        public void AddMember(IMember aMember)
        {
            IMember searchedMember = allMembers.Find(aMember);
            if (searchedMember == null)
            {
                allMembers.Add(aMember);
                Console.WriteLine("New member added to the system!");
            }
            else
            {
                Console.WriteLine("Member already exists in the system!");
            }
        }

        public void RemoveMember(IMember aMember)
        {
            IMember searchedMember = allMembers.Find(aMember);
            if (searchedMember == null)
            {
                Console.WriteLine("Member does not exist in the system!");
                return;
            }

            allMembers.Delete(aMember);
            Console.WriteLine("Member removed from the system!");
        }

        public void DisplayPhoneNumber(IMember aMember)
        {
            IMember searchedMember = allMembers.Find(aMember);
            if (searchedMember == null)
            {
                Console.WriteLine("Member does not exist in the system!");
                return;
            }
            Console.WriteLine(searchedMember.FirstName + " " + searchedMember.LastName + "'s contact number is " + searchedMember.ContactNumber);
        }

        public IMovie SearchMovie(string movieTitle)
        {
            IMovie searchedMovie = allMovies.Search(movieTitle);
            if (searchedMovie == null)
            {
                return null;
            }
            else
            {
                return searchedMovie;
            }
        }

        public void AddNewMovieCollection(IMovie aMovie)
        {
            allMovies.Insert(aMovie);
            Console.WriteLine("New movie collection added to the system!");
        }
        public void AddDVD(string movieTitle)
        {   
            IMovie searchedMovie = allMovies.Search(movieTitle);
            searchedMovie.AvailableCopies++;
            searchedMovie.TotalCopies++;
            Console.WriteLine("1 DVD is added.");
            Console.WriteLine("There is a total of " + searchedMovie.TotalCopies + " DVDs now.");
        }
        public void RemoveDVD(string movieTitle)
        {
            IMovie searchedMovie = allMovies.Search(movieTitle);
            if (searchedMovie == null)
            {
                Console.WriteLine("Movie does not exist in the system!");
                return;
            }
            else
            {
                if (searchedMovie.TotalCopies > 1) {
                    searchedMovie.AvailableCopies--;
                    searchedMovie.TotalCopies--;
                    Console.WriteLine("1 DVD is removed.");
                    Console.WriteLine("There is a total of " + searchedMovie.TotalCopies + " DVDs now.");
                }

                else { 
                    allMovies.Delete(searchedMovie);
                    Console.WriteLine("Last DVD is removed.");
                    Console.WriteLine("The movie " + searchedMovie.Title + " is removed from the system.");
                }                
            }
        }
    }
}
