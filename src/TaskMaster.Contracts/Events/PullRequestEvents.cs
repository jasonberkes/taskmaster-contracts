namespace TaskMaster.Contracts.Events;

/// <summary>
/// Base event for all PullRequest-related events.
/// </summary>
public abstract class PullRequestEventBase
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
    /// Pull request number.
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
/// Published when a PR is created.
/// </summary>
public class PullRequestCreatedEvent : PullRequestEventBase
{
    public string Title { get; set; } = string.Empty;
    public string? HeadBranch { get; set; }
    public string? BaseBranch { get; set; }
    public int? WorkItemId { get; set; }
    public int? TaskExecutionId { get; set; }
    public string? CreatedBy { get; set; }
}

/// <summary>
/// Published when a PR review completes.
/// </summary>
public class PullRequestReviewedEvent : PullRequestEventBase
{
    public string ReviewResult { get; set; } = string.Empty; // Approved, ChangesRequested, Commented
    public int QualityScore { get; set; }
    public string? ReviewBlobPath { get; set; }
    public int FindingsCount { get; set; }
}

/// <summary>
/// Published when a PR is merged.
/// </summary>
public class PullRequestMergedEvent : PullRequestEventBase
{
    public DateTime MergedAt { get; set; }
    public string? MergedBy { get; set; }
    public string? MergeCommitSha { get; set; }
    public int? WorkItemId { get; set; }
}

/// <summary>
/// Published when a PR is closed without merging.
/// </summary>
public class PullRequestClosedEvent : PullRequestEventBase
{
    public DateTime ClosedAt { get; set; }
    public string? ClosedBy { get; set; }
    public string? CloseReason { get; set; }
}

/// <summary>
/// Published when PR checks complete.
/// </summary>
public class PullRequestChecksCompletedEvent : PullRequestEventBase
{
    public bool AllChecksPassed { get; set; }
    public string ChecksSource { get; set; } = string.Empty; // "GitHubActions", "AzureDevOps"
    public string? FailedChecks { get; set; }
}
