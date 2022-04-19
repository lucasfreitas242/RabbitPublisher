using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitPublisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "bomdia_1",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello, World in RabbitMQ!";

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "bomdia_1",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($" [x] Enviada: {message}");
            }
        }
    }
}
