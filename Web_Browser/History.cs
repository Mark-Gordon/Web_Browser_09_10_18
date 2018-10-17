using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Web_Browser
{
    static class History{

        static string historyPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "\\history.xml";
        static XmlDocument xmlDoc = new XmlDocument();

        private static LinkedList<string> history = new LinkedList<string>();
        public static LinkedListNode<string> current = new LinkedListNode<string>(null);


        public static void checkExists()
        {
            if (!File.Exists(historyPath))
            {
                XmlNode rootNode = xmlDoc.CreateElement("historys");
                xmlDoc.AppendChild(rootNode);

                xmlDoc.Save(historyPath);

            }
            else
            {
                xmlDoc.Load(historyPath);
            }

        }

        public static void saveHistoryFile()
        {
            xmlDoc.Save(historyPath);

        }


        public static XmlNodeList getHistory()
        {

            XmlNodeList favouriteNodes = xmlDoc.SelectNodes("//historys/history");


            return favouriteNodes;
        }

        public static void clearHistoryFile()
        {

            xmlDoc.DocumentElement.RemoveAll();
            saveHistoryFile();
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

        public static void addToHistoryFile(string url)
        {

            XmlNode rootNode = xmlDoc.DocumentElement;
            // System.IO.File.AppendAllText(favouritePath, url + " " + name + Environment.NewLine);
            XmlNode historyNode = xmlDoc.CreateElement("history");

            historyNode.InnerText = url;
            rootNode.AppendChild(historyNode);
            xmlDoc.Save(historyPath);



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

        public static XmlDocument getXMLdoc()
        {
            return xmlDoc;
        }


    }




}
