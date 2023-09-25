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
        Customer customer = context.Customers.Add(new Customer
        {
            Name = "Acme",
            Address = address
        }).Entity;
        Order order = context.Orders.Add(new Order
        {
            Customer = customer,
            Contents = "Marbles",
            BillingAddress = address,
            ShippingAddress = address
        }).Entity;
        Assert.Equal(2, await context.SaveChangesAsync());
        Customer savedCustomer = await context.Customers
            .SingleAsync(x => x.Id == customer.Id);
        Order savedOrder = await context.Orders
            .SingleAsync(x => x.Id == order.Id);
        Assert.Equal(address, savedCustomer.Address);
        Assert.Equal(address, savedOrder.BillingAddress);
        Assert.Equal(address, savedOrder.ShippingAddress);
    }
}