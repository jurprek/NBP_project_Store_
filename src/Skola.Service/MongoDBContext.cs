using MongoDB.Bson;
using MongoDB.Driver;
using Skola.Service.Models;

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

        public Laptop GetLaptopById(string predmetId)
        {
            return _laptops.Find<Laptop>(laptop => laptop.PredmetId == predmetId).FirstOrDefault();
        }

        public Laptop CreateLaptop(Laptop laptop)
        {
            _laptops.InsertOne(laptop);
            return laptop;
        }

        public void UpdateLaptop(string predmetId, Laptop laptopIn)
        {
            _laptops.ReplaceOne(laptop => laptop.PredmetId == predmetId, laptopIn);
        }

        public void DeleteLaptop(string predmetId)
        {
            _laptops.DeleteOne(laptop => laptop.PredmetId == predmetId);
        }
    }
}
