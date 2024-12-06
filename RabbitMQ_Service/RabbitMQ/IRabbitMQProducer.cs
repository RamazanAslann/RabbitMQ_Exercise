namespace RabbitMQ_Service.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}
