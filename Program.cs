using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class MinimalRepro
{
    static async Task Main()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8089/");
        listener.Start();

        // Start async pattern
        listener.BeginGetContext(ar =>
        {
            try
            {
                var context = listener.EndGetContext(ar); // FAILS HERE
                context.Response.StatusCode = 200;
                context.Response.Close();
            }
            catch (HttpListenerException e)
            {
                Console.WriteLine($"ERROR: {e.ErrorCode} - {e.Message}");
            }
        }, null);

        await Task.Delay(200);

        // Trigger the error
        using var client = new HttpClient();
        await client.GetAsync("http://localhost:8089/");

        listener.Stop();
    }
}
