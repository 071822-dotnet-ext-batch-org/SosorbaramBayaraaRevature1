using System;
using System.Net.Http;
namespace HTTP
{
   public class Program
    {
        static void Main(string[] args)
        {
    while(true)
        {
            Console.WriteLine("\n\nYou want to hear the truth?\nType 1 or 2.\nThen press enter.\n\n");
            string userinput = Console.ReadLine();
           if (userinput == "1")
            {
            //fetches random joke from the database
            GetRequest("http://api.icndb.com/jokes/random");
            Console.ReadKey();
            break;
            }
            else if (userinput == "2")
            {
            //fetches 2 random jokes from the db with a custome name
            GetRequest2("http://api.icndb.com/jokes/215");
            Console.ReadKey();
            break;
            }
            else if (userinput != "1" || userinput != "2")
            {
                Console.WriteLine("Error. Please input correct input.");
            }
        }
        }
        async static void GetRequest(string url)
        {
           {    //Created client object, this will initiate requests to the server.
                // SInce this client is disposable, we used code of block "Using". Once this client object in no use it will automatically dispose
                using(HttpClient client = new HttpClient())
                {
                   using (HttpResponseMessage response =  await client.GetAsync("http://api.icndb.com/jokes/random"))
                   {
                        using(HttpContent content = response.Content)
                        {
                            string myContent = await content.ReadAsStringAsync();
                            Console.WriteLine(myContent);
                        }
                   }
                }
           }
        }
        async static void GetRequest2(string url)
        {
           {    //Created client object, this will initiate requests to the server.
                // SInce this client is disposable, we used code of block "Using". Once this client object in no use it will automatically dispose
                using(HttpClient client = new HttpClient())
                {
                   using (HttpResponseMessage response =  await client.GetAsync("http://api.icndb.com/jokes/215"))
                   {
                        using(HttpContent content = response.Content)
                        {
                            string myContent = await content.ReadAsStringAsync();
                            Console.WriteLine(myContent);
                        }
                   }
                }
           }
        }
    }
}









