using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQReadMessage.Code
{
    public class Consumer
    {
        MyConnectionFactory connectFactory;
        IModel Channel;

        public Consumer()
        {
            connectFactory = new MyConnectionFactory();
            connectFactory.CreatNewModel();
            Channel = connectFactory.Model;
        }

        public void ReadMessages(string queueName)
        {
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                if (message != null && message.ToLower().Contains("hello my name is, "))
                {
                  message =   message.ToLower().Replace("hello my name is, ","");

                  Console.WriteLine("Hello "+ message +", I am your father!");
                }
                
            };

            Channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
