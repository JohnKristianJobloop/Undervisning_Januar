// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design.Serialization;
using System.Net;
using System.Text;

Console.WriteLine("Hello, World!");

var listener = new HttpListener();

listener.Prefixes.Add("http://localhost:9001/");

listener.Start();

var context = await listener.GetContextAsync();

var responseMessage = "Recieved context...";

var byteCount = Encoding.UTF8.GetByteCount(responseMessage);

context.Response.ContentLength64 = byteCount;

context.Response.ContentEncoding = Encoding.UTF8;

context.Response.ContentType = "text/plain";

context.Response.StatusCode = (int)HttpStatusCode.OK;

using var output = context.Response.OutputStream;

await output.WriteAsync(Encoding.UTF8.GetBytes(responseMessage));

listener.Close();
