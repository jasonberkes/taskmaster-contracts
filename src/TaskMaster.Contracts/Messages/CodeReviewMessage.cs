namespace TaskMaster.Contracts.Messages;

/// <summary>
/// Message sent when a code review needs to be processed.
/// Triggered by GitHub webhooks (check_run, status events).
/// </summary>
public class CodeReviewMessage : MessageBase
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
    /// Pull request number to review.
    /// </summary>
    public int PullRequestNumber { get; set; }

    /// <summary>
    /// What triggered this code review.
    /// Values: "check_run", "status", "manual", "webhook"
    /// </summary>
    public string TriggerSource { get; set; } = string.Empty;

    /// <summary>
    /// The SHA of the commit being reviewed.
    /// </summary>
    public string? CommitSha { get; set; }

    /// <summary>
    /// Optional WorkItem ID that created this PR.
    /// </summary>
    public int? SourceWorkItemId { get; set; }

    /// <summary>
    /// Optional TaskExecution ID tracking this PR.
    /// </summary>
    public int? TaskExecutionId { get; set; }

    /// <summary>
    /// Creates a new CodeReviewMessage.
    /// </summary>
    public CodeReviewMessage()
    {
    }

    /// <summary>
    /// Creates a new CodeReviewMessage for a specific PR.
    /// </summary>
    public CodeReviewMessage(string owner, string repo, int prNumber, string triggerSource, string correlationId)
        : base(correlationId, "GitHubWebhook")
    {
        Owner = owner;
        Repo = repo;
        PullRequestNumber = prNumber;
        TriggerSource = triggerSource;
    }
}
