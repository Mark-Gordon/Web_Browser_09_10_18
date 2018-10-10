using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
           // System.IO.File.AppendAllText(favouritePath, url + " " + name + Environment.NewLine);
            XmlNode faveNode = xmlDoc.CreateElement("favourite");
            faveNode.InnerText = url;
            XmlAttribute attribute = xmlDoc.CreateAttribute("name");
            attribute.Value = name;
            faveNode.Attributes.Append(attribute);
            rootNode.AppendChild(faveNode);
            xmlDoc.Save(favouritePath);



        }

        public static void clearFavouritesFile()
        {

            xmlDoc.DocumentElement.RemoveAll();
            saveFavouritesFile();
        }

        public static void saveFavouritesFile()
        {
            xmlDoc.Save(favouritePath);
          
        }

       

        public static void checkExists()
        {
            if (!File.Exists(favouritePath))
            {
                XmlNode rootNode = xmlDoc.CreateElement("favourites");
                xmlDoc.AppendChild(rootNode);
             
                xmlDoc.Save(favouritePath);

            }
            else
            {
                xmlDoc.Load(favouritePath);
            }
              
        }

        public static XmlDocument getXMLdoc()
        {
            return xmlDoc;
        }

 
    }
}
