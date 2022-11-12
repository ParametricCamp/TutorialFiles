using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace dalle_api
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This example is part of the `Fun with Dall-E` video tutorial series
            // at ParametricCamp: https://www.youtube.com/playlist?list=PLx3k0RGeXZ_zs3az0Z2BnpTIPH2lxQfFX

            string url = "https://api.openai.com/v1/images/generations";
            string bearerToken = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            //string body = "{\"prompt\": \"an isometric view of a miniature city, tilt shift, bokeh, voxel, vray render, high detail\",\"n\": 2,\"size\": \"1024x1024\"}";
            string body = "{\"prompt\": \"an isometric view of a miniature city, tilt shift, bokeh, voxel, vray render, high detail\",\"n\": 2,\"size\": \"256x256\",\"response_format\":\"b64_json\"}";

            // Prepare data for the POST request
            var data = Encoding.ASCII.GetBytes(body);
            Console.WriteLine(data);

            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            // Authentication
            if (bearerToken != null)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + bearerToken);
            }
            else
            {
                request.Credentials = CredentialCache.DefaultCredentials;
            }

            // Perform request
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            // Retrieve response
            var response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine("Request response: " + response.StatusCode);

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //Console.WriteLine(responseString);


            // Deserialize JSON
            dynamic responseJson = JsonConvert.DeserializeObject<dynamic>(responseString);

            ////Console.WriteLine(responseJson);
            //Console.WriteLine(responseJson.created);
            //Console.WriteLine(responseJson.data);
            //Console.WriteLine(responseJson.data[0].url);
            //Console.WriteLine(responseJson.data[1].url);

            for (int i =0; i < responseJson.data.Count; i++)
            {
                string base64 = responseJson.data[i].b64_json;
                //Console.WriteLine(base64);

                Bitmap img = Base64StringToBitmap(base64);

                long unixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
                string filename = string.Format("image_{0}_{1}.png", unixTime, i);

                img.Save(filename);
                Console.WriteLine("Saving image to " + filename);
            }

            Console.ReadKey();
        }

        // From https://softwarebydefault.com/2013/03/01/base64-strings-bitmap/
        public static Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }
    }
}
