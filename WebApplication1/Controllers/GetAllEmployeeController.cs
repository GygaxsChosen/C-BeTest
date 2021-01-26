using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using MongoDB.Bson.Serialization;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAllEmployeeController : Controller
    {
       [HttpGet]
       public string GetAllEmployees()
        {
            List<Employee> mylist = Logic.BaseLogic<Employee>.FindMany("FreeCollection");
            string jsonString = JsonSerializer.Serialize(mylist);
            return jsonString;

        }



    }
}
