using System;
using System.IO;
using System.Net;
using System.Text;

namespace Web_Browser
{
    public static class WebManager
    {
        //returns hmtml of web page
        public static string getHTML(string address)
        {

            try
            {
                //Will add 'http://'to beginning of search if user has not included it
                if (address.Length > 8)
                {
                    if ((!address.Substring(0, 7).Equals("http://")) && (!address.Substring(0, 8).Equals("https://")))
                    {
                        address = "http://" + address;
                    }
                }
                else
                {
                    address = "http://" + address;
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Stream used to read the response from the server
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    //checks if response is character encoded and reads stream appropriately
                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string html = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                    return html;
                }
            }
            //if no response, returns the raised exception
            catch (WebException e)
            {
                var response = e.Response as HttpWebResponse;

                if (response != null) { 
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            return "400 Bad Request";
                        case HttpStatusCode.Forbidden:
                            return "403 Forbidden";
                        case HttpStatusCode.NotFound:
                            return "404 Not Found";
                    }
                }
            }
            catch (UriFormatException e)
            {
                return e.Message;
            }
            //thrown when there is an attempt to read, seek, or write to a stream that does not support
            //the invoked functionality.
            catch (NotSupportedException e)
            {
                return e.Message;
            }
            return "An unidentified error has occured.";
        }
    }
}