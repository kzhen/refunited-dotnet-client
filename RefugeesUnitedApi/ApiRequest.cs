using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RefugeesUnitedApi.ApiEntities;
using RefugeesUnitedApi.Exceptions;

namespace RefugeesUnitedApi
{
  public class ApiRequest
  {
    private ApiRequestSettings requestSettings;

    public ApiRequest(ApiRequestSettings requestSettings)
    {
      this.requestSettings = requestSettings;
    }

    public ProfileUnreadMessage GetUnreadMessages(int accountId)
    {
      string endpointUrl = string.Format("{0}/profile/{1}/unreadmessages", requestSettings.Host, accountId);

      return IssueApiGETRequest<ProfileUnreadMessage>(endpointUrl);
    }

    public ProfileMessageCollection GetMessageCollection(int accountId)
    {
      string endpointUrl = string.Format("{0}/profile/{1}/messages", requestSettings.Host, accountId);

      return IssueApiGETRequest<ProfileMessageCollection>(endpointUrl);
    }

    public MessageThread GetMessageThread(int accountId, int targetAccountId)
    {
      string endpointUrl = string.Format("{0}/profile/{1}/messages/{2}", requestSettings.Host, accountId, targetAccountId);

      return IssueApiGETRequest<MessageThread>(endpointUrl);
    }

    public Profile GetProfile(int accountId)
    {
      string endpointUrl = string.Format("{0}/profile/{1}", requestSettings.Host, accountId);

      return IssueApiGETRequest<ProfileWrapper>(endpointUrl).UserProfile;
    }

    private T IssueApiDELETERequest<T>(string endPointUrl)
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

    private T IssueApiPUTRequest<T>(string endPointUrl)
    {
      using (var handler = new HttpClientHandler())
      {
        handler.Credentials = new NetworkCredential(requestSettings.UserName, requestSettings.Password);

        using (var client = new HttpClient(handler))
        {
          var content = new StringContent("");
          
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

    private T IssueApiPOSTRequest<T>(string endPointUrl)
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

    private T IssueApiGETRequest<T>(string endPointUrl)
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
            var result = JsonConvert.DeserializeObject<T>(json);

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
