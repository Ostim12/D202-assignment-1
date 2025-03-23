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

//my own namespaces
using search;
using Sorting;
using DataStructuers;
using System.Diagnostics;

namespace D202_assignment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            

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
    }

    public class Movie
    {
        public string ID { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public int? ReleaseYear { get; set; }
        public string? Availability { get; set; }

        public Movie(string movieID, string? movieTitle, string? movieDirector, string? movieGenre, int? movieReleaseYear, string? movieAvailability)
        {
            ID = movieID;
            Title = movieTitle;
            Director = movieDirector;
            Genre = movieGenre;
            ReleaseYear = movieReleaseYear;
            Availability = movieAvailability;
        }

    }
}