using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefugeesUnitedApi
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class ProfileUnreadMessage
  {
    [JsonProperty(PropertyName = "unreadmessages")]
    public int UnreadMessages { get; set; }
  }
}
