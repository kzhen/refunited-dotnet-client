﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefugeesUnitedApi.Tests
{
  [TestClass]
  public class MessagingIntegrationTests
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

    [TestClass]
    public class UnreadMessagesTest
    {
      [TestMethod]
      public void ShouldReturn2UnreadMessageCount()
      {
        ApiRequest apiRequest = new ApiRequest(requestSettings);

        int accountId = 280976;

        ProfileUnreadMessage unread = apiRequest.GetUnreadMessages(accountId);

        Assert.AreEqual(1, unread.UnreadMessages);
      }
    }

    [TestClass]
    public class ProfileMessageCollectionTests
    {
      [TestMethod]
      public void ShouldReturnAListOfMessages()
      {
        ApiRequest apiRequest = new ApiRequest(requestSettings);
        int accountId = 280976;

        ProfileMessageCollection collection = apiRequest.GetMessageCollection(accountId);

        Assert.AreEqual(2, collection.threads.Length);
      }
    }

    [TestClass]
    public class ProfileMessageThread
    {
      [TestMethod]
      public void ShouldReturnAMessageThread()
      {
        ApiRequest apiRequest = new ApiRequest(requestSettings);
        int accountId = 280976;
        int targetAccountId = 324317;

        MessageThread thread = apiRequest.GetMessageThread(accountId, targetAccountId);
        

        Assert.IsNotNull(thread);
        Assert.AreEqual(2, thread.TotalMessageCount);
      }
    }
  }
}