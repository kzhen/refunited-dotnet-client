using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefugeesUnitedApi.ApiEntities;

namespace RefugeesUnitedApi.Tests
{
  [TestClass]
  public class ProfileIntegrationTests
  {
    public static ApiRequestSettings requestSettings = new ApiRequestSettings()
    {
      Host = "",
      UserName = "",
      Password = ""
    };

    [TestClass]
    public class ProfileInformation
    {
      [TestMethod]
      public void ShouldGetUsersProfile()
      {
        int accountId = 324784;

        ApiRequest apiRequest = new ApiRequest(requestSettings);
        Profile p = apiRequest.GetProfile(accountId);

        Assert.AreEqual("Basil", p.FirstName);
        Assert.AreEqual("Brown", p.Surname);
      }
    }
  }
}
