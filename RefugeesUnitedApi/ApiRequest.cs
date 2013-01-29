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
using System.Text.RegularExpressions;

namespace RefugeesUnitedApi
{
  public class ApiRequest
  {
    private ApiRequestSettings requestSettings;

    public ApiRequest(ApiRequestSettings requestSettings)
    {
      this.requestSettings = requestSettings;
    }

    public ProfileUnreadMessage GetUnreadMessages(int profileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string endpointUrl = GenerateEndPointUri(ApiEndpointUris.Message_Unread, args);

      return IssueApiGETRequest<ProfileUnreadMessage>(endpointUrl);
    }

    public ProfileMessageCollection GetMessageCollection(int profileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string endpointUrl = GenerateEndPointUri(ApiEndpointUris.Message_Collection, args);

      return IssueApiGETRequest<ProfileMessageCollection>(endpointUrl);
    }

    public MessageThread GetMessageThread(int profileId, int targetProfileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();
      args["targetProfile"] = targetProfileId.ToString();

      string endpointUrl = GenerateEndPointUri(ApiEndpointUris.Message_View, args);

      return IssueApiGETRequest<MessageThread>(endpointUrl);
    }

    public Profile GetProfile(int profileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string endpointUrl = GenerateEndPointUri(ApiEndpointUris.Profile_View, args);

      return IssueApiGETRequest<ProfileWrapper>(endpointUrl).UserProfile;
    }

    public List<Language> GetLanguages()
    {
      string endpointUrl = GenerateEndPointUri(ApiEndpointUris.Language_Collection, new Dictionary<string, string>());

      var languageCollection = IssueApiGETRequest<LanguageCollectionWrapper>(endpointUrl);

      return languageCollection.Languages;
    }

    private string GenerateEndPointUri(string resourceTemplateUri, Dictionary<string, string> args)
    {
      StringBuilder endpointUri = new StringBuilder();

      if (requestSettings.Host[requestSettings.Host.Length - 1] == '/')
      {
        endpointUri.Append(requestSettings.Host);
      }
      else
      {
        endpointUri.Append(requestSettings.Host);
        endpointUri.Append("/");
      }

      string template = Regex.Replace(resourceTemplateUri, @"\{(.+?)\}", m => args[m.Groups[1].Value]);

      if (template[0] == '/')
      {
        endpointUri.Append(template.Substring(1));
      }
      else
      {
        endpointUri.Append(template);
      }

      return endpointUri.ToString();
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
