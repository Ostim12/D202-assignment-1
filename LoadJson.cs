using Microsoft.Win32;
using System.IO;
using System.Text.Json;

//my own classes
using MovieClasses;

namespace LoadJson
{
    public class LoadJson
    {
        public MovieList loadMovies()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                string Json = File.ReadAllText(openFileDialog.FileName);
                if (Json == null || Json == "")
                { throw new Exception("big error"); }
                MovieList? Source = JsonSerializer.Deserialize<MovieList>(Json);
                return Source;
            }
            throw new Exception("Window Closed");
        }
    }
}
