namespace TaskMaster.Contracts;

/// <summary>
/// Azure Service Bus queue names used across TaskMaster microservices.
/// Single source of truth - no magic strings!
/// </summary>
public static class QueueNames
{
    /// <summary>
    /// Queue for WorkItem execution requests.
    /// Consumed by ClaudeCodeWorker and future execution agents.
    /// </summary>
    public const string ClaudeCodeWork = "claudecode-work-queue";

    /// <summary>
    /// Queue for code review processing requests.
    /// </summary>
    public const string CodeReviewWork = "codereview-work-queue";

    /// <summary>
    /// Queue for issue ingestion from various sources.
    /// </summary>
    public const string IssueIngestion = "issue-ingestion-queue";

    /// <summary>
    /// Queue for document indexing requests.
    /// </summary>
    public const string DocumentIndexing = "document-indexing-queue";

    /// <summary>
    /// Dead letter queue for failed messages.
    /// </summary>
    public const string DeadLetter = "dead-letter-queue";
}
