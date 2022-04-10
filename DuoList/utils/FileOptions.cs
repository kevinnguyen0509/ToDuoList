using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuoList.utils
{
    /// <summary>
    /// This Class is in charge of Reading and writing to internal files stored in the application
    /// </summary>
    public class FileOptions
    {
        private string iconClassPath = @"Content\Custom\textFiles\ClassIconNames.txt";

        /// <summary>
        /// This will return all the (fa fas/Awesome Icons) names so we can pass those names
        /// to the view so we can display them in the <i class="fa fas"/> using spefic names
        /// found in the file
        /// </summary>
        /// <returns>Returns a list of Icon image names</returns>
        public string[] GetAllGroceryImagesNames()
        {
            return readAllFile(iconClassPath);
        }

        /*************************Private Methods**************************/

        /// <summary>
        /// This class will take in a path file and read from it and return an array of the contents
        /// inside the file
        /// </summary>
        /// <param name="path">Takes in a string that stores the target path of a file</param>
        /// <returns>Returns an array of strings that was found in the file</returns>
        private string[] readAllFile(string path)
        {
            string[] fileArray = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + path);
            return fileArray;
        }


    }
}