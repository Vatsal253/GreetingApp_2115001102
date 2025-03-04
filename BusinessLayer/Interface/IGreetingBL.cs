using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        public string GetGreet();

        public string greeting(UserModel userModel);
        public bool GreetMessage(GreetingModel greetModel);
        public GreetingModel GetGreetingById(int id);
        public List<GreetingModel> GetAllGreetings();
        public GreetingModel EditGreeting(int id, GreetingModel greetingModel);
        public bool DeleteGreeting(int id);

    }
}
