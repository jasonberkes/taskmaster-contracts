namespace TaskMaster.Contracts.Messages;

/// <summary>
/// Message sent to report an issue from any detection source.
/// Used by SonarQube, CodeReview, GlitchTip, CI/CD integrations.
/// Matches the IssueReport model in TaskMaster.Issues module.
/// </summary>
public class IssueReportMessage : MessageBase
{
    /// <summary>
    /// Detection source identifier.
    /// Values: "SonarQube", "CodeReview", "GlitchTip", "CICD", "Manual"
    /// </summary>
    public string DetectionSource { get; set; } = string.Empty;

    /// <summary>
    /// GitHub repository owner.
    /// </summary>
    public string GitHubRepoOwner { get; set; } = string.Empty;

    /// <summary>
    /// GitHub repository name.
    /// </summary>
    public string GitHubRepoName { get; set; } = string.Empty;

    /// <summary>
    /// Issue category.
    /// Values: "Security", "Bug", "CodeSmell", "Performance", "Style"
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Issue severity.
    /// Values: "Critical", "High", "Medium", "Low", "Info"
    /// </summary>
    public string Severity { get; set; } = "Medium";

    /// <summary>
    /// Rule ID from the detection tool (e.g., SonarQube rule ID).
    /// </summary>
    public string? RuleId { get; set; }

    /// <summary>
    /// Human-readable description of the rule/issue.
    /// </summary>
    public string? RuleDescription { get; set; }

    /// <summary>
    /// File path where the issue was detected.
    /// </summary>
    public string FilePath { get; set; } = string.Empty;

    /// <summary>
    /// Line number where the issue starts.
    /// </summary>
    public int? LineNumber { get; set; }

    /// <summary>
    /// Line number where the issue ends.
    /// </summary>
    public int? EndLineNumber { get; set; }

    /// <summary>
    /// Code snippet showing the issue.
    /// </summary>
    public string? CodeSnippet { get; set; }

    /// <summary>
    /// Number of production errors associated with this issue.
    /// </summary>
    public int ProductionErrorCount { get; set; }

    /// <summary>
    /// Whether this issue is in a critical code path.
    /// </summary>
    public bool IsInCriticalPath { get; set; }

    /// <summary>
    /// Commit SHA where this issue was introduced.
    /// </summary>
    public string? IntroducedInCommit { get; set; }

    /// <summary>
    /// PR number where this issue was introduced.
    /// </summary>
    public int? IntroducedInPR { get; set; }

    /// <summary>
    /// User who introduced this issue.
    /// </summary>
    public string? IntroducedBy { get; set; }

    /// <summary>
    /// Additional metadata as JSON string.
    /// </summary>
    public string? Metadata { get; set; }

    /// <summary>
    /// Creates a new IssueReportMessage.
    /// </summary>
    public IssueReportMessage()
    {
    }

    /// <summary>
    /// Creates a new IssueReportMessage from a detection source.
    /// </summary>
    public IssueReportMessage(string detectionSource, string correlationId)
        : base(correlationId, detectionSource)
    {
        DetectionSource = detectionSource;
    }
}
