using System;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace Http_Listener_Exploration.Models.Listener;

public class WebServer
{
    private HttpListener _listener;
    private string _folder = "./wwwroot";

    public WebServer(string uriPrefix, string? rootFolder = null)
    {
        //Vi må lage, så adde prefix i to steps.

        //1. pass på at _listener refererer til et faktisk objekt.
        _listener = new();

        //2. legg til prefix til prefixes.
        _listener.Prefixes.Add(uriPrefix);


        if (!string.IsNullOrWhiteSpace(rootFolder)) _folder = rootFolder;
    }

    public async Task StartListener()
    {
        _listener.Start();

        while(true)
        {
            try
            {
                var context = await _listener.GetContextAsync();
                switch (context.Request.HttpMethod)
                {
                    case "GET": 
                        await ProcessGetRequestAsync(context);
                        break;
                    case "POST":
                        await ProcessPostRequest(context);
                        break;
                    default:
                        break;
                }
            }
            catch(HttpListenerException) {break;}
            catch(ArgumentException){break;}
        }

    }

    public void Stop() => _listener.Stop(); 

    private async Task ProcessGetRequestAsync(HttpListenerContext context)
    {
        try
        {
            var fileName = Path.GetFileName(context.Request.RawUrl);
            var filePath = Path.Combine(_folder, fileName!);

            byte[] responseMessage;

            if (!File.Exists(filePath))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                responseMessage = Encoding.UTF8.GetBytes($"Sorry, {fileName} is not available...");
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                responseMessage = await File.ReadAllBytesAsync(filePath);
            }

            context.Response.ContentLength64 = responseMessage.Length;
            context.Response.ContentType = GetMIMEstringForFile(fileName!);
            context.Response.ContentEncoding = Encoding.UTF8;

            using var output = context.Response.OutputStream;
            await output.WriteAsync(responseMessage);

        } catch(ArgumentException)
        {
            throw;
        }
    }

    private async Task ProcessPostRequest(HttpListenerContext context)
    {
        try
        {
            var request = context.Request;
            var response = context.Response;

            byte[] responseMessage;


            if (!request.HasEntityBody)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                responseMessage = Encoding.UTF8.GetBytes("Cannot process request, missing request body");
            }
            else
            {
                var fileName = request.Headers["x-filename"] ?? $"data-{DateTime.UtcNow:t}.txt";

                using var memStream = new MemoryStream();

                await request.InputStream.CopyToAsync(memStream);

                var filePath = Path.Combine(_folder, fileName);

                await File.WriteAllBytesAsync(filePath, memStream.ToArray());

                response.StatusCode = (int)HttpStatusCode.Created;
                responseMessage = Encoding.UTF8.GetBytes($"'message':'sucessfully saved file.','path':'{fileName}'");
                response.ContentType = "application/json";
            }
            response.ContentLength64 = responseMessage.Length;
            using var output = response.OutputStream;
            await output.WriteAsync(responseMessage);
        } catch (ArgumentNullException){throw;}
    }

    private string GetMIMEstringForFile(string fileName) => fileName.Split(".")[1] switch
    {
        "html" => "text/html",
        "txt" => "text/plain",
        _ => "text/plain"
    };


}
