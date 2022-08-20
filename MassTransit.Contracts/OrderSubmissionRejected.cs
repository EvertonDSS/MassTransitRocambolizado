using System;

namespace MassTransit.Contracts
{
    public interface OrderSumissionRejected //interface para pedido rejeitado
    {
        Guid OrderId { get;  }
        DateTime Timestamp { get;  }
        string CustomerNumber { get; }
        string Reason { get; }
    }
}