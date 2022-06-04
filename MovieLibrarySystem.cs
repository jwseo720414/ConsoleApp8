
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

            //判断当前用户是否租赁电影 如果租赁不能删除

            IMovie[] list = allMovies.ToArray();
            bool isBorrower = false;
            //遍历list

            for (int i = 0; i < list.Length; i++)
            {
                IMovie movie = list[i];
                if (movie.Borrowers.Search(searchedMember))
                {
                    isBorrower = true;
                    break;

                }
            }
            if (isBorrower)
            {
                Console.WriteLine("当前用户租赁了电影不能删除！");
            }
            else
            {
                allMembers.Delete(aMember);
                Console.WriteLine("Member removed from the system!");
            }
           
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
        
        
        public void DisplayMovies()
        {
            IMovie[] movies = allMovies.ToArray();
            
            if (movies.Length == 0)
            {
                Console.WriteLine("There are no movies added.");
                return;
            }
            else 
            {
                for (int i = 0; i < movies.Length; i++)
                {
                    Console.WriteLine("Movie title: " + movies[i].Title.ToString());
                    Console.WriteLine("Available Copies: " + movies[i].AvailableCopies.ToString());
                    Console.WriteLine();
                }

            }
        }

        public void DisplayInfo(string movieName)
        {
            IMovie movie = allMovies.Search(movieName);
            if (movie == null)
            {
                Console.WriteLine("The movie doesn't exists in the system!.");
                return;
            }
            else
            {
                Console.WriteLine(); 
                Console.WriteLine("Movie title: " + movie.Title.ToString());
                Console.WriteLine("Movie Genre: " + movie.Genre.ToString());
                Console.WriteLine("Movie Classification: " + movie.Classification.ToString());
                Console.WriteLine("Movie Duration: " + movie.Duration.ToString());
                Console.WriteLine("Available Copies(DVDs): " + movie.AvailableCopies.ToString());
                Console.WriteLine();
            }
        }

        public void BorrowDvd(IMember aMember, string movieTitle)
        {
            IMember searchMember = allMembers.Find(aMember);
            if (searchMember == null)
            {
                Console.WriteLine("Member does not exist in the system!");
                return;
            }
            IMovie searchMovie = allMovies.Search(movieTitle);
            if (searchMovie == null)
            {
                Console.WriteLine("Movie \"" + movieTitle + "\" does not exist in the system!");
            }
            else
            {
                bool borrowAccess = searchMovie.AddBorrower(aMember);
                if (borrowAccess == false)
                {
                    Console.WriteLine("You already borrowing this Movie(DVD)!!");
                }
                else
                {
                    Console.WriteLine("You borrowed \"" + searchMovie.Title.ToString() + "\" !!");
                }
            }
        }

        public void ReturnDvd(IMember aMember, string movieTitle)
        {
            IMember searchMember = allMembers.Find(aMember);
            if (searchMember == null)
            {
                Console.WriteLine("Member does not exist in the system!");
                return;
            }
            IMovie searchMovie = allMovies.Search(movieTitle);
            if (searchMovie == null)
            {
                Console.WriteLine("Movie \"" + movieTitle + "\" does not exist in the system!");
            }
            else
            {
                bool returnAccess = searchMovie.RemoveBorrower(aMember);
                if (returnAccess == false)
                {
                    Console.WriteLine("Currently you are not borrowing this Movie(DVD) \"" + movieTitle + "\" !!");
                }
                else
                {
                    Console.WriteLine("You successfully returned \"" + searchMovie.Title.ToString() + "\" !!");
                }
            }
        }

        public void DisplayAllMembers(string movieTitle)
        {
            IMovie movie = allMovies.Search(movieTitle);
            if (movie == null)
            {
                Console.WriteLine("Movie \"" + movieTitle + "\" does not exist in the system!");
                return;
            }
            else
            {
                Console.WriteLine(movie.Borrowers.ToString());

            }
        }

        public void DisplayTop(IMember member)
        {
            Console.WriteLine("");
            IMovie [] list =  allMovies.ToArray();
         
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = i; j < list.Length; j++)
                {
                    if (list[i].NoBorrowings<list[j].NoBorrowings)
                    {
                        IMovie temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
          
            //取前三条
            if (list.Length == 1)
            {
                Console.WriteLine(list[0].ToString());
            }
            if (list.Length == 2)
            {
                Console.WriteLine(list[0].ToString());
                Console.WriteLine(list[1].ToString());
            }
            if (list.Length>=3)
            {
                Console.WriteLine(list[0].ToString());
                Console.WriteLine(list[1].ToString());
                Console.WriteLine(list[2].ToString());
            }

        }

        /// <summary>
        /// 显示当前登录人 借阅的电影信息
        /// </summary>
        /// <param name="member"></param>
        public void DisplayMovie(IMember member)
        {
            //获取所有movie
            Console.WriteLine("");
            IMovie[] list = allMovies.ToArray();//获取当前所有电影
            //遍历list
            for (int i = 0; i < list.Length; i++)
            {
                IMovie movie = list[i];
                if (movie.Borrowers.Search(member))
                {
                    //有当前借阅人打印电影信息
                    Console.WriteLine(movie.ToString());
                }
            }
        }
    }
}

