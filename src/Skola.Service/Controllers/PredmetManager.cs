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
        var laptopFilter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(laptopId));
        var laptopDocument = _laptopCollection.Find(laptopFilter).FirstOrDefault();

        if (laptopDocument != null)
        {
            var naziv = laptopDocument["model"].AsString;
            var poslovnicaId = laptopDocument["poslovnicaId"].AsString;

            var poslovnicaCollection = _mongoDatabase.GetCollection<Poslovnica>("Poslovnica");
            var poslovnica = poslovnicaCollection.Find(p => p.Id_Poslovnica == poslovnicaId).FirstOrDefault();

            if (poslovnica != null)
            {
                var predmetCollection = _mongoDatabase.GetCollection<Predmet>("Predmet");
                var newPredmet = new Predmet
                {
                    Naziv = naziv,
                   // Poslovnica = poslovnica
                };

                predmetCollection.InsertOne(newPredmet);
            }
        }
    }
}
