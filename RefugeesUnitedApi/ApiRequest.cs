using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

      return IssueApiRequest<ProfileUnreadMessage>(endpointUrl);
    }

    public ProfileMessageCollection GetMessageCollection(int accountId)
    {
      string endpointUrl = string.Format("{0}/profile/{1}/messages", requestSettings.Host, accountId);

      return IssueApiRequest<ProfileMessageCollection>(endpointUrl);
    }

    public MessageThread GetMessageThread(int accountId, int targetAccountId)
    {
      string endpointUrl = string.Format("{0}/profile/{1}/messages/{2}", requestSettings.Host, accountId, targetAccountId);

      return IssueApiRequest<MessageThread>(endpointUrl);
    }

    public Profile GetProfile(int accountId)
    {
      string endpointUrl = string.Format("{0}/profile/{1}", requestSettings.Host, accountId);

      return IssueApiRequest<ProfileWrapper>(endpointUrl).UserProfile;
    }

    private T IssueApiRequest<T>(string endpointUrl)
    {
      using (var handler = new HttpClientHandler())
      {
        handler.Credentials = new NetworkCredential(requestSettings.UserName, requestSettings.Password);

        using (HttpClient client = new HttpClient(handler))
        {
          var response = client.GetAsync(endpointUrl).Result;

          if (response.IsSuccessStatusCode)
          {
            string json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
          }
          else
          {
            throw new Exception("Unable to process request");
          }
        }
      }
    }
  }
}
