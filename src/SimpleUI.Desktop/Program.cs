// See https://aka.ms/new-console-template for more information

using System.Net;
using SimpleUI.Models;

while (true)
{
    Thread.Sleep(1000);
    var json = await GetAsync("http://localhost:5005/api/Guests/1");
    
    var guest = Newtonsoft.Json.JsonConvert.DeserializeObject<GuestModel>(json);
    
    Console.WriteLine(guest.Id +" "+ guest.FirstName + " " +  guest.LastName);
}


async Task<string> GetAsync(string uri)
{
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

    using HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
    await using Stream stream = response.GetResponseStream();
    using StreamReader reader = new StreamReader(stream);
    return await reader.ReadToEndAsync();
}
