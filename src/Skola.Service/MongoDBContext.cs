using MongoDB.Bson;
using MongoDB.Driver;
using Skola.Service.Models;
using System.Collections.Generic;

namespace NBP_project_Store.Service
{
    public class MongoDBContext
    {
        private readonly IMongoCollection<Laptop> _laptops;

        public MongoDBContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("NBP_Project_Store_MongoDB");
            _laptops = database.GetCollection<Laptop>("Opis");
        }

        public List<Laptop> GetLaptops()
        {
            return _laptops.Find(laptop => true).ToList();
        }

        public Laptop GetLaptopById(string id_laptop)
        {
            return _laptops.Find(laptop => laptop.Id_Laptop == id_laptop).FirstOrDefault();
        }

        public Laptop CreateLaptop(Laptop laptop)
        {
            _laptops.InsertOne(laptop);
            return laptop;
        }

        public void UpdateLaptop(string id_laptop, Laptop laptopIn)
        {
            _laptops.ReplaceOne(laptop => laptop.Id_Laptop == id_laptop, laptopIn);
        }

        public void DeleteLaptop(string id_laptop)
        {
            _laptops.DeleteOne(laptop => laptop.Id_Laptop == id_laptop);
        }
    }
}
