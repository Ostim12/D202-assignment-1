using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Collections.ObjectModel;

//my own namespaces
using MovieClasses;
using SaveJson;
using search;
using DataStructuers;
using System.Security.Cryptography.X509Certificates;

namespace D202_assignment_1
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MovieList ActiveMovieList; // list that is currently actively being used
        int SelectedMovieIndexNum = -1;

        Waitlist SelectedMovieWaitlist;

        MovieList LoadedMovies; // 

        MovieList UpdatedMovies;

        MovieList SearchResualtsList; // resualts from a search function
        int SearchResualtsIndexNum = -1;

        SimpleHashTable<Movie> MoviesHashTable = new SimpleHashTable<Movie>();

        SortListOfMoviesByTitle SortByTitle = new SortListOfMoviesByTitle();

        string Search_Type = "SearchRBTitle";

        string CustomerName = "";


        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateBtnBorrowJoinWaitlist()
        {
            SelectedMovieWaitlist = ActiveMovieList.Movies[SelectedMovieIndexNum].Waitlist;
            if (SelectedMovieWaitlist.IsEmpty)
            {
                BtnBorrowJoinWaitlist.Content = "Borrow Movie";
                BtnReturn.IsEnabled = false;
                return;
            }
            if (SelectedMovieWaitlist.IsFull)
            {
                BtnBorrowJoinWaitlist.Content = "Join WaitList";
                BtnBorrowJoinWaitlist.IsEnabled = false;
                BtnReturn.IsEnabled = true;
                return;
            }
            BtnBorrowJoinWaitlist.Content = "Join WaitList";
            BtnReturn.IsEnabled = true;
        }


        public void UpdateMovieBox(MovieList updataList)
        {
            if (updataList != null)
            {
                MovieBox.Items.Clear(); 
                foreach (Movie movie in updataList.Movies)
                {
                    MovieBox.Items.Add(movie);
                }
            }
        }

        public void Save(MovieList SaveList){
            SaveJson.SaveJson Saver = new SaveJson.SaveJson();
            Saver.Save(SaveList);
        }


        private void LoadFileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadedMovies = LoadJson.loadMovies();
                ActiveMovieList = LoadedMovies;
                UpdateMovieBox(ActiveMovieList);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void SaveFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Save(ActiveMovieList);
        }

        private void BTNAddMovie_Click(object sender, RoutedEventArgs e)
        {
            Movie newMovie = new Movie();
            if (InputMovieID.Text == "") { MessageBox.Show("id can't be blank"); return; }
            newMovie.ID = InputMovieID.Text;
            newMovie.Title = InputMovieTitle.Text;
            newMovie.Director = InputMovieDirector.Text;
            newMovie.Genre = InputMovieGenre.Text;
            newMovie.ReleaseYear = InputMovieReleaseYear.Text;
            if (InputMovieAvailability.IsChecked == true) // IsChecked is nullable
            {
                newMovie.IsAvailable = true;
            }
            else 
            { 
                newMovie.IsAvailable = false; 
            }

                try
            {
                UpdatedMovies = ActiveMovieList;
                if (UpdatedMovies == null)
                    UpdatedMovies = new MovieList();
                UpdatedMovies.Add(newMovie);
                ActiveMovieList = UpdatedMovies;
                UpdateMovieBox(ActiveMovieList);
            }catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void BTNEditMovie_Click(object sender, RoutedEventArgs e)
        {



        }

        private void BTNSortByID_Click(object sender, RoutedEventArgs e)
        {
            ActiveMovieList = SortListOfMoviesByID.SortByID(ActiveMovieList);
            UpdateMovieBox(ActiveMovieList);
        }

        private void BTNSortByTitle_Click(object sender, RoutedEventArgs e)
        {
            ActiveMovieList = SortListOfMoviesByTitle.SortByTitle(ActiveMovieList);
            UpdateMovieBox(ActiveMovieList);
        }

        private void SearchRB_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            Search_Type = rb.Name;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveMovieList == null) 
                { return; }
            if (Search_Type == "SearchRBTitle")
            {
                try
                {
                    (SearchResualtsList , SearchResualtsIndexNum) = SearchBYTitle.search(ActiveMovieList, SearchBox.Text);
                    UpdateMovieBox(SearchResualtsList);
                }
                catch (Exception E)
                { Debug.WriteLine(E.Message); }
            }
            if (Search_Type == "SearchRBID")
            {
                try
                {
                    (SearchResualtsList, SearchResualtsIndexNum) = SearchByID.search(ActiveMovieList, SearchBox.Text);
                    UpdateMovieBox(SearchResualtsList);
                }
                catch (Exception E)
                { Debug.WriteLine(E.Message); }
        }
        }

        private void SearchClear_Click(object sender, RoutedEventArgs e)
        {
            UpdateMovieBox(ActiveMovieList);
            SearchResualtsList.Clear();
            SearchResualtsIndexNum = -1;
        }

        private void MovieBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchResualtsIndexNum != -1)
            {
                if (MovieBox.SelectedIndex >= 0)
                {
                    SelectedMovieIndexNum = SearchResualtsIndexNum;
                    UpdateBtnBorrowJoinWaitlist();
                }
                return; 
            }
            SelectedMovieIndexNum = MovieBox.SelectedIndex;
            if (MovieBox.SelectedIndex == -1)
            {
                TabBorrowReturn.IsEnabled = false;
                if (TabBorrowReturn.IsFocused)
                {
                    TabLoadSave.Focus();
                    UpdateBtnBorrowJoinWaitlist();
                }
                return;
            }
            TabBorrowReturn.IsEnabled = true;
            if (!TabAddEdit.IsFocused) 
            {
                TabBorrowReturn.Focus();
            }
            UpdateBtnBorrowJoinWaitlist();
        }

        private void BtnBorrowJoinWaitlist_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveMovieList.Movies[SelectedMovieIndexNum].IsAvailable)
            {
                ActiveMovieList.Movies[SelectedMovieIndexNum].IsAvailable = false;
                UpdateBtnBorrowJoinWaitlist();
                return;
            }
            if (CustomerName == "")
            {
                MessageBox.Show("Please Enter a name");
                return;
            }
            if (SelectedMovieWaitlist.IsFull)
            {
                MessageBox.Show("Waitlist is full");
                return;
            }
            SelectedMovieWaitlist.Enqueue(CustomerName);
            UpdateBtnBorrowJoinWaitlist();
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveMovieList.Movies[SelectedMovieIndexNum].IsAvailable)
            {
                return;
            }
            if (SelectedMovieWaitlist.IsEmpty)
            {
                ActiveMovieList.Movies[SelectedMovieIndexNum].IsAvailable = true;
                return;
            }
            string NextPerson = SelectedMovieWaitlist.Dequeue();
            MessageBox.Show($"Movie is now borowed out to : {NextPerson}");

        }

        private void InputUsersName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerName = InputUsersName.Text;
        }
    }
}