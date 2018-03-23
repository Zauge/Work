using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQSendMessage.Code
{
   public class Message
    {

       public readonly IConnection Connection;
       public  IModel Model;

       private string ExchangeDeclare = "FamilyExchange";
       private string QueueDeclare = "FamilyQueue";
       private string Key = "routing key";

       public void CreatModel()
       {
           var connectionFactory = new MyConnectionFactory();
           Model = connectionFactory.CreateModel();
           Model.ExchangeDeclare(ExchangeDeclare, ExchangeType.Direct);
           Model.QueueDeclare(QueueDeclare, false, false, false, null);
           Model.QueueBind(QueueDeclare, ExchangeDeclare, Key);
           Model.BasicPublish(ExchangeDeclare, Key, null, message());
       }

       public void Display()
       {
           Console.WriteLine("Message Published!");
       }

       private byte[] message()
       {
           Console.WriteLine("Please Enter your name:");

           var name = "Hello my name is, " + Console.ReadLine();
           var messageBodyBytes = Encoding.UTF8.GetBytes(name);

           return messageBodyBytes;
       }

    }
}
