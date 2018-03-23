using System;
using System.Text;

namespace RabbitMQReadMessage.Code
{
    public class Message
    {

        public Consumer consumer;
        private string ExchangeDeclare = "FamilyExchange";
        private string QueueDeclare = "FamilyQueue";
        private string Key = "routing key";

       public Message ()
       {
            consumer = new Consumer();
        }

        public void ReadMessages()
        {
            consumer.ReadMessages(QueueDeclare);
        }

        public void Display()
        {
            Console.WriteLine(" Press [enter] to exit");
            Console.ReadLine();
        }

    }
}
