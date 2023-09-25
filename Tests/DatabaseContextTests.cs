using Database;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests;

public class DatabaseContextTests : ServiceTestsBase
{
    [ServiceFact]
    public async void SaveChangesAsync_SavesOrderCustomerAndAddress()
    {
        DatabaseContext context = GetContext();
        Address address = new Address
        {
            Line1 = "123 Main St",
            City = "Boston",
            State = "MA",
            PostalCode = "02123",
            Country = "USA"
        };
        Order order = context.Orders.Add(new Order
        {
            Customer = new Customer
            {
                Name = "Acme",
                Address = address
            },
            Contents = "Marbles",
            BillingAddress = address,
            ShippingAddress = address
        }).Entity;
        Assert.Equal(2, await context.SaveChangesAsync());
        Customer customer = await context.Customers
            .Include(x => x.Orders)
            .SingleAsync(x => x.Id == order.Customer.Id);
        Order savedOrder = customer.Orders.First();
        Assert.Equal(address, customer.Address);
        Assert.Equal(address, savedOrder.BillingAddress);
        Assert.Equal(address, savedOrder.ShippingAddress);
    }
}