using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostEmployeeRecordsController : Controller
    {
        Logic.EmployeeLogic<Employee> EmployeeLogic = new Logic.EmployeeLogic<Employee>();

        [HttpPost]
        public Employee PostNewEmployee([FromBody] Employee content)
        {

            Employee someEmployee = EmployeeLogic.UpdateOrCreateOne("FreeCollection", content, "");
            return someEmployee;
        }
        [HttpDelete("{RealId}")]
        public void DeleteEmployeeRecord(string RealId)
        {
            EmployeeLogic.DeleteOne("FreeCollection", RealId);
          
        }

        [HttpPut]
        public Employee EditEmployee([FromBody] Employee content)
        {
            Employee returnObject = EmployeeLogic.UpdateAndReplaceOne("FreeCollection", content);
            return returnObject;
        }
        [HttpGet]
        public string GetAllEmployees()
        {
            List<Employee> mylist = EmployeeLogic.FindMany("FreeCollection");
            string jsonString = JsonSerializer.Serialize(mylist);
            return jsonString;

        }
    }
}
