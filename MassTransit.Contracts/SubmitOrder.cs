using System;

namespace MassTransit.Contracts
{
    public interface SubmitOrder //interface padrão para enviar pedido
    {
        Guid OrderId { get; set; }
        DateTime Timestamp { get; set; }
        
        string CustomerNumber { get; set; }
    }
}