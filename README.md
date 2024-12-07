# SOLID Principles Notification System

This project demonstrates the practical application of SOLID principles through a notification system implementation in C#. Each principle is illustrated with clear examples of both good and bad practices, culminating in a complete implementation that incorporates all principles together.

## Project Structure

```
solid-notification-system/
├── src/
│   └── NotificationSystem/
│       ├── Examples/
│       │   ├── 1.SRP/    # Single Responsibility Principle
│       │   ├── 2.OCP/    # Open-Closed Principle
│       │   ├── 3.LSP/    # Liskov Substitution Principle
│       │   ├── 4.ISP/    # Interface Segregation Principle
│       │   └── 5.DIP/    # Dependency Inversion Principle
│       └── Final/        # Complete implementation
├── tests/
│   └── NotificationSystem.Tests/
│       ├── 1.SRP/        # Tests for SRP examples
│       ├── 2.OCP/        # Tests for OCP examples
│       ├── 3.LSP/        # Tests for LSP examples
│       ├── 4.ISP/        # Tests for ISP examples
│       ├── 5.DIP/        # Tests for DIP examples
│       └── Final/        # Tests for final implementation
```

## SOLID Principles Demonstrated

### 1. Single Responsibility Principle (SRP)
- Each class has one reason to change
- Examples show separation of concerns in notification handling
- Located in `Examples/1.SRP/`

### 2. Open-Closed Principle (OCP)
- System is open for extension but closed for modification
- Demonstrates adding new notification channels without changing existing code
- Located in `Examples/2.OCP/`

### 3. Liskov Substitution Principle (LSP)
- Subtypes must be substitutable for their base types
- Shows proper inheritance and contract adherence
- Located in `Examples/3.LSP/`

### 4. Interface Segregation Principle (ISP)
- Clients shouldn't depend on methods they don't use
- Demonstrates interface splitting and focused contracts
- Located in `Examples/4.ISP/`

### 5. Dependency Inversion Principle (DIP)
- High-level modules shouldn't depend on low-level modules
- Shows proper dependency injection and abstraction
- Located in `Examples/5.DIP/`

## Final Implementation

The final implementation in the `Final/` directory combines all SOLID principles in a complete notification system that:
- Supports multiple notification channels (Email, SMS)
- Provides message validation
- Implements logging
- Uses dependency injection
- Is easily extensible

### Key Components

1. **Interfaces**
   - `INotificationChannel`
   - `INotificationFormatter`
   - `INotificationValidator`
   - `INotificationLogger`

2. **Services**
   - `NotificationService`
   - `NotificationFormatter`
   - `NotificationValidator`
   - `FileNotificationLogger`

3. **Channels**
   - `EmailChannel`
   - `SmsChannel`

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- Visual Studio 2022 or VS Code

### Installation

1. Clone the repository
```bash
git clone https://github.com/choudharyr/solid-notification-system.git
```

2. Build the solution
```bash
dotnet build
```

3. Run the tests
```bash
dotnet test
```

### Required NuGet Packages
- `Microsoft.Extensions.DependencyInjection`
- `Microsoft.Extensions.Configuration`
- `Moq` (for testing)

## Usage

### Basic Usage
```csharp
// Create a notification message
var message = new NotificationMessage(
    "recipient@example.com",
    "Hello, World!",
    "Email"
);

// Send the notification
await notificationService.SendNotificationAsync(message);
```

### Adding a New Channel
```csharp
public class TeamsChannel : INotificationChannel
{
    public string ChannelType => "Teams";

    public async Task<bool> SendAsync(NotificationMessage message)
    {
        // Teams-specific implementation
    }
}
```

## Testing

The project includes comprehensive tests for:
- Individual SOLID principle examples
- Final implementation components
- Integration scenarios

Run tests using:
```bash
dotnet test
```

## Best Practices Demonstrated

1. **Clean Architecture**
   - Clear separation of concerns
   - Dependency injection
   - Interface-based design

2. **Testing**
   - Unit tests
   - Integration tests
   - Mock-based testing

3. **Error Handling**
   - Graceful failure handling
   - Comprehensive logging
   - Input validation

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Thanks to Robert C. Martin (Uncle Bob) for the SOLID principles
- Inspired by real-world notification systems
- Built for educational purposes