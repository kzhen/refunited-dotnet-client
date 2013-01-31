using RefugeesUnitedApi.ApiEntities;
using System;
using System.Collections.Generic;
namespace RefugeesUnitedApi
{
  public interface IApiRequest
  {
    List<Country> GetCountries();
    List<Language> GetLanguages();
    ProfileMessageCollection GetMessageCollection(int profileId);
    MessageThread GetMessageThread(int profileId, int targetProfileId);
    Profile GetProfile(int profileId);
    bool GetProfileExists(string userName);
    ProfileUnreadMessage GetUnreadMessages(int profileId);
  }
}
