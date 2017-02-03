using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace JavaScriptSerializerExample
{
    class Person {
        public string name { get; set; }
        public int age { get; set; }
        public bool Logged { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0} \nAge: {1} \nLogged: {2}", name, age,Logged);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // deserialize JSON from file
            //String JSONstring = File.ReadAllText("C:/Users/slipk/Documents/Visual Studio 2015/Projects/JavaScriptSerializerExample/JavaScriptSerializerExample/JSON.json");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Person p1 = serializer.Deserialize<Person>(JSONstring);
            //Console.WriteLine(p1);

            /* deserialize JSON from http*/
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://vertecmx.com/API/user_device?user_id=1");
            client.Headers["VERTEC-KEY"] = "qhXkNkwupto4e291116";
            Console.WriteLine(client.Headers);
            StreamReader reader = new StreamReader(stream);
            // Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());
            // Console.WriteLine((string)jObject["total_entries"]);
            //Console.WriteLine((string)jObject["albums"][0]);

            //List<string> list =JsonConvert.DeserializeObject<List<string>>(reader.Read().ToString());
            //foreach (string item in list)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(reader.ReadLine());
            
            stream.Close();
            /* OUTPUT JSON*/

            //Person p2 = new Person() { name = "Jorge", age = 18,Logged =true};
            //string outputJSON = serializer.Serialize(p2);
            //Console.WriteLine("OutputJson: "+outputJSON);
            //File.WriteAllText("Output.json", outputJSON);
        }
    }
}
