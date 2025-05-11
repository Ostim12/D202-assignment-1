using D202_assignment_1;
using MovieClasses;
using search;

namespace TestIng
{
    public class UnitTestSorting
    {
        [Fact]
        public void SortListOfMoviesByIDTest()
        {
            MovieList testList = new MovieList();

           

            for (int i = 9; i > 0; i--)
            {
                Movie testMovie1 = new Movie();
                testMovie1.ID = Convert.ToString(i);
                testMovie1.Title = "Title" + i;
                testList.Add(testMovie1);
            }

            testList = SortListOfMoviesByID.SortByID(testList);

            for (int i = 1; i < 10; i++)
            {
                Assert.Equal(Convert.ToString(i), testList.Movies[i-1].ID);
            }
        }

        [Fact]
        public void SortListOfMoviesByTitleTest()
        {
            MovieList testList = new MovieList();

            

            for (int i = 9; i > 0; i--)
            {
                Movie testMovie1 = new Movie();
                testMovie1.ID = Convert.ToString(i);
                testMovie1.Title = "Title" + i;
                testList.Add(testMovie1);
            }

            testList = SortListOfMoviesByTitle.SortByTitle(testList);

            for (int i = 1; i < 10; i++)
            {
                Assert.Equal("Title" + i, testList.Movies[i - 1].Title);
            }
        }

    }

    public class UnitTestSearching
    {
        [Fact]
        public void SearchByTitle()
        {
            MovieList testList = new MovieList();

            // id , title , pos
            // 9 , Title9 , 0
            // 8 , Title8 , 1
            // 7 , Title7 , 2
            // 6 , Title6 , 3

            for (int i = 9; i > 0; i--)
            {
                Movie testMovie1 = new Movie();
                testMovie1.ID = Convert.ToString(i);
                testMovie1.Title = "Title" + i;
                testList.Add(testMovie1);
            }

            MovieList outputlist = new MovieList();

            int outputIndexNum = -1;
            
            (outputlist,outputIndexNum) = SearchBYTitle.search(testList, "Title6");

            Assert.Equal(3, outputIndexNum);
            Assert.Equal("Title6", outputlist.Movies[0].Title);

        }
        [Fact]
        public void SearchBYID()
        {
            MovieList testList = new MovieList();

            // all strings
            // id , title , pos
            // 0 , Title0 , 0
            // 1 , Title1 , 1
            // 2 , Title2 , 2
            // 3 , Title3 , 3
            //... goes to 9

            for (int i = 0; i < 10; i++)
            {
                Movie testMovie1 = new Movie();
                testMovie1.ID = Convert.ToString(i);
                testMovie1.Title = "Title" + i;
                testList.Add(testMovie1);
            }
            testList.IsSortedByID = true;

            MovieList outputlist = new MovieList();

            int outputIndexNum = -1;

            (outputlist, outputIndexNum) = SearchByID.search(testList, "5");

            Assert.Equal(5, outputIndexNum);
            Assert.Equal("5", outputlist.Movies[0].ID);

        }
    }
}