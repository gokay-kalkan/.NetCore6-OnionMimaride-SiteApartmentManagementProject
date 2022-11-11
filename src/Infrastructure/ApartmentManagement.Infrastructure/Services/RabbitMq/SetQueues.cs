

using RabbitMQ.Client;

namespace ApartmentManagement.Infrastructure.Services.RabbitMq
{
    public  class SetQueues
    {
        public static void SetQueue(byte[]datas )
        {
            var factory = new ConnectionFactory();
            factory.Uri =new Uri("amqps://oqnrvvfh:RgxRf5ptbCsdzZSHXzDn3dpnXPw_5n1U@beaver.rmq.cloudamqp.com/oqnrvvfh");

             var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

           var quee= channel.QueueDeclare("sendDuesPayment", true, false, false);

            channel.BasicPublish(String.Empty, "sendDuesPayment",null,datas);
            
        }
    }
}
