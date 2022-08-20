using Microsoft.Extensions.Logging;
namespace MassTransit.Components
{ 
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;
    public class SubmitOrderConsumer :
        IConsumer<SubmitOrder>
    {
        readonly ILogger<SubmitOrderConsumer> _logger;

        public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
        {
            _logger = logger;
        }
        
        public async Task Consume(ConsumeContext<SubmitOrder> context)
        {
            _logger.Log(LogLevel.Debug, "SubmitOrderConsumer: {CustomerNumber}", context.Message.CustomerNumber);
            
            if (context.Message.CustomerNumber.Contains("TEST"))
            {
                await context.RespondAsync<OrderSumissionRejected>(new
                {
                    OrderId = context.Message.OrderId,
                    Timestamp = InVar.Timestamp,
                    CustomerNumber = context.Message.CustomerNumber,
                    Reason = $"Teste de cliente submit fail ordem: {context.Message.CustomerNumber}"
                });
                
                return;
            }     
            else
            {
                await context.RespondAsync<OrderSubmissionAccepted>(new
                {
                    OrderId = context.Message.OrderId,
                    Timestamp = InVar.Timestamp,
                    CustomerNumber = context.Message.CustomerNumber
                });
            }
            
        }
    }
}