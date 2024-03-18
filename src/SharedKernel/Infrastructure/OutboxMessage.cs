namespace SharedKernel.Infrastructure;

public class OutboxMessage(int? id, DateTime occurredUtc, string type, string data, DateTime? processedUtc = null)
{
    public int? Id { get; init; } = id;
    public DateTime OccurredUtc { get; init; } = occurredUtc;
    public string Type { get; init; } = type;
    public string Data { get; init; } = data;
    public DateTime? ProcessedUtc { get; set; } = processedUtc;
}