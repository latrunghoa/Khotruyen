using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KhotruyenM.Controllers
{
    public class ApiTTSController : ApiController
    {
        static void Main(string[] args)
        {

            //REST API is built on top of HTTP protocol which requires these components
            // a HTTP CLIENT to make a HTTP request to server, in this demo it's HTTPCLIENT a popular HTTP client in .net
            // a HTTP SERVER to expose resources via endpoint, in this case server endpoint is: https://api.fpt.ai and the resource endpoint is: http://api.fpt.ai/hmi/tts/v5
            // CLIENT talk to SERVER by sending a request to SERVER
            // a request includes:
            // a Endpoint: https://api.fpt.ai/hmi/tts/v5
            // a VERB like GET, POST, PUT, DELETE. in this demo the VERB POST is used which require a BODY (StringContent)
            // Headers, some API requires specific headers, some are not.
            //SERVER response to CLIENT by sending a response back to CLIENT

            //it's like postman client
            var httpClient = new HttpClient();

            //set the server url
            httpClient.BaseAddress = new Uri("https://api.fpt.ai");

            //set the header for request

            httpClient.DefaultRequestHeaders.Clear();

            httpClient.DefaultRequestHeaders.Add("voice", "myan");
            httpClient.DefaultRequestHeaders.Add("X-TTS-NoCache", "true");
            httpClient.DefaultRequestHeaders.Add("api_key", "aG1GnDQVkXrs79ikHszZfn95eKZWZE3t");

            //prepare the request's body
            var body = new StringContent("Demo Http Client");

            //send the request to server
            var result = httpClient.PostAsync("hmi/tts/v5", body).Result;

            result.EnsureSuccessStatusCode();

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);
        }
    }
}