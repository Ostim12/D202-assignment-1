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
using LoadJson;
using SaveJson;
using search;
using Sorting;
using DataStructuers;
using System.Security.Cryptography.X509Certificates;

namespace D202_assignment_1
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MovieList LoadedMovies;

        MovieList UpdatedMovies;

        SimpleHashTable<Movie> MoviesHashTable = new SimpleHashTable<Movie>();

        public MainWindow()
        {
            InitializeComponent();
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

        public T[] BubbleSort<T>(T[] values) where T : IComparable<T>
        {
            BubbleSort<T> sorter = new BubbleSort<T>();
            return sorter.Sort(values); 
        }

        public T[] MergeSort<T>(T[] values) where T : IComparable<T>
        {
            MergeSort<T> sorter = new MergeSort<T>();
            sorter.Sort(values);
            return values;
        }

        public MovieList Load()
        {
            LoadJson.LoadJson Loader = new LoadJson.LoadJson();
            return Loader.loadMovies();
        }

        public void Save(MovieList SaveList){
            SaveJson.SaveJson Saver = new SaveJson.SaveJson();
            Saver.Save(SaveList);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadFileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadedMovies = Load();
                UpdateMovieBox(LoadedMovies);
            }
            catch (Exception)
            {
                Debug.Print("load window closed");
            }
        }

        private void SaveFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Save(LoadedMovies);
        }

        private void BTNAddMovie_Click(object sender, RoutedEventArgs e)
        {
            Movie newMovie = new Movie();
            newMovie.ID = InputMovieID.Text;
            newMovie.Title = InputMovieTitle.Text;
            newMovie.Director = InputMovieDirector.Text;
            newMovie.Genre = InputMovieGenre.Text;
            newMovie.ReleaseYear = InputMovieReleaseYear.Text;
            newMovie.Availability = InputMovieAvailability.IsChecked;

            UpdatedMovies = LoadedMovies;
            UpdatedMovies.Add(newMovie);
            UpdateMovieBox(UpdatedMovies);
        }

        private void BTNEditMovie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("file not saved");

        }
    }
}