using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Web_Browser
{
    static class Homepage
    {

        static string homePath = Directory.GetCurrentDirectory() + Path.AltDirectorySeparatorChar + "homepage.xml";
        static XmlDocument xmlDoc = new XmlDocument();

        public static void setNewHomepage(string url)
        {
            clearHomepageFile();

            XmlNode rootNode = xmlDoc.DocumentElement;

            XmlNode homeNode = xmlDoc.CreateElement("home");
            homeNode.InnerText = url;

            rootNode.AppendChild(homeNode);
            xmlDoc.Save(homePath);

        }

        public static string getHomepageURL()
        {

            try
            {
                return xmlDoc.ChildNodes[0].InnerText;
            }
            catch(Exception noFavouriteSetDefault)
            {
                setNewHomepage("https://www.google.co.uk/");
            }
         
            return File.ReadLines(homePath).First();
        }

        public static void clearHomepageFile()
        {

            xmlDoc.DocumentElement.RemoveAll();
            saveHomepageFile();
        }

        public static void saveHomepageFile()
        {
            xmlDoc.Save(homePath);

        }

        public static XmlDocument getXMLdoc()
        {
            return xmlDoc;
        }

        public static void checkExists()
        {
            if (!File.Exists(homePath))
            {
                XmlNode rootNode = xmlDoc.CreateElement("homepage");
                xmlDoc.AppendChild(rootNode);


                setNewHomepage("www.google.com");

            }
            else
            {
                xmlDoc.Load(homePath);
            }

        }
    }
}
