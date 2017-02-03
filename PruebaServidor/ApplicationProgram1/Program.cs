using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace ApplicationProgram1
{
    public  class Person {
        public static string[] description = {"minimo","poco", "moderado", "grave", "extremo" };
        public static string user_id="1";
        public static string timeIn= "04/12/2016 18:27:54";
        public static string timeOut= "04/12/2016 18:28:20";
        public static string danio="1";
        public static string meanprocessed= "84.07907";
        public static string meanfilled= "107.931808";
        public static string entropyprocessed= "1.89837229";
        public static string entropyfilled= "1.69621468";
        public static string imei= "35219030";
        public static string fabricante= "Sony";
        public static string modelo= "E5803";
        public static string version= "6.0.1";
        public static string serial= "CB5A28YDSR";
        public static string type = "Smartphone";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> datos = new Dictionary<string, string>();
            datos.Add("user_id", Person.user_id);
            datos.Add("timeIn", Person.timeIn);
            datos.Add("timeOut", Person.timeOut);
            datos.Add("danio", Person.danio);
            datos.Add("meanprocessed", Person.meanprocessed);
            datos.Add("meanfilled", Person.meanfilled);
            datos.Add("entropyprocessed", Person.entropyprocessed);
            datos.Add("entropyfilled", Person.entropyfilled);
            datos.Add("imei", Person.imei);
            datos.Add("fabricante", Person.fabricante);
            datos.Add("modelo", Person.modelo);
            datos.Add("version", Person.version);
            datos.Add("serial", Person.serial);
            datos.Add("type", Person.type);
            datos.Add("description", Person.description[0]);
            HttpPostRequest("http://www.vertecmx.com/API/user_device", datos);
            Console.Read();
        }
        private static void HttpPostRequest(string url, Dictionary<string, string> postParameters)
        {
            string postData = "";
            foreach (string key in postParameters.Keys)
            { postData+=HttpUtility.UrlEncode(key)+"="+HttpUtility.UrlEncode(postParameters[key])+"&";}
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            byte[] data = Encoding.ASCII.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Headers.Add("VERTEC-KEY", "qhXkNkwupto4e291116");
            Stream responseStream = request.GetRequestStream();
            responseStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            JObject jObject = JObject.Parse(reader.ReadLine());
            string responsejson = ((string )jObject["response"]);
            Console.WriteLine("Response from server: "+responsejson);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            stream.Close();
            response.Close();
            responseStream.Close();
        }
    }
}