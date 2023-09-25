namespace Domain;

public class Customer
{
    public required Address Address { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public List<Order> Orders { get; } = new List<Order>();
}