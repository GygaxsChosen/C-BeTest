using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class PostEmployeeRecordsController : ControllerBase
    {
    
        [HttpPost]
        public Employee PostNewEmployee([FromBody] Employee content)
        {
            Employee returnObject = Logic.BaseLogic<Employee>.UpdateOrCreateOne("FreeCollection", content, "");
            return returnObject;
        }

        [HttpPut]
        public Employee EditEmployee([FromBody] Employee content)
        {
            Employee returnObject = Logic.BaseLogic<Employee>.UpdateAndReplaceOne("FreeCollection", content);
            return returnObject;
        }
    }
}
