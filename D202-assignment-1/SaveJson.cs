using Microsoft.Win32;
using System.IO;
using System.Text.Json;

//my own classes
using MovieClasses;

namespace SaveJson
{
    class SaveJson
    {

        public void Save(MovieList? movieList = null)
        {   
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                string jsonString = JsonSerializer.Serialize(movieList);
                File.WriteAllText(saveFileDialog.FileName, jsonString);
            }
        }
    }
}
