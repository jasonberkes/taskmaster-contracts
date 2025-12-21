namespace TaskMaster.Contracts.Events;

/// <summary>
/// Base event for system-wide events.
/// </summary>
public abstract class SystemEventBase
{
    /// <summary>
    /// UTC timestamp when the event occurred.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public string EventId { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Service/component that generated this event.
    /// </summary>
    public string Source { get; set; } = string.Empty;
}

/// <summary>
/// Published when service health status changes.
/// </summary>
public class HealthStatusChangedEvent : SystemEventBase
{
    public string ServiceName { get; set; } = string.Empty;
    public string PreviousStatus { get; set; } = string.Empty;
    public string NewStatus { get; set; } = string.Empty; // Healthy, Degraded, Unhealthy
    public string? Details { get; set; }
}

/// <summary>
/// Published when a deployment completes.
/// </summary>
public class DeploymentCompletedEvent : SystemEventBase
{
    public string ServiceName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Environment { get; set; } = string.Empty;
    public bool Success { get; set; }
    public string? DeploymentId { get; set; }
}

/// <summary>
/// Published when queue statistics change significantly.
/// </summary>
public class QueueStatsChangedEvent : SystemEventBase
{
    public string QueueName { get; set; } = string.Empty;
    public int ActiveMessages { get; set; }
    public int DeadLetterMessages { get; set; }
    public int ScheduledMessages { get; set; }
}

/// <summary>
/// Published when dead letter messages require attention.
/// </summary>
public class DeadLetterAlertEvent : SystemEventBase
{
    public string QueueName { get; set; } = string.Empty;
    public int MessageCount { get; set; }
    public string? OldestMessageId { get; set; }
    public DateTime? OldestMessageTimestamp { get; set; }
}

/// <summary>
/// Published for budget alerts.
/// </summary>
public class BudgetAlertEvent : SystemEventBase
{
    public string BudgetType { get; set; } = string.Empty; // Daily, Weekly, Monthly
    public decimal CurrentSpend { get; set; }
    public decimal BudgetLimit { get; set; }
    public int PercentUsed { get; set; }
}
