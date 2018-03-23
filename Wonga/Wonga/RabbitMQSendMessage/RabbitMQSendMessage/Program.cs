using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSendMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new Code.Message();
            message.CreatModel();
            message.Display();
        }
    }
}
