using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefugeesUnitedApi
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class MessageThread
  {
    [JsonProperty(PropertyName = "totalMessageCount")]
    public int TotalMessageCount { get; set; }

    [JsonProperty(PropertyName = "targetProfile")]
    public TargetProfile TargetProfile { get; set; }

    [JsonProperty(PropertyName = "messages")]
    public IDictionary<int, Message> Messages { get; set; }
  }

  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class TargetProfile
  {
    [JsonProperty(PropertyName = "profileId")]
    public int ProfileId { get; set; }

    [JsonProperty(PropertyName = "givenName")]
    public string GivenName { get; set; }

    [JsonProperty(PropertyName = "surName")]
    public string Surname { get; set; }
  }

  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Message
  {
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "body")]
    public string Body { get; set; }

    [JsonProperty(PropertyName = "sendDate")]
    public string SendDate { get; set; }

    [JsonProperty(PropertyName = "messageDirection")]
    public string MessageDirection { get; set; }
  }
}
