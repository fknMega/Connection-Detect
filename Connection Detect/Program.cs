using System;
using System.Net;
using System.Threading.Tasks;
using netstatPlus;
using Newtonsoft.Json;





namespace Connection_Detect
{
    class Program
    {
        static void Main(string[] args)
        {

            Parallel.ForEach(netclient.GetConnections(), connection =>
            {

                WebClient client = new WebClient();

                var content = client.DownloadString("http://ipwhois.app/json/" + connection.remoteaddy);
                //Console.WriteLine(content);
                dynamic json = JsonConvert.DeserializeObject(content);
                if (json.success == true)
                {

                    Console.WriteLine(connection.name + " (" + connection.pid + ")" + " >> >> " + connection.remoteaddy + " location: " + json.country + ", " + json.city + "\n");

                }


            });

            while (true) { }

        }
    }
}
