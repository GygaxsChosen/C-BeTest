using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class DeleteEmployeeController : Controller
    {
       [HttpDelete("{RealId}")]
       public void DeleteEmployeeRecord(string RealId)
        {
            Logic.BaseLogic<Employee>.DeleteOne("FreeCollection", RealId);
        }

    }
}
