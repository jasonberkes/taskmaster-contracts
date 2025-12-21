namespace TaskMaster.Contracts;

/// <summary>
/// Azure Service Bus topic names used across TaskMaster microservices.
/// Topics are used for pub/sub event distribution.
/// </summary>
public static class TopicNames
{
    /// <summary>
    /// Topic for WorkItem lifecycle events.
    /// Events: Created, Queued, Completed, Failed, StatusChanged
    /// </summary>
    public const string WorkItemEvents = "workitem-events";

    /// <summary>
    /// Topic for TaskExecution events.
    /// Events: Started, PhaseChanged, Completed, Failed
    /// </summary>
    public const string ExecutionEvents = "execution-events";

    /// <summary>
    /// Topic for Pull Request events.
    /// Events: Created, Reviewed, Merged, Closed
    /// </summary>
    public const string PullRequestEvents = "pr-events";

    /// <summary>
    /// Topic for code review events.
    /// Events: Requested, Started, Completed, FindingsProcessed
    /// </summary>
    public const string CodeReviewEvents = "codereview-events";

    /// <summary>
    /// Topic for issue events.
    /// Events: Ingested, Updated, Promoted, Resolved
    /// </summary>
    public const string IssueEvents = "issue-events";

    /// <summary>
    /// Topic for system-wide events.
    /// Events: HealthChanged, DeploymentCompleted, ConfigurationChanged
    /// </summary>
    public const string SystemEvents = "system-events";
}
