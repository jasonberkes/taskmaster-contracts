namespace TaskMaster.Contracts.Messages;

/// <summary>
/// Message sent to queue a WorkItem for execution.
/// Used by ClaudeCodeWorker and future execution agents.
/// </summary>
public class WorkItemMessage : MessageBase
{
    /// <summary>
    /// The WorkItem ID to execute.
    /// </summary>
    public int WorkItemId { get; set; }

    /// <summary>
    /// Which execution provider should handle this WorkItem.
    /// Default is "ClaudeCode" for the Claude Code CLI worker.
    /// Future values: "OpenAI", "Gemini", "Human", "SecurityAgent", etc.
    /// </summary>
    public string ExecutionProvider { get; set; } = ExecutionProviders.ClaudeCode;

    /// <summary>
    /// Optional priority override for queue processing.
    /// If not set, uses the WorkItem's priority.
    /// </summary>
    public int? PriorityOverride { get; set; }

    /// <summary>
    /// Optional user ID who triggered the execution.
    /// </summary>
    public string? TriggeredBy { get; set; }

    /// <summary>
    /// Whether this is a retry attempt.
    /// </summary>
    public bool IsRetry { get; set; }

    /// <summary>
    /// Retry attempt number (0 for first attempt).
    /// </summary>
    public int RetryCount { get; set; }

    /// <summary>
    /// Creates a new WorkItemMessage.
    /// </summary>
    public WorkItemMessage()
    {
    }

    /// <summary>
    /// Creates a new WorkItemMessage for a specific WorkItem.
    /// </summary>
    /// <param name="workItemId">The WorkItem ID to execute.</param>
    /// <param name="correlationId">Correlation ID for tracing.</param>
    /// <param name="source">Source service creating this message.</param>
    public WorkItemMessage(int workItemId, string correlationId, string source)
        : base(correlationId, source)
    {
        WorkItemId = workItemId;
    }
}
