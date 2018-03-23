using RabbitMQ.Client;

namespace RabbitMQReadMessage.Code
{
    public class MyConnectionFactory
    {
        private string HostName = "localhost";
        private string UserName = "guest";
        private string password = "guest";
        private string ExchangeDeclare = "FamilyExchange";
        private string QueueDeclare = "FamilyQueue";
        private string Key = "routing key";
        public IModel Model;

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

        public void CreatNewModel()
        {
            Model = conn().CreateModel();
            Model.ExchangeDeclare(ExchangeDeclare, ExchangeType.Direct);
            Model.QueueDeclare(QueueDeclare, false, false, false, null);
            Model.QueueBind(QueueDeclare, ExchangeDeclare, Key);
        }


    }
}
