namespace TaskMaster.Contracts.Events;

/// <summary>
/// Base event for all Issue-related events (from TaskMaster.Issues module).
/// </summary>
public abstract class IssueEventBase
{
    /// <summary>
    /// The Issue ID this event relates to.
    /// </summary>
    public int IssueId { get; set; }

    /// <summary>
    /// The issue's correlation key for deduplication.
    /// </summary>
    public string CorrelationKey { get; set; } = string.Empty;

    /// <summary>
    /// UTC timestamp when the event occurred.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public string EventId { get; set; } = Guid.NewGuid().ToString();
}

/// <summary>
/// Published when a new issue is ingested.
/// </summary>
public class IssueIngestedEvent : IssueEventBase
{
    public string Source { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Severity { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public int ImpactScore { get; set; }
    public bool IsNew { get; set; } // true if new issue, false if existing updated
}

/// <summary>
/// Published when an existing issue is updated (seen again).
/// </summary>
public class IssueUpdatedEvent : IssueEventBase
{
    public int OccurrenceCount { get; set; }
    public int SourceCount { get; set; }
    public int ImpactScore { get; set; }
    public string[] Sources { get; set; } = Array.Empty<string>();
}

/// <summary>
/// Published when an issue is promoted to a WorkItem.
/// </summary>
public class IssuePromotedEvent : IssueEventBase
{
    public int WorkItemId { get; set; }
    public string PromotionRule { get; set; } = string.Empty;
    public int WorkItemPriority { get; set; }
    public int? GroupId { get; set; }
    public int IssuesInGroup { get; set; }
}

/// <summary>
/// Published when an issue is resolved.
/// </summary>
public class IssueResolvedEvent : IssueEventBase
{
    public string ResolutionReason { get; set; } = string.Empty; // Fixed, Stale, FalsePositive, WontFix
    public int? FixedByWorkItemId { get; set; }
    public DateTime ResolvedAt { get; set; }
}

/// <summary>
/// Published when an issue recurs after being resolved.
/// </summary>
public class IssueRecurredEvent : IssueEventBase
{
    public int RecurrenceCount { get; set; }
    public DateTime LastFixedAt { get; set; }
}
