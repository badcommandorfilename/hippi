using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Newtonsoft.Json;

namespace Hippi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        /// <summary>
        /// Configures HTTP handling. Maps any POST request to the Echo function or an error response.
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.MapWhen(context => context.Request.Method == "POST", (a) => //Maps all POST methods, regardless of URL
            {
                    a.Run(async (context) => //Handler method for HTTP Requests
                    {
                        var response = new ChatMessage { color = "red" }; //Return object
                        try
                        {
                            response = Echo(context.Request); //Get response message from Echo function
                        }
                        catch(Exception ex)
                        {
                            response.message = $"Sorry, I couldn't understand that: {ex.Message}";
                        }

                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(response)); //Write response in JSON format
                    });
                }
            );
        }

        /// <summary>
        /// Example HipChat method. Echos the message sent to your Integrations endpoint
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private ChatMessage Echo(HttpRequest request)
        {
            RoomMessage m;
            using (var r = new StreamReader(request.Body))
            {
                var b = r.ReadToEnd();
                m = JsonConvert.DeserializeObject<RoomMessage>(b);
                return new ChatMessage { message = $"You wrote {m.item.message.message}" };
            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
