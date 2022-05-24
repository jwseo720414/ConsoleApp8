using System;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Movie movie = new Movie("Star wars", MovieGenre.Action, MovieClassification.M, 60, 3);
            Movie movie6 = new Movie("Ztar wars", MovieGenre.Action, MovieClassification.M, 60, 3);

            Movie movie1 = new Movie("Atar wars", MovieGenre.Action, MovieClassification.M, 60, 3);
            Movie movie2 = new Movie("aaa", MovieGenre.Action, MovieClassification.M, 60, 3);
            Movie movie3 = new Movie("aa", MovieGenre.Action, MovieClassification.M, 60, 3);
            Movie movie4 = new Movie("b", MovieGenre.Action, MovieClassification.M, 60, 3);
            Movie movie5 = new Movie("a", MovieGenre.Action, MovieClassification.M, 60, 3);



            Member member = new Member("Jaewon", "seo", "0411289259", "1234");
            //Member member1 = new Member("Jaewon1", "seo", "0411289259", "1234");

            bool bo = movie.AddBorrower(member);
            //bool bo1 = movie.AddBorrower(member1);
            MovieCollection movieCollection = new MovieCollection();
            //bool bo2 = movieCollection.IsEmpty();

            Console.WriteLine(bo);
            //Console.WriteLine(bo1);
            //Console.WriteLine(bo2);
            //Console.WriteLine(movie.Borrowers.ToString());
            Console.WriteLine(movie.ToString());

            //movieCollection.Insert(movie);
            //movieCollection.Insert(movie1);
            //movieCollection.Insert(movie2); 
            //Console.WriteLine(movieCollection.IsEmpty());

            Console.WriteLine(movieCollection.Insert(movie));
            //Console.WriteLine(movieCollection.IsEmpty());

            Console.WriteLine(movieCollection.Insert(movie6));

            Console.WriteLine(movieCollection.Insert(movie1));
            Console.WriteLine(movieCollection.Insert(movie2));
            Console.WriteLine(movieCollection.Insert(movie3));
            Console.WriteLine(movieCollection.Insert(movie4));
            Console.WriteLine(movieCollection.Insert(movie5));
            //Console.WriteLine(movieCollection.Number.ToString());
            //Console.WriteLine(movieCollection.Delete(movie2));
            //Console.WriteLine(movie.Title);
            //movieCollection.PreOrderTraverse();
            //movieCollection.InOrderTraverse();

            //Console.WriteLine(movieCollection.Search(movie2));
            //movieCollection.Insert(movie);
            //movieCollection.Insert(movie1);
            //movieCollection.Insert(movie2);

            //if (movieCollection.Search("aaa") == null)
            //{
            //    Console.WriteLine("its NULL");
            //}
            //else
            //{
            //    Console.WriteLine("its NOT NULL");
            //}
            IMovie[] movies = movieCollection.ToArray();
            //Console.WriteLine(movies[0].Title.ToString());
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine(movies[i].Title.ToString());
            }
            Console.WriteLine(movies[2].ToString());



            //Console.WriteLine(movieCollection.ToArray().Length);

            //movieCollection.ToArray();
            //Console.WriteLine(movieCollection.Search("aaa").ToString());


            //Console.WriteLine(movieCollection.Search(movie1));
            //Console.WriteLine(movieCollection.Search(movie2));

            //Console.WriteLine(movieCollection.Delete(movie));








            Console.ReadLine();
        }
    }
}
