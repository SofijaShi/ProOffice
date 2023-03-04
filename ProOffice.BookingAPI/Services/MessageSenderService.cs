namespace ProOffice.BookingAPI.Services
{
    public class MessageSenderService : IMessageSenderService
    {
        public void SendMessage(string message)
        {
            try
            {
                // in real world scenario this message will be sent to
                // message bus and another emailing microservice will
                // consume that message and handle the sending email logic
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
