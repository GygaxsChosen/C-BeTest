using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class BaseController<GenricType> : Controller
    {
        Logic.BaseLogic<GenricType> BaseLogic = new Logic.BaseLogic<GenricType>();
        public GenricType PostNewEntity(string CollectionToHit, GenricType content)
        {
            GenricType ReturnObject = BaseLogic.UpdateOrCreateOne(CollectionToHit, content, "");
            return ReturnObject;
        }

        public void DeleteOneEntity(string CollectionToHit, string RealId)
        {
            BaseLogic.DeleteOne(CollectionToHit, RealId);
        }

        public List<GenricType> FindMany(string CollectionToHit)
        {
            return BaseLogic.FindMany(CollectionToHit);
        }
        public GenricType FindOne(string CollectionToHit, string Id)
        {
            return BaseLogic.FindOne(CollectionToHit, Id);

        }
    }
}
