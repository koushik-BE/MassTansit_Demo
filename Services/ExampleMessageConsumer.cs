using MassTransit;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class ExampleMessageConsumer : IConsumer<ExampleMessage>
    {
        private readonly ILogger<ExampleMessageConsumer> _logger;

        public ExampleMessageConsumer(ILogger<ExampleMessageConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ExampleMessage> context)
        {
            _logger.LogInformation($"Received message: {context.Message.Text}");
            await Task.CompletedTask;
        }
    }
}
