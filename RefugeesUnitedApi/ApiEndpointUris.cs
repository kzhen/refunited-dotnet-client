using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi
{
  internal class ApiEndpointUris
  {
    internal const string Country_Detail = "/country/:countryid";
    internal const string Country_Collection = "/country";
    internal const string Language_Collection = "/language";
    internal const string Message_Collection = "/profile/:profileid/messages";
    internal const string Message_Unread = "/profile/:profileid/unreadmessages";
    internal const string Message_View = "/profile/:profileid/messages/:profileid2";
    internal const string Profile_Collection = "/profile";
    internal const string Profile_Favorites = "/profile/:profileid/favorites";
    internal const string Profile_View = "/profile/:profileid";
  }
}
