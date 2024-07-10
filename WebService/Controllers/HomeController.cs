using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Services;


[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<MessagesController> _logger;
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public MessagesController(IPublishEndpoint publishEndpoint, ILogger<MessagesController> logger, ISendEndpointProvider sendEndpointProvider)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
        _sendEndpointProvider = sendEndpointProvider;
    }

    [HttpPost]
    public async Task Post([FromBody] ExampleMessage exampleMessage)
    {
        _logger.LogInformation("Sending Message"); 
        await _publishEndpoint.Publish(exampleMessage); 
    }

    [HttpPost]
    [Route("SendToQueue")]
    public async Task SendToQueue([FromBody] string text)
    {
        var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:Test-Order"));
        await sendEndpoint.Send(new TestOrder { QueueMessage = text });
    }
}
