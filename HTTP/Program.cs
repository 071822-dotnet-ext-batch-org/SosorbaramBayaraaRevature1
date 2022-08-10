using System;
using System.Net.Http;
namespace HTTP
{
   public class Program
    {
        static void Main(string[] args)
        {
           GetRequest("http://api.icndb.com/jokes/random");
          Console.ReadKey();
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
    }
}