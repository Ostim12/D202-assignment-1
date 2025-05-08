using D202_assignment_1;
using MovieClasses;

namespace TestIng
{
    public class UnitTestSorting
    {
        [Fact]
        public void SortListOfMoviesByIDTest()
        {
            MovieList testList = new MovieList();

            Movie testMovie1 = new Movie();

            for (int i = 10; i > 0; i--)
            {
                testMovie1.ID = Convert.ToString(i);
                testMovie1.Title = "Title" + i;
                testList.Add(testMovie1);
            }

            SortListOfMoviesByID.SortByID(testList);

            for (int i = 0; i > 10; i++)
            {
                Assert.Equal(Convert.ToString(i), testList.Movies[i].ID);
            }
        }

        [Fact]
        public void SortListOfMoviesByTitleTest()
        {
            MovieList testList = new MovieList();

            Movie testMovie1 = new Movie();

            for (int i = 10; i > 0; i--)
            {
                testMovie1.ID = Convert.ToString(i);
                testMovie1.Title = "Title" + i;
                testList.Add(testMovie1);
            }

            SortListOfMoviesByTitle.SortByTitle(testList);

            for (int i = 0; i > 10; i++)
            {
                Assert.Equal("Title" + i, testList.Movies[i].Title);
            }
        }

    }

    public class UnitTestSearching
    {

    }
}