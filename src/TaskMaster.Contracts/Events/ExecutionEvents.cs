namespace TaskMaster.Contracts.Events;

/// <summary>
/// Base event for all TaskExecution-related events.
/// </summary>
public abstract class ExecutionEventBase
{
    /// <summary>
    /// The TaskExecution ID this event relates to.
    /// </summary>
    public int ExecutionId { get; set; }

    /// <summary>
    /// The WorkItem ID being executed.
    /// </summary>
    public int WorkItemId { get; set; }

    /// <summary>
    /// Who/what is assigned to execute this WorkItem.
    /// </summary>
    public string? AssignedTo { get; set; }

    /// <summary>
    /// Type of execution (e.g., ClaudeCodeJob, Manual).
    /// </summary>
    public string? ExecutionType { get; set; }

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
/// Published when a TaskExecution starts.
/// </summary>
public class ExecutionStartedEvent : ExecutionEventBase
{
    public DateTime StartedAt { get; set; }
    public string ExecutionProvider { get; set; } = ExecutionProviders.ClaudeCode;
    public string? WorkerInstanceId { get; set; }
}

/// <summary>
/// Published when a TaskExecution phase changes.
/// </summary>
public class ExecutionPhaseChangedEvent : ExecutionEventBase
{
    public string PreviousPhase { get; set; } = string.Empty;
    public string NewPhase { get; set; } = string.Empty;
    public string? PhaseDetails { get; set; }
}

/// <summary>
/// Published when a TaskExecution completes.
/// </summary>
public class ExecutionCompletedEvent : ExecutionEventBase
{
    public bool Success { get; set; }
    public DateTime CompletedAt { get; set; }
    public int DurationSeconds { get; set; }
    public decimal TotalCost { get; set; }
    public string? PullRequestUrl { get; set; }
    public int? PullRequestNumber { get; set; }
}

/// <summary>
/// Published when a TaskExecution fails.
/// </summary>
public class ExecutionFailedEvent : ExecutionEventBase
{
    public string ErrorMessage { get; set; } = string.Empty;
    public string? ErrorType { get; set; }
    public string? StackTrace { get; set; }
    public DateTime FailedAt { get; set; }
    public bool WillRetry { get; set; }
    public int RetryCount { get; set; }
}

/// <summary>
/// Published periodically during long-running executions.
/// </summary>
public class ExecutionHeartbeatEvent : ExecutionEventBase
{
    public string CurrentPhase { get; set; } = string.Empty;
    public int ElapsedSeconds { get; set; }
    public decimal CurrentCost { get; set; }
    public string? StatusMessage { get; set; }
}
