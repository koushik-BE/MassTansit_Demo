using MassTransit;
using Microsoft.Extensions.Hosting;
using Services;

IHostBuilder builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(services =>
{
    services.AddMassTransit(x =>
    {
        x.AddConsumers(typeof(ExampleMessage).Assembly);

        x.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host("localhost", "/", c =>
            {
                c.Username("guest");
                c.Password("guest");
            });

            cfg.ConfigureEndpoints(ctx);

            cfg.ReceiveEndpoint("Test-Order", e =>
            {
                e.ConfigureConsumer<TestOrderConsumer>(ctx);
            });
        });
    });
});

await builder.Build().RunAsync();

