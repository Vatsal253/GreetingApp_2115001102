using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using NLog;
namespace HelloGreetingApplication.Controllers
{   /// <summary>
    /// Class providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public HelloGreetingController()
        {
            //_logger = logger;
            _logger.Info("Logger has been integrated");

        }

        [HttpGet]
        public IActionResult Get()
        {
            /// <summary>
            /// Method to Get the response from server 
            /// </summary>
            ResponseModel<string> responseModel = new ResponseModel<string>();
            _logger.Info("working");
            responseModel.Success = true;
            responseModel.Message = "Hello to Greeting App API Endpoint";
            responseModel.Data = "Hello world";
            return Ok(responseModel);

        }

        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            /// <summary>
            /// method to add an entry on the server 
            /// </summary>
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request Recieved Successfully";
            responseModel.Data = $"Key: {requestModel.key}, Value : {requestModel.value}";
            return Ok(responseModel);
        }
        /// <summary>
        /// Put method to update the greeting message
        /// </summary>
        /// <param name="requestModel">Request model containing key and value</param>
        /// <returns>Response model with updated data</returns>
        [HttpPut]
        public IActionResult Put(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Data updated successfully";
            responseModel.Data = $"Updated Key: {requestModel.key}, Updated Value: {requestModel.value}";
            return Ok(responseModel);
        }

        /// <summary>
        /// Patch method to partially update the greeting message
        /// </summary>
        /// <param name="requestModel">Request model with partial data</param>
        /// <returns>Response model with patched data</returns>
        [HttpPatch]
        public IActionResult Patch(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Data partially updated successfully";
            responseModel.Data = $"Patched Key: {requestModel.key}, Patched Value: {requestModel.value}";
            return Ok(responseModel);
        }

        /// <summary>
        /// Delete method to delete the greeting message
        /// </summary>
        /// <param name="key">Key to identify the resource</param>
        /// <returns>Response model with deletion status</returns>
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = $"Data with Key: {key} deleted successfully";
            responseModel.Data = null;
            return Ok(responseModel);
        }

    }
}