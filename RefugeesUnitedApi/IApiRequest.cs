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
    List<Profile> GetFavourites(int profileId);
    bool GetProfileExists(string userName);
    ProfileUnreadMessage GetUnreadMessages(int profileId);
    ProfileLoginResult ProfileLogin(string userName, string password);
    SearchResults Search(string name, int page, int limit);
    void UpdateProfile(Profile profile);
    void CompleteVerification(int profileId, string verificationCode);
    string GetEmailVerificationCode(int profileId, string email);
    string GetPhoneVerificationCode(int profileId, string dialCode, string cellPhone);
  }
}
