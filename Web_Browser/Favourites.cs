using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    static class Favourites
    {

        static string favouritePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "favourites.txt";


        public static string[] getFaves()
        {
            string[] faveArray = File.ReadAllLines(favouritePath, Encoding.UTF8);
            return faveArray;
        }


        public static void addToFavouritesFile(string url, string name)
        {
            System.IO.File.AppendAllText(favouritePath, url + " " + name + Environment.NewLine);

        }

        public static void setFavouritesFile(List<string> favesList)
        {

            System.IO.File.WriteAllLines(favouritePath, favesList);
        }

        public static void clearFavouritesFile()
        {
            File.Create(favouritePath).Close();
        }

    }
}
