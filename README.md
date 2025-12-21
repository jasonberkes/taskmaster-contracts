# TaskMaster.Contracts

Shared contracts library for TaskMaster Platform microservices. Contains message contracts, event definitions, and constants for Service Bus communication.

## Overview

This library provides the **single source of truth** for:
- **Messages**: Service Bus message contracts for queue communication
- **Events**: Event definitions for pub/sub topic communication  
- **Constants**: Queue names, topic names, and execution provider identifiers

All TaskMaster microservices reference this library to ensure consistent communication.

## Installation

```bash
dotnet add package TaskMaster.Contracts
```

## Structure

```
TaskMaster.Contracts/
├── Messages/
│   ├── IMessage.cs              # Base interface for all messages
│   ├── MessageBase.cs           # Abstract base class
│   ├── WorkItemMessage.cs       # Queue WorkItem for execution
│   ├── CodeReviewMessage.cs     # Queue PR for code review
│   ├── IssueReportMessage.cs    # Report issue from any source
│   └── ExecutionResultMessage.cs # Execution completion result
├── Events/
│   ├── WorkItemEvents.cs        # WorkItem lifecycle events
│   ├── ExecutionEvents.cs       # TaskExecution events
│   ├── PullRequestEvents.cs     # PR lifecycle events
│   ├── CodeReviewEvents.cs      # Code review events
│   ├── IssueEvents.cs           # Issue module events
│   └── SystemEvents.cs          # System-wide events
└── Constants/
    ├── QueueNames.cs            # Service Bus queue names
    ├── TopicNames.cs            # Service Bus topic names
    └── ExecutionProviders.cs    # Execution provider identifiers
```

## Usage

### Sending a WorkItem to the Queue

```csharp
using TaskMaster.Contracts;
using TaskMaster.Contracts.Messages;

var message = new WorkItemMessage
{
    WorkItemId = 123,
    ExecutionProvider = ExecutionProviders.ClaudeCode,
    CorrelationId = Guid.NewGuid().ToString()
};

await serviceBusSender.SendMessageAsync(QueueNames.ClaudeCodeWork, message);
```

### Publishing Events

```csharp
using TaskMaster.Contracts;
using TaskMaster.Contracts.Events;

var evt = new WorkItemCompletedEvent
{
    WorkItemId = 123,
    CompletedAt = DateTime.UtcNow,
    TotalCost = 0.05m
};

await eventPublisher.PublishAsync(TopicNames.WorkItemEvents, evt);
```

### Reporting Issues

```csharp
using TaskMaster.Contracts.Messages;

var issue = new IssueReportMessage("SonarQube", correlationId)
{
    GitHubRepoOwner = "jasonberkes",
    GitHubRepoName = "taskmaster-platform",
    Category = "Security",
    Severity = "High",
    FilePath = "src/Services/AuthService.cs",
    LineNumber = 42
};

await serviceBusSender.SendMessageAsync(QueueNames.IssueIngestion, issue);
```

## Microservices Using This Library

| Service | Messages Used | Events Published |
|---------|--------------|------------------|
| TaskMaster.Platform | All | All |
| TaskMaster.ClaudeCodeWorker | WorkItemMessage, ExecutionResultMessage | ExecutionEvents |
| TaskMaster.DocumentService | IssueReportMessage | IssueEvents |
| TaskMaster.AgentFramework | WorkItemMessage, ExecutionResultMessage | ExecutionEvents |

## Versioning

This library follows [Semantic Versioning](https://semver.org/):
- **MAJOR**: Breaking changes to message/event contracts
- **MINOR**: New messages, events, or constants (backward compatible)
- **PATCH**: Bug fixes, documentation updates

## Contributing

All contract changes should be:
1. Backward compatible when possible
2. Discussed before implementation
3. Documented with XML comments
4. Tested in consuming services before release

## License

MIT License - see [LICENSE](LICENSE) for details.
