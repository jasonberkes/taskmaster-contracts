namespace TaskMaster.Contracts.Messages;

/// <summary>
/// Base class for all Service Bus messages.
/// Provides default implementations for common message properties.
/// </summary>
public abstract class MessageBase : IMessage
{
    /// <inheritdoc />
    public string MessageId { get; set; } = Guid.NewGuid().ToString();

    /// <inheritdoc />
    public string CorrelationId { get; set; } = string.Empty;

    /// <inheritdoc />
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <inheritdoc />
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// Creates a new message with default values.
    /// </summary>
    protected MessageBase()
    {
    }

    /// <summary>
    /// Creates a new message with a specific correlation ID.
    /// </summary>
    /// <param name="correlationId">The correlation ID for request tracing.</param>
    /// <param name="source">The source service creating this message.</param>
    protected MessageBase(string correlationId, string source)
    {
        CorrelationId = correlationId;
        Source = source;
    }
}
