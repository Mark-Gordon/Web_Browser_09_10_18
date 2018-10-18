using System;
using System.IO;
using System.Linq;
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
            saveHomepageFile();
        }

        public static string getHomepageURL()
        {
            try
            {
                return xmlDoc.ChildNodes[0].InnerText;
            }
            catch(XmlException noHomepageSetDefault)
            {
                Console.WriteLine(noHomepageSetDefault.Message + "\nSetting default homepage of google");
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
            try
            {
                xmlDoc.Save(homePath);
            }
            catch (XmlException unableToSave)
            {
                Console.WriteLine(unableToSave.Message);
            }
        }

        public static XmlDocument getXMLdoc()
        {
            return xmlDoc;
        }

        public static void checkExists()
        {
            //creates file if does not exist
            if (!File.Exists(homePath))
            {
                XmlNode rootNode = xmlDoc.CreateElement("homepage");
                xmlDoc.AppendChild(rootNode);

                setNewHomepage("www.google.com");
            }
            else
            {
                try
                {
                    xmlDoc.Load(homePath);
                }
                catch (XmlException unableToLoad)
                {
                    Console.WriteLine(unableToLoad.Message);
                }
            }
        }
    }
}
