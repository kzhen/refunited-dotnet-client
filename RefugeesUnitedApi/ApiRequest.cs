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
using RefugeesUnitedApi.JsonConverters;

namespace RefugeesUnitedApi
{
  public class ApiRequest : IApiRequest
  {
    private ApiRequestSettings requestSettings;
    private ApiHttpRequest apiHttpRequester;

    public ApiRequest(ApiRequestSettings requestSettings)
    {
      if (requestSettings == null)
      {
        throw new ArgumentNullException("requestSettings");
      }

      this.requestSettings = requestSettings;
      this.apiHttpRequester = new ApiHttpRequest(requestSettings);
    }

    public ProfileUnreadMessage GetUnreadMessages(int profileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Message_Unread, requestSettings, args);

      return apiHttpRequester.IssueApiGETRequest<ProfileUnreadMessage>(endpointUrl);
    }

    public ProfileMessageCollection GetMessageCollection(int profileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Message_Collection, requestSettings, args);

      return apiHttpRequester.IssueApiGETRequest<ProfileMessageCollection>(endpointUrl);
    }

    public MessageThread GetMessageThread(int profileId, int targetProfileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();
      args["targetProfile"] = targetProfileId.ToString();

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Message_View, requestSettings, args);

      return apiHttpRequester.IssueApiGETRequest<MessageThread>(endpointUrl);
    }

    public Profile GetProfile(int profileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Profile_View, requestSettings, args);

      return apiHttpRequester.IssueApiGETRequest<ProfileWrapper>(endpointUrl).UserProfile;
    }

    public List<Profile> GetFavourites(int profileId)
    {
      Dictionary<string, string> args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string endPointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Profile_Favorites, requestSettings, args);

      var result = apiHttpRequester.IssueApiGETRequest<FavouritesWrapper>(endPointUrl);

      return result.Favourites;
    }

    public List<Language> GetLanguages()
    {
      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Language_Collection, requestSettings, new Dictionary<string, string>());

      var languageCollection = apiHttpRequester.IssueApiGETRequest<LanguageCollectionWrapper>(endpointUrl);

      return languageCollection.Languages;
    }

    public List<Country> GetCountries()
    {
      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Country_Collection, requestSettings, new Dictionary<string, string>());

      var countries = apiHttpRequester.IssueApiGETRequest<List<Country>>(endpointUrl);

      return countries;
    }

    public bool GetProfileExists(string userName)
    {
      var args = new Dictionary<string, string>();
      args["userName"] = userName;

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Profile_exists, requestSettings, args);

      object result = apiHttpRequester.IssueApiGETRequest<object>(endpointUrl);

      return ((Newtonsoft.Json.Linq.JContainer)result)["exists"].ToString() == "True";
    }

    public ProfileLoginResult ProfileLogin(string userName, string password)
    {
      var args = new Dictionary<string, string>();
      args["userName"] = userName;
      args["password"] = password;

      string endPointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Profile_login, requestSettings, args);

      var loginResult = apiHttpRequester.IssueApiGETRequest<ProfileLoginResult>(endPointUrl);

      return loginResult;
    }

    public SearchResults Search(string name, int page = 0, int limit = 10)
    {
      var args = new Dictionary<string, string>();
      args["name"] = name;
      args["page"] = page.ToString();
      args["limit"] = limit.ToString();

      string endPointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Search, requestSettings, args);

      var results = apiHttpRequester.IssueApiGETRequest<SearchResults>(endPointUrl);

      return results;
    }

    public void UpdateProfile(Profile profile)
    {
      if (profile == null)
      {
        throw new ArgumentNullException("profile");
      }
      if (profile.ProfileId <= 0)
      {
        throw new ArgumentException("profileId must be specified");
      }

      var args = new Dictionary<string, string>();
      args["profileId"] = profile.ProfileId.ToString();

      string endPointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Profile_View, requestSettings, args);

      var putContent = new Dictionary<string, string>();
      putContent["primaryEmail"] = profile.Email;
      putContent["givenName"] = profile.FirstName;
      putContent["surName"] = profile.Surname;
      putContent["dialCode"] = profile.DialCode;
      putContent["cellPhone"] = profile.CellPhoneNumber;
      putContent["countryOfBirthId"] = profile.CountryOfBirthId.Value.ToString();

      var result = apiHttpRequester.IssueApiPUTRequest<Profile>(endPointUrl, putContent);
    }

    public void CompleteVerification(int profileId, string verificationCode)
    {
    }

    public EmailVerificationToken GetEmailVerificationCode(int profileId, string email)
    {
      var postData = new List<KeyValuePair<string, string>>();
      postData.Add(new KeyValuePair<string, string>("userProfileId", profileId.ToString()));
      postData.Add(new KeyValuePair<string, string>("email", email));

      HttpContent postContent = new FormUrlEncodedContent(postData);

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Verification_email, requestSettings, new Dictionary<string,string>());

      var response = apiHttpRequester.IssueApiPOSTRequest<EmailVerificationToken>(endpointUrl, postContent);

      return response;
    }

    public PhoneVerificationToken GetPhoneVerificationCode(int profileId, string dialCode, string cellPhone)
    {
      var postData = new List<KeyValuePair<string, string>>();
      postData.Add(new KeyValuePair<string, string>("userProfileId", profileId.ToString()));
      postData.Add(new KeyValuePair<string, string>("dialCode", dialCode));
      postData.Add(new KeyValuePair<string, string>("cellPhone", cellPhone));

      HttpContent postContent = new FormUrlEncodedContent(postData);

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Verification_phone, requestSettings, new Dictionary<string, string>());

      var response = apiHttpRequester.IssueApiPOSTRequest<PhoneVerificationToken>(endpointUrl, postContent);

      return response;
    }
    
    public bool AddProfileFavourite(int profileId, int targetProfileId)
    {
      var postData = new List<KeyValuePair<string, string>>();
      postData.Add(new KeyValuePair<string,string>("targetProfileId", targetProfileId.ToString()));

      HttpContent postContent = new FormUrlEncodedContent(postData);

      var parameters = new Dictionary<string,string>();
      parameters.Add("profileId", profileId.ToString());

      string endpointUrl = ApiEndpointUris.GenerateEndPointUri(ApiEndpointUris.Profile_Favorites, requestSettings, parameters);

      var response = apiHttpRequester.IssueApiPOSTRequest<object>(endpointUrl, postContent);

      return true;
    }
  }
}
