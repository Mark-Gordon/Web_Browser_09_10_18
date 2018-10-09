using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    static class History{

        static string path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "\\history.txt";

        private static LinkedList<string> history = new LinkedList<string>();
        public static LinkedListNode<string> current = new LinkedListNode<string>(null);




        public static string[] getHistory ()
        {
            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            return readText;
        }

        public static void clearHistory()
        {
            File.Create(path).Close();
        }


        public static bool addURL(string url)
        {

            addToHistoryFile(url);

            if (current.Value != null && !(current.Value.Equals(url)))
            {
                history.AddAfter(current, url);
                current = current.Next;
                //in the case that the user makes a search while having a forward history,
                //remove this history history
                while (!history.Last.Equals(current))
                {
                    history.RemoveLast();
                }
                return true;
            }
            else
            {
                if (current.Value == null)
                {
                    history.AddFirst(url);
                    current = history.First;
                    return true;
                }
            }
            return false;
        }

        private static void addToHistoryFile(string url)
        {
            System.IO.File.AppendAllText(path, url + Environment.NewLine);

        }

        public static void updateHistoryFile(List<string> historyList)
        {
            System.IO.File.WriteAllLines(path, historyList);
        }

        //checks if there is a previous node to go from the current one
        public static bool canGoToPrevious()
        {
            return (current.Previous != null);
        }

        //checks if there is a next node to go from the current one
        public static bool canGoToNext()
        {
            return (current.Next != null);
        }

        //sets the current node to the previous one and return the url associated with it
        public static string goToPrevious()
        {
            if (canGoToPrevious())
            {
                current = current.Previous;
                return current.Value;
            }
            else
            {
                throw new NoPreviousPageException("No previous Page to go to.");
            }
        }


        //sets the current node to the previous one and return the url associated with it
        public static string goToNext()
        {
            if (canGoToNext())
            {
                current = current.Next;
                return current.Value;
            }
            else
            {
                throw new NoNextPageException("No Next Page to go to.");
            }
        }


    }




}
