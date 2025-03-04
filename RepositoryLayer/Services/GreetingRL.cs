using RepositoryLayer.Interface;
using System;
using ModelLayer.Model;
using NLog;

namespace RepositoryLayer.Services
{
    public class GreetingRL : IGreetingRL
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public string Greeting(UserModel userModel)
        {
            string greetingMessage = string.Empty;

            if (!string.IsNullOrEmpty(userModel.FirstName) && !string.IsNullOrEmpty(userModel.LastName))
            {
                greetingMessage = $"Hello {userModel.FirstName} {userModel.LastName}";
            }
            else if (!string.IsNullOrEmpty(userModel.FirstName))
            {
                greetingMessage = $"Hello {userModel.FirstName}";
            }
            else if (!string.IsNullOrEmpty(userModel.LastName))
            {
                greetingMessage = $"Hello {userModel.LastName}";
            }
            else
            {
                greetingMessage = "Hello World";
            }

            _logger.Info($"Generated Greeting: {greetingMessage}");
            return greetingMessage;
        }
    }
}
