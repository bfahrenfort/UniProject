using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace UniProject.Utils
{
    class APIConn
    {
        private const String uri = "https://uniprojecttest.azurewebsites.net/";

        //Returns a JSON format string 
        public static string Request(string ApiCallString)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "/" + ApiCallString);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json; charset=utf-8";

            var response =  (HttpWebResponse)httpWebRequest.GetResponse();

            string resString;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                resString = sr.ReadToEnd();
            }

            return resString;
        }

        //Returns a http response code
        //Still needs to be properly implemented into API, just use request above and parse data
        public static HttpWebResponse Post(string ApiCallString)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + "/" + ApiCallString);
            httpWebRequest.Method = WebRequestMethods.Http.Post;
            httpWebRequest.Accept = "application/json; charset=utf-8";

            return (HttpWebResponse)httpWebRequest.GetResponse();
        }
    }
}