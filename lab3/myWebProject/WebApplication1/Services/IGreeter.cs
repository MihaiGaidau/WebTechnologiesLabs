using Microsoft.Extensions.Configuration;

namespace WebApplication1.Services
{
    public interface IGreeter
    {
        string GetTheMessageOfheDay();

    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetTheMessageOfheDay()
        {
            return _configuration["Greeting"];
        }
    }
}