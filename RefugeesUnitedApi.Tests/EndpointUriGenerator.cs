using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RefugeesUnitedApi.Tests
{
  [TestClass]
  public class EndpointUriGenerator
  {
    [TestMethod]
    public void ShouldGenerateValidUri()
    {
      int profileId = 1234;
      string Profile_View = "/profile/{profileId}";

      var args = new Dictionary<string, string>();
      args["profileId"] = profileId.ToString();

      string result = GetEndpointUrl(Profile_View, args); ;

      Assert.AreEqual("http://api.somehost.com/profile/1234", result);
    }

    private string GetEndpointUrl(string resourceTemplateUri, Dictionary<string, string> parameters)
    {
      string host = "http://api.somehost.com";

      StringBuilder endpointUri = new StringBuilder();
      endpointUri.Append(host);

      endpointUri.Append(Regex.Replace(resourceTemplateUri, @"\{(.+?)\}", m => parameters[m.Groups[1].Value]));

      return endpointUri.ToString();
    }
  }
}
