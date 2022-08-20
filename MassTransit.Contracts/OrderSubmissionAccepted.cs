using System;

namespace MassTransit.Contracts
{
    public interface OrderSubmissionAccepted //interface para pedido rejeitado
    {
        Guid OrderId { get; set; }
        DateTime Timestamp { get; set; }
        string CustomerNumber { get; set; }
    }
}