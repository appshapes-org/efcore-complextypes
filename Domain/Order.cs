namespace Domain;

public class Order
{
    public required Address BillingAddress { get; set; }

    public required string Contents { get; set; }

    public Customer Customer { get; set; } = null!;

    public Guid Id { get; set; } = Guid.NewGuid();

    public required Address ShippingAddress { get; set; }
}