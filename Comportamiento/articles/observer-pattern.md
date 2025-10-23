# Observer Pattern Implementation

## Overview

The Observer pattern is a behavioral design pattern that defines a one-to-many dependency between objects so that when one object (subject) changes state, all its dependents (observers) are notified and updated automatically.

## Structure

### Participants

1. **Subject**: Maintains a list of observers and notifies them of state changes
2. **Observer**: Defines an interface for objects that should be notified of changes
3. **ConcreteSubject**: Implements the Subject interface and maintains the state
4. **ConcreteObserver**: Implements the Observer interface and reacts to subject changes

## Implementation in Comportamiento Project

### Interfaces

```csharp
public interface IObserver<T>
{
    void Update(T data);
}

public interface ISubject<T>
{
    void Attach(IObserver<T> observer);
    void Detach(IObserver<T> observer);
    void Notify(T data);
}
```

### Concrete Implementation

#### NewsAgency (Subject)

```csharp
public class NewsAgency : ISubject<NewsData>
{
    private readonly List<IObserver<NewsData>> _observers;
    private NewsData? _latestNews;

    public NewsAgency()
    {
        _observers = new List<IObserver<NewsData>>();
    }

    public void Attach(IObserver<NewsData> observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver<NewsData> observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(NewsData data)
    {
        _latestNews = data;
        foreach (var observer in _observers)
        {
            observer.Update(data);
        }
    }

    public void PublishNews(string title, string content, string category)
    {
        var newsData = new NewsData(title, content, category);
        Notify(newsData);
    }
}
```

#### Concrete Observers

```csharp
public class EmailSubscriber : IObserver<NewsData>
{
    private readonly string _email;

    public EmailSubscriber(string email)
    {
        _email = email;
    }

    public void Update(NewsData data)
    {
        Console.WriteLine($"Sending email to {_email}: {data.Title}");
    }
}
```

## Benefits

1. **Loose Coupling**: Subject and observers are loosely coupled
2. **Open/Closed Principle**: Can add new observers without modifying the subject
3. **Dynamic Relationships**: Observers can be added/removed at runtime
4. **Broadcast Communication**: One subject can notify multiple observers

## Use Cases

- Event handling systems
- Model-View architectures
- News/RSS feed systems
- File system monitoring
- Stock price updates

## Comparison with Strategy Pattern

While both are behavioral patterns, they serve different purposes:

- **Observer**: One-to-many communication, push-based notifications
- **Strategy**: Encapsulates algorithms, allows algorithm substitution

The Comportamiento project uses Observer pattern while the Payment project uses Strategy pattern, demonstrating different behavioral design approaches.