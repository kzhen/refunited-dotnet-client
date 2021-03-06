﻿using System;
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
    };

    [TestClass]
    public class ProfileFavouritesTests
    {
      [TestMethod]
      public void ShouldReturnAListOfFavourites()
      {
        int profileId = 324784;

        ApiRequest request = new ApiRequest(requestSettings);

        var result = request.GetFavourites(profileId);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
      }
    }

    [TestClass]
    public class ProfileUpdateTests
    {
      [TestMethod]
      public void ShouldUpdateProfile()
      {
        int profileId = 324784;

        Profile profile = new Profile()
        {
          ProfileId = profileId,
          FirstName = "Basil",
          Surname = "Brown",
          Email = "refugee1@kenpire.com",
          DialCode = "+44",
          CellPhoneNumber = "123456"
        };

        ApiRequest apiRequest = new ApiRequest(requestSettings);

        apiRequest.UpdateProfile(profile);

        var selectedProfile = apiRequest.GetProfile(profileId);

        Assert.AreEqual("Basil", selectedProfile.FirstName);
        Assert.AreEqual("Brown", selectedProfile.Surname);
        Assert.AreEqual("refugee1@kenpire.com", selectedProfile.Email);
        Assert.AreEqual("+44", selectedProfile.DialCode);
        Assert.AreEqual("123456", selectedProfile.CellPhoneNumber);
      }
    }

    [TestClass]
    public class SearchTests
    {
      [TestMethod]
      public void ShouldSearchForAUser()
      {
        string name = "basil brown";

        ApiRequest apiRequest = new ApiRequest(requestSettings);

        var results = apiRequest.Search(name);

        Assert.IsNotNull(results);
      }
    }

    [TestClass]
    public class ProfileLoginTests
    {
      [TestMethod]
      public void ShouldLoginTheUser()
      {
        string username = "basil123";
        string password = "Passw0rd";

        ApiRequest apiRequest = new ApiRequest(requestSettings);

        var result = apiRequest.ProfileLogin(username, password);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Authenticated, "User is not authenticated");
      }
    }

    [TestClass]
    public class ProfileExists
    {
      [TestMethod]
      public void ShouldCheckIfAccountExists()
      {
        string username = "Basil123";

        ApiRequest apiRequest = new ApiRequest(requestSettings);

        var exists = apiRequest.GetProfileExists(username);

        Assert.AreEqual(true, exists);
      }

      [TestMethod]
      public void ShouldCheckIfAccountDoesntExists()
      {
        string username = "asdddddss234234234";

        ApiRequest apiRequest = new ApiRequest(requestSettings);

        var exists = apiRequest.GetProfileExists(username);

        Assert.AreEqual(false, exists);
      }
    }

    [TestClass]
    public class ProfileInformation
    {
      [TestMethod]
      public void ShouldGetUsersProfile()
      {
        int profileId = 324784;

        ApiRequest apiRequest = new ApiRequest(requestSettings);
        Profile p = apiRequest.GetProfile(profileId);

        Assert.AreEqual("Basil", p.FirstName);
        Assert.AreEqual("Brown", p.Surname);
      }
    }
  }
}
