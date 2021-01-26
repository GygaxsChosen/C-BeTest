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
    public class EmployeeDocumentationController : Controller
    {
        [HttpPost]
        public DocumentationData UpdateOrCreateEmployeeDocumentation( DocumentationData data)
        {

           DocumentationData returnObject = Logic.BaseLogic<DocumentationData>.UpdateOrCreateOne("EmployeeDocumentation", data, "DocumentationText");

            return returnObject;
        }
     
        [HttpGet("{RealId}")]
        public string LookupEmployeeDocumentationController(string RealId)
        {
            DocumentationData Documentation = Logic.BaseLogic<DocumentationData>.FindOne("EmployeeDocumentation", RealId);

            string jsonString = JsonSerializer.Serialize(Documentation);

            return jsonString;
        }

    }
}
