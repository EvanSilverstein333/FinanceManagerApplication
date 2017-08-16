using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using System.ServiceModel;
using FinanceManager.Contract.Events;
using System.Diagnostics;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;

namespace WebClient.Infrastructure.Abstractions
{
    public class FinanceManagerMessageCallback : IDisposable
    {
        private static IConnection _connection;
        
        static FinanceManagerMessageCallback()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            SubscribeToMessages();
        }

        private static void SubscribeToMessages()
        {

            var channel = _connection.CreateModel();
            channel.ExchangeDeclare(exchange: "direct_events", type: "direct");

            var queueName = channel.QueueDeclare().QueueName;

            foreach (var e in GetEventTypes())
            {
                channel.QueueBind(queue: queueName,
                                    exchange: "direct_events",
                                    routingKey: e.ToString());
            }

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Message_Received;

            channel.BasicConsume(queue: queueName,
                                    autoAck: true,
                                    consumer: consumer);
            
        }

        private static void Message_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            String jsonified = Encoding.UTF8.GetString(e.Body);
            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var message = JsonConvert.DeserializeObject(jsonified,jsonSerializerSettings);
        }

        private static Type[] GetEventTypes()
        {
            var eventTypes = new Type[]
            {
                typeof(FinancialAccountAddedEvent),
                typeof(FinancialAccountChangedEvent)
            };
            return eventTypes;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
