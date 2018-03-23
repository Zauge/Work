using RabbitMQ.Client;

namespace RabbitMQSendMessage.Code
{

    public class MyConnectionFactory
    {
        private string HostName = "localhost";
        private string UserName = "guest";
        private string password = "guest";

        public MyConnectionFactory()
        {
            conn();
        }

        private IConnection conn()
        {
            var factory = new ConnectionFactory();

            factory.HostName = HostName;
            factory.UserName = UserName;
            factory.Password = password;
            IConnection connection = factory.CreateConnection();

            return connection;
        }

        public IModel CreateModel()
        {
            var connection = conn();
            var model = connection.CreateModel();
            return model;
        }
    }
}
