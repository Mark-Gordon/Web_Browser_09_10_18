using System;
using System.Collections.Generic;
using System.IO;
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
            //creates file if does not exist
            if (!File.Exists(historyPath))
            {
                XmlNode rootNode = xmlDoc.CreateElement("historys");
                xmlDoc.AppendChild(rootNode);

                saveHistoryFile();
            }
            else
            {
                try
                {
                    xmlDoc.Load(historyPath);
                }
                catch (XmlException unableToLoad)
                {
                    Console.WriteLine(unableToLoad.Message);
                }
            }

        }

        public static void saveHistoryFile()
        {
            try
            {
                xmlDoc.Save(historyPath);
            }catch(XmlException unableToSave)
            {
                Console.WriteLine(unableToSave.Message);
            }

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

            //First coniditon check:
            // 1) Because you can’t call the ‘AddAfter’ method if there isn’t already a value in the linked list
            //2) If the current value is equal to the URL there is no need to add it again
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
            XmlNode historyNode = xmlDoc.CreateElement("history");

            historyNode.InnerText = url;
            rootNode.AppendChild(historyNode);
            saveHistoryFile();



        }



        public static bool canGoToPrevious()
        {
            return (current.Previous != null);
        }

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
                throw new NoPreviousPageException("No previous page to go to.");
            }
        }


        //sets the current node to the next one and return the url associated with it
        public static string goToNext()
        {
            if (canGoToNext())
            {
                current = current.Next;
                return current.Value;
            }
            else
            {
                throw new NoNextPageException("No next page to go to.");
            }
        }

        public static XmlDocument getXMLdoc()
        {
            return xmlDoc;
        }


    }




}
