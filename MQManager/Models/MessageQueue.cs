using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Manager.Models
{
    /// <summary>
    /// This is suppose to be in a client side
    /// </summary>
    public class MessageQueue
    {
        public PaymentMessage PaymentMessage { get; set; }
    }
}
