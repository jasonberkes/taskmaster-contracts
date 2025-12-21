namespace TaskMaster.Contracts;

/// <summary>
/// Execution provider identifiers for WorkItem processing.
/// Used to route WorkItems to the appropriate execution agent.
/// </summary>
public static class ExecutionProviders
{
    /// <summary>
    /// Claude Code CLI worker - primary code execution agent.
    /// Uses Anthropic's Claude Code CLI tool.
    /// </summary>
    public const string ClaudeCode = "ClaudeCode";

    /// <summary>
    /// Claude API - direct API calls without CLI.
    /// For non-code tasks that don't need file system access.
    /// </summary>
    public const string ClaudeApi = "ClaudeApi";

    /// <summary>
    /// OpenAI execution agent (future).
    /// For tasks better suited to GPT models.
    /// </summary>
    public const string OpenAI = "OpenAI";

    /// <summary>
    /// Google Gemini execution agent (future).
    /// </summary>
    public const string Gemini = "Gemini";

    /// <summary>
    /// Human execution - no auto-processing.
    /// WorkItem waits for manual human completion.
    /// </summary>
    public const string Human = "Human";

    /// <summary>
    /// Security audit agent (future).
    /// Specialized agent for security-focused code analysis.
    /// </summary>
    public const string SecurityAgent = "SecurityAgent";

    /// <summary>
    /// Database migration agent (future).
    /// Specialized agent for database schema changes.
    /// </summary>
    public const string DatabaseAgent = "DatabaseAgent";

    /// <summary>
    /// Documentation agent (future).
    /// Specialized agent for documentation tasks.
    /// </summary>
    public const string DocumentationAgent = "DocumentationAgent";

    /// <summary>
    /// Check if a provider is a valid known provider.
    /// </summary>
    public static bool IsValid(string provider)
    {
        return provider switch
        {
            ClaudeCode or ClaudeApi or OpenAI or Gemini or Human
                or SecurityAgent or DatabaseAgent or DocumentationAgent => true,
            _ => false
        };
    }

    /// <summary>
    /// Check if a provider supports automated execution.
    /// </summary>
    public static bool IsAutomated(string provider)
    {
        return provider != Human;
    }
}
