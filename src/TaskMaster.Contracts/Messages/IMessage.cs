namespace TaskMaster.Contracts.Messages;

/// <summary>
/// Base interface for all Service Bus messages.
/// Ensures consistent message structure across all microservices.
/// </summary>
public interface IMessage
{
    /// <summary>
    /// Unique identifier for this message instance.
    /// </summary>
    string MessageId { get; }

    /// <summary>
    /// Correlation ID for tracing requests across services.
    /// Should be propagated through the entire request chain.
    /// </summary>
    string CorrelationId { get; }

    /// <summary>
    /// UTC timestamp when the message was created.
    /// </summary>
    DateTime Timestamp { get; }

    /// <summary>
    /// Source service that created this message.
    /// </summary>
    string Source { get; }
}
