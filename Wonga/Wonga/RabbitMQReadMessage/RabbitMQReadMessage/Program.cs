using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQReadMessage
{
    class Program
    {
        static void Main(string[] args)
        {
           var messages = new Code.Message();
            messages.ReadMessages();
        }
    }
}
