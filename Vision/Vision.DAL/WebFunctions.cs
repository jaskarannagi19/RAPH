using Vision.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL
{
    public static class WebFunctions
    {
        public static HttpResponseMessage CallMarkerAdminURL(string URL)
        {
            //using (var client = new HttpClient())
            //{
            var client = new HttpClient();
            //client.Timeout = new TimeSpan(0, 0, 0, 2);
            //client.BaseAddress = new Uri(CommonProperties.MarkerAdminURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = client.GetAsync(CommonProperties.MarkerAdminURL + URL).Result;
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch(AggregateException)
            {
                return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.ServiceUnavailable };
            }
            catch(Exception)
            {
                return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError };
            }
            //}

            //return result;
        }
    }
}
