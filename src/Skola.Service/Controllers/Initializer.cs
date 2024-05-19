using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Extensibility;
using NBP_project_Store.Service; // Ovdje uvozimo vaš namespace
using System.ComponentModel.Composition;
using Cassandra;
using System.Net;

[Export(typeof(IInitializer))]
public class Initializer : IInitializer
{
    private readonly IMongoDatabase _mongoDatabase;
    private readonly IPredmetManager _predmetManager;

    public Initializer(IMongoClient mongoClient, IPredmetManager predmetManager)
    {
        _mongoDatabase = mongoClient.GetDatabase("NBP_Project_Store_MongoDB");
        _predmetManager = predmetManager;
    }

    public ICollection<IPEndPoint> ContactPoints => throw new NotImplementedException();

    public Configuration GetConfiguration()
    {
        throw new NotImplementedException();
    }

    public void Initialize()
    {
        // Inicijalizirajte sve potrebne konfiguracije i ostale inicijalizacijske radnje.

        // Primjer koda za kreiranje Predmeta iz Laptopa u MongoDB-u
        _predmetManager.KreirajPredmetIzLaptopa("yourLaptopId");
    }
}
