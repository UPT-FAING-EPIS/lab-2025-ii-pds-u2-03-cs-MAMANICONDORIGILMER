using NUnit.Framework;
using Comportamiento.Domain;
using System;
using System.Collections.Generic;

namespace Comportamiento.Domain.Tests;

public class ObserverPatternTests
{
    private NewsAgency _newsAgency;
    private TestObserver _testObserver1;
    private TestObserver _testObserver2;

    [SetUp]
    public void Setup()
    {
        _newsAgency = new NewsAgency();
        _testObserver1 = new TestObserver("Observer1");
        _testObserver2 = new TestObserver("Observer2");
    }

    [Test]
    public void NewsAgency_ShouldStartWithNoSubscribers()
    {
        // Act & Assert
        Assert.That(_newsAgency.SubscriberCount, Is.EqualTo(0));
        Assert.That(_newsAgency.GetLatestNews(), Is.Null);
    }

    [Test]
    public void Attach_ShouldAddObserverToSubscribers()
    {
        // Act
        _newsAgency.Attach(_testObserver1);

        // Assert
        Assert.That(_newsAgency.SubscriberCount, Is.EqualTo(1));
    }

    [Test]
    public void Detach_ShouldRemoveObserverFromSubscribers()
    {
        // Arrange
        _newsAgency.Attach(_testObserver1);
        _newsAgency.Attach(_testObserver2);

        // Act
        _newsAgency.Detach(_testObserver1);

        // Assert
        Assert.That(_newsAgency.SubscriberCount, Is.EqualTo(1));
    }

    [Test]
    public void PublishNews_ShouldNotifyAllAttachedObservers()
    {
        // Arrange
        _newsAgency.Attach(_testObserver1);
        _newsAgency.Attach(_testObserver2);

        // Act
        _newsAgency.PublishNews("Test Title", "Test Content", "Sports");

        // Assert
        Assert.That(_testObserver1.UpdateCallCount, Is.EqualTo(1));
        Assert.That(_testObserver2.UpdateCallCount, Is.EqualTo(1));
        Assert.That(_testObserver1.LastReceivedData?.Title, Is.EqualTo("Test Title"));
        Assert.That(_testObserver1.LastReceivedData?.Content, Is.EqualTo("Test Content"));
        Assert.That(_testObserver1.LastReceivedData?.Category, Is.EqualTo("Sports"));
    }

    [Test]
    public void PublishNews_ShouldUpdateLatestNews()
    {
        // Act
        _newsAgency.PublishNews("Latest News", "Breaking news content", "General");

        // Assert
        var latestNews = _newsAgency.GetLatestNews();
        Assert.That(latestNews, Is.Not.Null);
        Assert.That(latestNews.Title, Is.EqualTo("Latest News"));
        Assert.That(latestNews.Content, Is.EqualTo("Breaking news content"));
        Assert.That(latestNews.Category, Is.EqualTo("General"));
    }

    [Test]
    public void MultipleNewsPublications_ShouldNotifyObserversEachTime()
    {
        // Arrange
        _newsAgency.Attach(_testObserver1);

        // Act
        _newsAgency.PublishNews("News 1", "Content 1", "Category 1");
        _newsAgency.PublishNews("News 2", "Content 2", "Category 2");
        _newsAgency.PublishNews("News 3", "Content 3", "Category 3");

        // Assert
        Assert.That(_testObserver1.UpdateCallCount, Is.EqualTo(3));
        Assert.That(_testObserver1.LastReceivedData?.Title, Is.EqualTo("News 3"));
        Assert.That(_testObserver1.LastReceivedData?.Content, Is.EqualTo("Content 3"));
        Assert.That(_testObserver1.LastReceivedData?.Category, Is.EqualTo("Category 3"));
    }

    [Test]
    public void DetachedObserver_ShouldNotReceiveNotifications()
    {
        // Arrange
        _newsAgency.Attach(_testObserver1);
        _newsAgency.Attach(_testObserver2);
        _newsAgency.Detach(_testObserver2);

        // Act
        _newsAgency.PublishNews("Test News", "Test Content", "Test Category");

        // Assert
        Assert.That(_testObserver1.UpdateCallCount, Is.EqualTo(1));
        Assert.That(_testObserver2.UpdateCallCount, Is.EqualTo(0));
    }

    [Test]
    public void NewsData_ShouldHaveCorrectProperties()
    {
        // Arrange
        var title = "Test Title";
        var content = "Test Content";
        var category = "Test Category";

        // Act
        var newsData = new NewsData(title, content, category);

        // Assert
        Assert.That(newsData.Title, Is.EqualTo(title));
        Assert.That(newsData.Content, Is.EqualTo(content));
        Assert.That(newsData.Category, Is.EqualTo(category));
        Assert.That(newsData.PublishedDate, Is.LessThanOrEqualTo(DateTime.Now));
        Assert.That(newsData.PublishedDate, Is.GreaterThanOrEqualTo(DateTime.Now.AddSeconds(-1)));
    }

    [Test]
    public void ConcreteObservers_ShouldImplementUpdateCorrectly()
    {
        // Arrange
        var emailSubscriber = new EmailSubscriber("test@example.com");
        var smsSubscriber = new SMSSubscriber("+1234567890");
        var newsDisplay = new NewsDisplay("Main Display");

        _newsAgency.Attach(emailSubscriber);
        _newsAgency.Attach(smsSubscriber);
        _newsAgency.Attach(newsDisplay);

        // Act
        _newsAgency.PublishNews("Observer Test", "Testing concrete observers", "Test");

        // Assert
        Assert.That(_newsAgency.SubscriberCount, Is.EqualTo(3));
        var latestNews = _newsAgency.GetLatestNews();
        Assert.That(latestNews, Is.Not.Null);
        Assert.That(latestNews.Title, Is.EqualTo("Observer Test"));
    }
}

/// <summary>
/// Test helper class to capture observer notifications
/// </summary>
public class TestObserver : IObserver<NewsData>
{
    public string Name { get; }
    public int UpdateCallCount { get; private set; }
    public NewsData? LastReceivedData { get; private set; }

    public TestObserver(string name)
    {
        Name = name;
        UpdateCallCount = 0;
        LastReceivedData = null;
    }

    public void Update(NewsData data)
    {
        UpdateCallCount++;
        LastReceivedData = data;
    }
}
