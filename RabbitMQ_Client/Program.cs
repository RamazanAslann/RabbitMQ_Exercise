// See https://aka.ms/new-console-template for more information
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_Service;



public class Mainclass() {
    public static void Main()
    {
        var factory = new ConnectionFactory()
        {
            Uri = new Uri("amqps://kvoqhsut:DjofD1VnByDLGSODZ3nV-6MEq3upu5Oy@shark.rmq.cloudamqp.com/kvoqhsut")
        };

        using var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        channel.QueueDeclare("sms", exclusive: false, autoDelete: false);

        

        var consumer = new EventingBasicConsumer(channel);

        channel.BasicConsume(queue:"sms", consumer:consumer);

        consumer.Received += Consumer_Received;


    }

    private static void Consumer_Received(object? sender, BasicDeliverEventArgs e)
    {
        var body = e.Body.ToArray();

        var message = Encoding.UTF8.GetString(body);

        Console.WriteLine($"Received:{message}");
        Console.ReadLine();


    }
}



