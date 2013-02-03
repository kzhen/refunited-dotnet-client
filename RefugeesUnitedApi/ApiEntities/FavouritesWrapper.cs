using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.ApiEntities
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  internal class FavouritesWrapper
  {
    [JsonProperty(PropertyName = "favorites")]
    public List<Profile> Favourites { get; set; }
  }
}
