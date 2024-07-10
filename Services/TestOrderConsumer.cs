using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TestOrderConsumer : IConsumer<TestOrder>
    {
        private readonly ILogger<TestOrderConsumer> _logger;
        public TestOrderConsumer(ILogger<TestOrderConsumer> logger)
        {
            _logger = logger;
        }
        Task IConsumer<TestOrder>.Consume(ConsumeContext<TestOrder> context)
        {
            _logger.LogInformation("Received message from Test-Order");
            return Task.CompletedTask;
        }
    }
}
