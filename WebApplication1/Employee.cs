using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Employee
    {
        private string name;
        private double salary;
        private int age;
        private string _Id;
        private string realId;


        public Employee(string Name, double Salary, int Age)
        {
            name = Name;
            salary = Salary;
            age = Age;

        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string RealId
        {
            get { return realId; }
            set { realId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        

        public Employee()
        {
          
        }
    }
}
