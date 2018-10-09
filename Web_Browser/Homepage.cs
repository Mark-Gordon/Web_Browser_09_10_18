using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    static class Homepage
    {

        static string homePath = Directory.GetCurrentDirectory() + Path.AltDirectorySeparatorChar + "homepage4.txt";

        public static void setNewHomepage(string url)
        {
            System.IO.File.WriteAllText(homePath, url);
            
        }

        public static string getHomepageURL()
        {

            try
            {
                File.ReadLines(homePath).First();
            }catch(Exception noFavouriteSetDefault)
            {
                setNewHomepage("https://www.google.co.uk/");
            }
         
            return File.ReadLines(homePath).First();
        }
    }
}
