# Comportamiento Project Documentation

Welcome to the documentation for the **Comportamiento** project, which demonstrates the implementation of the **Observer Pattern** in .NET.

## Overview

The Comportamiento project showcases a behavioral design pattern implementation using the Observer pattern, which is different from the Strategy pattern used in other projects. This pattern allows objects to be notified of state changes in other objects they're observing.

## Architecture

The project follows Domain-Driven Design (DDD) principles with a clear separation of concerns:

- **Domain Layer**: Contains the core business logic and domain models
- **Test Layer**: Comprehensive unit tests ensuring reliability

## Observer Pattern Implementation

The Observer pattern is implemented through:

- `IObserver<T>` - Generic observer interface
- `ISubject<T>` - Generic subject interface
- `NewsAgency` - Concrete subject that manages subscribers
- Multiple concrete observers (EmailSubscriber, SMSSubscriber, NewsDisplay)

## Key Components

### Core Interfaces
- **IObserver<T>**: Defines the contract for objects that want to be notified of changes
- **ISubject<T>**: Defines the contract for objects that can be observed

### Domain Models
- **NewsData**: Represents news information with title, content, category, and publish date
- **NewsAgency**: Manages subscribers and publishes news notifications

### Concrete Observers
- **EmailSubscriber**: Simulates email notification functionality
- **SMSSubscriber**: Simulates SMS notification functionality
- **NewsDisplay**: Simulates display system notifications

## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Git

### Building the Project

```bash
# Clone the repository
git clone <repository-url>
cd Comportamiento

# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run tests
dotnet test
```

### Running Tests

The project includes comprehensive unit tests covering:
- Observer attachment and detachment
- Notification functionality
- Multiple observer scenarios
- Data integrity validation

```bash
dotnet test Comportamiento/Comportamiento.Domain.Tests/
```

## Usage Example

```csharp
// Create a news agency
var newsAgency = new NewsAgency();

// Create and attach observers
var emailSubscriber = new EmailSubscriber("user@example.com");
var smsSubscriber = new SMSSubscriber("+1234567890");
var display = new NewsDisplay("Main Screen");

newsAgency.Attach(emailSubscriber);
newsAgency.Attach(smsSubscriber);
newsAgency.Attach(display);

// Publish news - all observers will be notified
newsAgency.PublishNews(
    "Breaking News",
    "Important announcement content",
    "General"
);
```

## Design Patterns Used

- **Observer Pattern**: For implementing the publish-subscribe mechanism
- **Domain-Driven Design**: For organizing the solution structure
- **Dependency Inversion**: Through interface-based programming

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Ensure all tests pass
6. Submit a pull request

## License

This project is part of an educational laboratory focused on design patterns and software architecture.