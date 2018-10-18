using System;
using System.IO;
using System.Xml;

namespace Web_Browser
{
    static class Favourites
    {
        static string favouritePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "favourites.xml";
        static XmlDocument xmlDoc = new XmlDocument();

        public static XmlNodeList getFaves()
        {
            XmlNodeList favouriteNodes = xmlDoc.SelectNodes("//favourites/favourite");

            return favouriteNodes;
        }


        public static void addToFavouritesFile(string url, string name)
        {
            XmlNode rootNode = xmlDoc.DocumentElement;

            XmlNode faveNode = xmlDoc.CreateElement("favourite");
            faveNode.InnerText = url;
            XmlAttribute attribute = xmlDoc.CreateAttribute("name");
            attribute.Value = name;
            faveNode.Attributes.Append(attribute);
            rootNode.AppendChild(faveNode);
            saveFavouritesFile();
        }

        public static void clearFavouritesFile()
        {
            xmlDoc.DocumentElement.RemoveAll();
            saveFavouritesFile();
        }

        public static void saveFavouritesFile()
        {
            try
            {
                xmlDoc.Save(favouritePath);
            } catch (XmlException unableToSave) {
                Console.WriteLine(unableToSave.Message);
            }
          
        }

       

        public static void checkExists()
        {
            //creates file if does not exist
            if (!File.Exists(favouritePath))
            {
                XmlNode rootNode = xmlDoc.CreateElement("favourites");
                xmlDoc.AppendChild(rootNode);

                saveFavouritesFile();
            }
            else
            {
                try
                {
                    xmlDoc.Load(favouritePath);
                }catch(XmlException unableToLoad)
                {
                    Console.WriteLine(unableToLoad.Message);
                }
            }
              
        }

        public static XmlDocument getXMLdoc()
        {
            return xmlDoc;
        }

 
    }
}
