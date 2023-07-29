using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CustomerDbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var logger = app.Logger;

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.MapGet("/customers", async (CustomerDbContext context) =>
{
    var customers = await context.Customer.ToListAsync();
    logger.ShowRetrievedCustomerCount(customers.Count);
    return Results.Ok(customers);
});

app.MapGet("/customers/{id}", async (string id, CustomerDbContext context) =>
{
    var customer = await context.Customer.FindAsync(id);
    if (customer == null)
    {
        logger.CustomerNotFound(id);
        return Results.NotFound();
    }
    logger.RetrievedCustomer(id);
    return Results.Ok(customer);
});

app.MapPost("/customers", async (Customer customer, CustomerDbContext context) =>
{
    logger.CreatingCustomer(customer.Id);
    context.Customer.Add(customer);
    await context.SaveChangesAsync();
    logger.CreatedCustomer(customer.Id);
    return Results.Created($"/customers/{customer.Id}", customer);
});

app.MapPut("/customers/{id}", async (string id, Customer customer, CustomerDbContext context) =>
{
    logger.UpdatingCustomer(id);
    var currentCustomer = await context.Customer.FindAsync(id);
    if (currentCustomer == null)
    {
        logger.CustomerNotFound(id);
        return Results.NotFound();
    }

    context.Entry(currentCustomer).CurrentValues.SetValues(customer);
    await context.SaveChangesAsync();
    logger.UpdatedCustomer(id);
    return Results.NoContent();
});

app.MapDelete("/customers/{id}", async (string id, CustomerDbContext context) =>
{
    logger.DeletingCustomer(id);
    var currentCustomer = await context.Customer.FindAsync(id);
    if (currentCustomer == null)
    {
        logger.CustomerNotFound(id);
        return Results.NotFound();
    }

    context.Customer.Remove(currentCustomer);
    await context.SaveChangesAsync();
    logger.DeletedCustomer(id);
    return Results.NoContent();
});

app.Run();
