using System;
using Newtonsoft.Json;
using RabbitMQ.Manager;
using RabbitMQ.Manager.Models;

namespace RabbitMQ.Sender
{
    class Program
    {
        #region Declaration(s)
        private const string QUEUE_NAME = "Hello";

        private static readonly Random random = new Random();
        #endregion

        #region Method(s)
        static void Main(string[] args)
        {
            try
            {
                var mq = new MessageQueue
                {
                    PaymentMessage = new PaymentMessage()
                    {
                        Id = Guid.NewGuid(),
                        AccountNumber = GetRandomNumber(10000000, 99999999).ToString(),
                        Amount = GetRandomNumber(5000,100000),
                        ReferenceNumber = "Salary",
                    }
                };

                //send serialise object to a Queue, 
                //reason for using json object was to receive a message as a string and not an object.
                string message = JsonConvert.SerializeObject(mq);

                Print(message);

                ManageRabbitMQ.Send(QUEUE_NAME, message);


                Print("New Payment Message has been sent");
            }
            catch (Exception ex)
            {
                Print(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        } 

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (random) // synchronize
            {
                return random.Next(min, max);
            }
        }
        #endregion
    }
}
