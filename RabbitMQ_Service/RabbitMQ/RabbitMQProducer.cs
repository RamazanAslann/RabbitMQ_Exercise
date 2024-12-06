using System.Text;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ_Service.Models;

namespace RabbitMQ_Service.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage<T>(T message)
        {
            var connectionHost = _configuration.GetSection("RabbitMQConfiguration:Connection").Value;

           

           var factory = new ConnectionFactory
           {
              
               Uri =new Uri(connectionHost)

           };

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("sms",exclusive:false,autoDelete:false);

            var json = JsonConvert.SerializeObject(message);

            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange:"",routingKey:"sms",body:body);


        }
    }
}
