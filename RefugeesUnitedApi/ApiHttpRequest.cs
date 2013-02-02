using Newtonsoft.Json;
using RefugeesUnitedApi.Exceptions;
using RefugeesUnitedApi.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi
{
  internal class ApiHttpRequest
  {
    private ApiRequestSettings requestSettings;
    private JsonSerializerSettings jsonSerializerSettings;

    internal ApiHttpRequest(ApiRequestSettings settings)
    {
      this.requestSettings = settings;

      this.jsonSerializerSettings = new JsonSerializerSettings();
      this.jsonSerializerSettings.Converters.Add(new CountriesConverter());
    }

    internal T IssueApiDELETERequest<T>(string endPointUrl)
    {
      using (var handler = new HttpClientHandler())
      {
        handler.Credentials = new NetworkCredential(requestSettings.UserName, requestSettings.Password);

        using (var client = new HttpClient(handler))
        {
          var content = new StringContent("");

          var response = client.DeleteAsync(endPointUrl).Result;

          if (response.IsSuccessStatusCode)
          {
            string json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
          }
          else
          {
            switch (response.StatusCode)
            {
              case HttpStatusCode.BadRequest:
                throw new InvalidParameterException("Invalid parameters");
              case HttpStatusCode.MethodNotAllowed:
                throw new NoDeleteException("This method is not accepted for this API call.");
            }
            throw new Exception("Unable to process request");
          }
        }
      }
    }

    internal T IssueApiPUTRequest<T>(string endPointUrl, Dictionary<string, string> putContent)
    {
      using (var handler = new HttpClientHandler())
      {
        handler.Credentials = new NetworkCredential(requestSettings.UserName, requestSettings.Password);

        using (var client = new HttpClient(handler))
        {
          var postData = new List<KeyValuePair<string, string>>();
          foreach (var item in putContent)
          {
            postData.Add(new KeyValuePair<string, string>(item.Key, item.Value));            
          }

          HttpContent content = new FormUrlEncodedContent(postData); 

          var response = client.PutAsync(endPointUrl, content).Result;

          if (response.IsSuccessStatusCode)
          {
            string json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
          }
          else
          {
            switch (response.StatusCode)
            {
              case HttpStatusCode.BadRequest:
                throw new InvalidParameterException("Invalid parameters");
              case HttpStatusCode.MethodNotAllowed:
                throw new NoPutException("This method is not accepted for this API call.");
            }
            throw new Exception("Unable to process request");
          }
        }
      }
    }

    internal T IssueApiPOSTRequest<T>(string endPointUrl)
    {
      using (var handler = new HttpClientHandler())
      {
        handler.Credentials = new NetworkCredential(requestSettings.UserName, requestSettings.Password);

        using (HttpClient client = new HttpClient(handler))
        {
          HttpContent content = new StringContent(""); //TODO: allow the passing in of the content

          var response = client.PostAsync(endPointUrl, content).Result;

          if (response.IsSuccessStatusCode)
          {
            string json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
          }
          else
          {
            switch (response.StatusCode)
            {
              case HttpStatusCode.BadRequest:
                throw new InvalidParameterException("Invalid parameters");
              case HttpStatusCode.MethodNotAllowed:
                throw new NoPostException("This method is not accepted for this API call.");
            }
            throw new Exception("Unable to process request");
          }
        }
      }
    }

    internal T IssueApiGETRequest<T>(string endPointUrl)
    {
      using (var handler = new HttpClientHandler())
      {
        handler.Credentials = new NetworkCredential(requestSettings.UserName, requestSettings.Password);

        using (HttpClient client = new HttpClient(handler))
        {
          var response = client.GetAsync(endPointUrl).Result;

          if (response.IsSuccessStatusCode)
          {
            string json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(json, this.jsonSerializerSettings);

            return result;
          }
          else
          {
            switch (response.StatusCode)
            {
              case HttpStatusCode.BadRequest:
                throw new InvalidParameterException("Invalid parameters");
            }
            throw new Exception("Unable to process request");
          }
        }
      }
    }
  }
}
