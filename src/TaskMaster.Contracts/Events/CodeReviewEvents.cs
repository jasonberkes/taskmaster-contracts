namespace TaskMaster.Contracts.Events;

/// <summary>
/// Base event for all CodeReview-related events.
/// </summary>
public abstract class CodeReviewEventBase
{
    /// <summary>
    /// GitHub repository owner.
    /// </summary>
    public string Owner { get; set; } = string.Empty;

    /// <summary>
    /// GitHub repository name.
    /// </summary>
    public string Repo { get; set; } = string.Empty;

    /// <summary>
    /// Pull request number being reviewed.
    /// </summary>
    public int PullRequestNumber { get; set; }

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
/// Published when a code review is requested/queued.
/// </summary>
public class CodeReviewRequestedEvent : CodeReviewEventBase
{
    public string TriggerSource { get; set; } = string.Empty;
    public int? SourceWorkItemId { get; set; }
    public int? TaskExecutionId { get; set; }
}

/// <summary>
/// Published when a code review starts processing.
/// </summary>
public class CodeReviewStartedEvent : CodeReviewEventBase
{
    public DateTime StartedAt { get; set; }
    public string? WorkerInstanceId { get; set; }
}

/// <summary>
/// Published when a code review completes.
/// </summary>
public class CodeReviewCompletedEvent : CodeReviewEventBase
{
    public DateTime CompletedAt { get; set; }
    public int QualityScore { get; set; }
    public string Recommendation { get; set; } = string.Empty; // Approved, ApprovedWithSuggestions, NeedsWork
    public string? ReviewBlobPath { get; set; }
    public int SuggestionsCount { get; set; }
    public int SecurityIssuesCount { get; set; }
    public int PerformanceIssuesCount { get; set; }
    public int ConcernsCount { get; set; }
}

/// <summary>
/// Published when code review findings are processed into Issues.
/// </summary>
public class CodeReviewFindingsProcessedEvent : CodeReviewEventBase
{
    public int IssuesCreated { get; set; }
    public int IssuesUpdated { get; set; }
    public int IssuesPromoted { get; set; }
    public int WorkItemsCreated { get; set; }
}
