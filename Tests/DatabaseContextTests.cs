using Database;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests;

public class DatabaseContextTests : ServiceTestsBase
{
    [ServiceFact]
    public async void SaveChangesAsync_SavesCustomerAndAddress()
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
        Customer customer = context.Customers.Add(new Customer { Name = "Acme", Address = address }).Entity;
        Assert.Equal(1, await context.SaveChangesAsync());
        Assert.NotNull(await context.Customers.SingleOrDefaultAsync(x => x.Id == customer.Id));
    }
}