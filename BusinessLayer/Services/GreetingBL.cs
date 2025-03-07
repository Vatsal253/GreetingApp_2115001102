using BusinessLayer.Interface;
using ModelLayer.Model;
using NLog;
using RepositoryLayer.Interface;
using System;


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
       

        public string greeting(UserNameModel userModel)
        {
            return _greetingRL.Greeting(userModel);
        }
        public bool GreetMessage(GreetingModel greetModel)
        {
            return _greetingRL.GreetMessage(greetModel);
        }
        public GreetingModel GetGreetingById(int id)
        {
            return _greetingRL.GetGreetingById(id);
        }
        public List<GreetingModel> GetAllGreetings()
        {
            var entityList = _greetingRL.GetAllGreetings();  // Calling Repository Layer
            if (entityList != null)
            {
                return entityList.Select(g => new GreetingModel
                {
                    Id = g.id,
                    GreetMessage = g.Greeting
                }).ToList();  // Converting List of Entity to List of Model
            }
            return null;
        }
        public GreetingModel EditGreeting(int id, GreetingModel greetingModel)
        {
            var result = _greetingRL.EditGreeting(id, greetingModel); // Calling Repository Layer
            if (result != null)
            {
                return new GreetingModel()
                {
                    Id = result.id,
                    GreetMessage = result.Greeting
                };
            }
            return null;
        }
        public bool DeleteGreeting(int id)
        {
            var result = _greetingRL.DeleteGreeting(id); 
            if (result)
            {
                return true; // Successfully Deleted
            }
            return false; // Not Found
        }





    }
}

