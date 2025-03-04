using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IGreetingRL
    {
        public string Greeting(UserModel userModel);
        public bool GreetMessage(GreetingModel greetModel);
        public GreetingModel GetGreetingById(int id);
        public List<GreetingEntity> GetAllGreetings();
        public GreetingEntity EditGreeting(int id, GreetingModel greetingModel);
        public bool DeleteGreeting(int id);




    }
}
