namespace TaskMaster.Contracts.Events;

/// <summary>
/// Base event for all WorkItem-related events.
/// </summary>
public abstract class WorkItemEventBase
{
    /// <summary>
    /// The WorkItem ID this event relates to.
    /// </summary>
    public int WorkItemId { get; set; }

    /// <summary>
    /// UTC timestamp when the event occurred.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public string EventId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Correlation ID for request tracing.
    /// </summary>
    public string? CorrelationId { get; set; }
}

/// <summary>
/// Published when a new WorkItem is created.
/// </summary>
public class WorkItemCreatedEvent : WorkItemEventBase
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Priority { get; set; }
    public string? UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// Published when a WorkItem is queued for execution.
/// </summary>
public class WorkItemQueuedEvent : WorkItemEventBase
{
    public DateTime QueuedAt { get; set; }
    public int Priority { get; set; }
    public string? UserId { get; set; }
    public int? ExecutionId { get; set; }
    public string ExecutionProvider { get; set; } = ExecutionProviders.ClaudeCode;
}

/// <summary>
/// Published when a WorkItem execution completes successfully.
/// </summary>
public class WorkItemCompletedEvent : WorkItemEventBase
{
    public DateTime CompletedAt { get; set; }
    public string? CompletedBy { get; set; }
    public string? PullRequestUrl { get; set; }
    public int ExecutionId { get; set; }
    public decimal TotalCost { get; set; }
    public int DurationSeconds { get; set; }
}

/// <summary>
/// Published when a WorkItem execution fails.
/// </summary>
public class WorkItemFailedEvent : WorkItemEventBase
{
    public string ErrorMessage { get; set; } = string.Empty;
    public int RetryCount { get; set; }
    public int? ExecutionId { get; set; }
    public string? ErrorType { get; set; }
    public string? StackTrace { get; set; }
    public DateTime FailedAt { get; set; }
}

/// <summary>
/// Published when a WorkItem's status changes.
/// </summary>
public class WorkItemStatusChangedEvent : WorkItemEventBase
{
    public string PreviousStatus { get; set; } = string.Empty;
    public string NewStatus { get; set; } = string.Empty;
    public string? ChangedBy { get; set; }
    public string? Reason { get; set; }
}
