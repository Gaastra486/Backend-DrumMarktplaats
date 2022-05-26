namespace SharedLibrary
{
    public class RabbitMQSettings
    {
        // RabbitMQ properties;

        public readonly string Username = "guest";
        public readonly string Password = "guest";
        // You can put in localhost if you decide to run it locally, otherwise put down the IP address of the server which you're trying to connect to;
        public readonly string IPAddress = "localhost:5672";
        public readonly string QueueName = "bid-queue";
    }
}
