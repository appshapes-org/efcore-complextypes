namespace Domain;

public record Address
{
    public required string City { get; init; }

    public required string Country { get; init; }

    public required string Line1 { get; init; }

    public string? Line2 { get; init; }

    public required string PostalCode { get; init; }

    public required string State { get; init; }
}