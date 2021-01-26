using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Logic
{
    public class BaseLogic <GenericType>
    {
        public static  List<GenericType> FindMany(string collectionToReference)
        {
            List<GenericType> listOfEntitites = DataBase.BaseDatabase<GenericType>.FindMany(collectionToReference);
            return listOfEntitites;
        }
        public static GenericType UpdateAndReplaceOne(string collectionToReference, GenericType ObjectToCreate)
        {
             GenericType returnObject = DataBase.BaseDatabase<GenericType>.UpdateAndReplaceOne(collectionToReference, ObjectToCreate);
            return returnObject;
        }
        public static GenericType UpdateOrCreateOne(string collectionToReference, GenericType ObjectToCreate, string valueToUpdate)
        {
            var IdValue = typeof(GenericType).GetProperty("RealId").GetValue(ObjectToCreate);
    
            try
            {
                var dataLookup = FindOne(collectionToReference, IdValue.ToString());
                var IdValueOfFoundItem = typeof(GenericType).GetProperty("RealId").GetValue(ObjectToCreate);
                if (IdValueOfFoundItem.ToString() == IdValue.ToString())
                {

                    DataBase.BaseDatabase<GenericType>.UpdateOne(collectionToReference, ObjectToCreate, valueToUpdate);
                 
                }

            }
            catch
            {
                DataBase.BaseDatabase<GenericType>.CreateOne(collectionToReference, ObjectToCreate);
              
            }

            return ObjectToCreate;


        }
        public static GenericType FindOne(string collectionToReference, string Id)
        {
           return DataBase.BaseDatabase<GenericType>.FindOne(collectionToReference, Id);

        }

        public static bool DeleteOne(string collectionToReference, string IdToDelete)
        {
            GenericType myObject = FindOne(collectionToReference, IdToDelete);
            var IdValue = typeof(GenericType).GetProperty("RealId").GetValue(myObject);
            if(IdValue.ToString() == IdToDelete)
            {
                DataBase.BaseDatabase<GenericType>.DeleteOne(collectionToReference, myObject);

            }
            return false;
        }
    }
}
