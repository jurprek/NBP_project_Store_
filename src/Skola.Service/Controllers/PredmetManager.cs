// PredmetManager
using MongoDB.Bson;
using MongoDB.Driver;
using NBP_project_Store;

public class PredmetManager : IPredmetManager
{
    private readonly IMongoCollection<BsonDocument> _laptopCollection;
    private readonly IMongoDatabase _mongoDatabase;

    public PredmetManager(IMongoDatabase mongoDatabase)
    {
        _laptopCollection = mongoDatabase.GetCollection<BsonDocument>("Laptop");
        _mongoDatabase = mongoDatabase;
    }

    public void KreirajPredmetIzLaptopa(string laptopId)
    {
        var laptopFilter = Builders<BsonDocument>.Filter.Eq("Id_Laptopa", laptopId);
        var laptopDocument = _laptopCollection.Find(laptopFilter).FirstOrDefault();

        if (laptopDocument != null)
        {
            var naziv = laptopDocument["model"].AsString;

            var predmetCollection = _mongoDatabase.GetCollection<Predmet>("Predmet");
            var newPredmet = new Predmet
            {
                Naziv = naziv,
                Id_Predmet = laptopId
            };

            predmetCollection.InsertOne(newPredmet);
        }
    }
}
