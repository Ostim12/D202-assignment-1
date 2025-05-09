using Microsoft.Win32;
using System.IO;
using System.Text.Json;

//my own classes
using MovieClasses;

namespace D202_assignment_1
{
    public class LoadJson
    {
        public static MovieList loadMovies()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                string Json = File.ReadAllText(openFileDialog.FileName);
                if (Json == null || Json == "")
                { throw new Exception("Bad file : File is Blank"); }
                MovieList? Source = JsonSerializer.Deserialize<MovieList>(Json);

                if (Source.HasDuplicateID())
                {
                    throw new Exception("Bad file : File has a duplicate ID");
                }
                return Source;
            }
            throw new Exception("Window Closed");
        }
    }
}
