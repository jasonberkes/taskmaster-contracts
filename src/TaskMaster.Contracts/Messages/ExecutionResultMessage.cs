namespace TaskMaster.Contracts.Messages;

/// <summary>
/// Message sent when a WorkItem execution completes (success or failure).
/// Published by execution agents (ClaudeCodeWorker, etc.) after processing.
/// </summary>
public class ExecutionResultMessage : MessageBase
{
    /// <summary>
    /// The WorkItem ID that was executed.
    /// </summary>
    public int WorkItemId { get; set; }

    /// <summary>
    /// The TaskExecution ID tracking this execution.
    /// </summary>
    public int TaskExecutionId { get; set; }

    /// <summary>
    /// Whether the execution succeeded.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Execution status.
    /// Values: "Completed", "Failed", "Cancelled", "TimedOut"
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Which provider executed this WorkItem.
    /// </summary>
    public string ExecutionProvider { get; set; } = ExecutionProviders.ClaudeCode;

    /// <summary>
    /// Error message if execution failed.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Error type/category if execution failed.
    /// </summary>
    public string? ErrorType { get; set; }

    /// <summary>
    /// Pull request URL if one was created.
    /// </summary>
    public string? PullRequestUrl { get; set; }

    /// <summary>
    /// Pull request number if one was created.
    /// </summary>
    public int? PullRequestNumber { get; set; }

    /// <summary>
    /// Total cost of the execution (AI tokens, etc.).
    /// </summary>
    public decimal TotalCost { get; set; }

    /// <summary>
    /// Execution duration in seconds.
    /// </summary>
    public int DurationSeconds { get; set; }

    /// <summary>
    /// When the execution started.
    /// </summary>
    public DateTime StartedAt { get; set; }

    /// <summary>
    /// When the execution completed.
    /// </summary>
    public DateTime CompletedAt { get; set; }

    /// <summary>
    /// Creates a new ExecutionResultMessage.
    /// </summary>
    public ExecutionResultMessage()
    {
    }

    /// <summary>
    /// Creates a successful execution result.
    /// </summary>
    public static ExecutionResultMessage Succeeded(
        int workItemId,
        int taskExecutionId,
        string correlationId,
        string source,
        string? prUrl = null,
        int? prNumber = null)
    {
        return new ExecutionResultMessage
        {
            WorkItemId = workItemId,
            TaskExecutionId = taskExecutionId,
            Success = true,
            Status = "Completed",
            CorrelationId = correlationId,
            Source = source,
            PullRequestUrl = prUrl,
            PullRequestNumber = prNumber,
            CompletedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Creates a failed execution result.
    /// </summary>
    public static ExecutionResultMessage Failed(
        int workItemId,
        int taskExecutionId,
        string correlationId,
        string source,
        string errorMessage,
        string? errorType = null)
    {
        return new ExecutionResultMessage
        {
            WorkItemId = workItemId,
            TaskExecutionId = taskExecutionId,
            Success = false,
            Status = "Failed",
            CorrelationId = correlationId,
            Source = source,
            ErrorMessage = errorMessage,
            ErrorType = errorType,
            CompletedAt = DateTime.UtcNow
        };
    }
}
