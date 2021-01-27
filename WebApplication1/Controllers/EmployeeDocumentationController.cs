using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDocumentationController : BaseController<DocumentationData>
    {
        Logic.EmployeeLogic<DocumentationData> EmployeeLogic = new Logic.EmployeeLogic<DocumentationData>();
        [HttpPost]
        public DocumentationData UpdateOrCreateEmployeeDocumentation( DocumentationData data)
        {
            DocumentationData returnObject = EmployeeLogic.UpdateOrCreateOne("EmployeeDocumentation", data, "DocumentationText");
             return returnObject;
        }
     
        [HttpGet("{RealId}")]
        public string LookupEmployeeDocumentationController(string RealId)
        {
            DocumentationData Documentation = FindOne("EmployeeDocumentation", RealId);
            string jsonString = JsonSerializer.Serialize(Documentation);

            return jsonString;
        }
       

    }
}
