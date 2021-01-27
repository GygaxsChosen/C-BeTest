using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Logic
{
    public class BaseLogic <GenericType>
    {
        DataBase.EmployeeDataBase<GenericType> EmployeeWriter = new DataBase.EmployeeDataBase<GenericType>();

        public List<GenericType> FindMany(string collectionToReference)
        {
            List<GenericType> listOfEntitites = EmployeeWriter.FindMany(collectionToReference);
         return listOfEntitites;
        }
        public  GenericType UpdateAndReplaceOne(string collectionToReference, GenericType ObjectToCreate)
        {

            GenericType returnObject = EmployeeWriter.UpdateAndReplaceOne(collectionToReference, ObjectToCreate);

            return returnObject;
        }
        public  GenericType UpdateOrCreateOne(string collectionToReference, GenericType ObjectToCreate, string valueToUpdate)
        {
            var IdValue = typeof(GenericType).GetProperty("RealId").GetValue(ObjectToCreate);
    
            try
            {
                var dataLookup = FindOne(collectionToReference, IdValue.ToString());
                var IdValueOfFoundItem = typeof(GenericType).GetProperty("RealId").GetValue(ObjectToCreate);
                if (IdValueOfFoundItem.ToString() == IdValue.ToString())
                {
                    EmployeeWriter.UpdateOne(collectionToReference, ObjectToCreate, valueToUpdate);
                }

            }
            catch
            {
                EmployeeWriter.CreateOne(collectionToReference, ObjectToCreate);
              
            }

            return ObjectToCreate;


        }
        public GenericType FindOne(string collectionToReference, string Id)
        {
            return EmployeeWriter.FindOne(collectionToReference, Id);
          
        }

        public bool DeleteOne(string collectionToReference, string IdToDelete)
        {
            GenericType myObject = FindOne(collectionToReference, IdToDelete);
            var IdValue = typeof(GenericType).GetProperty("RealId").GetValue(myObject);
            if(IdValue.ToString() == IdToDelete)
            {
                EmployeeWriter.DeleteOne(collectionToReference, myObject);
              

            }
            return false;
        }
    }
}
