using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Manager.Models
{
    public class PaymentMessage
    {
        public Guid Id { get; set; }

        public string AccountNumber {get; set;}

        public string ReferenceNumber { get; set; }

        public decimal Amount { get; set; }
    }
}
