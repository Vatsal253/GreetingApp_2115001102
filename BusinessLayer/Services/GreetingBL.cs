using BusinessLayer.Interface;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Interface;
using System;
using System.Net.Security;

namespace BusinessLayer.Services
{
    public class GreetingBL : IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }
        public string GetGreet()
        {
            return "Hello! World";
        }
       

        public string greeting(UserModel userModel)
        {
            return _greetingRL.Greeting(userModel);
        }
    }
}

