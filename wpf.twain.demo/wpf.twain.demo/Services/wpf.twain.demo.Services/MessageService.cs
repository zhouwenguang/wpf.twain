using wpf.twain.demo.Services.Interfaces;

namespace wpf.twain.demo.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
