using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi
{
  internal class ApiEndpointUris
  {
    internal const string Country_Detail = "/country/{countryId}";
    internal const string Country_Collection = "/country";
    internal const string Language_Collection = "/language";
    internal const string Message_Collection = "/profile/{profileId}/messages";
    internal const string Message_Unread = "/profile/{profileId}/unreadmessages";
    internal const string Message_View = "/profile/{profileId}/messages/{targetProfile}";
    internal const string Profile_Collection = "/profile";
    internal const string Profile_Favorites = "/profile/{profileId}/favorites";
    internal const string Profile_View = "/profile/{profileId}";
    internal const string Profile_exists = "/profile/exists/{userName}";
  }
}
