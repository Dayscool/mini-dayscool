using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class EntregaService
    {
        private readonly IMongoCollection<Entrega> _entregas;

        public EntregaService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _entregas = database.GetCollection<Entrega>(settings.EntregaCollectionName);
        }

        public List<Entrega> Get() =>
            _entregas.Find(book => true).ToList();

        public Entrega Get(string id) =>
            _entregas.Find<Entrega>(book => book.Id == id).FirstOrDefault();

        public Entrega Create(Entrega book)
        {
            _entregas.InsertOne(book);
            return book;
        }

        public void Update(string id, Entrega bookIn) =>
            _entregas.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Entrega bookIn) =>
            _entregas.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) => 
            _entregas.DeleteOne(book => book.Id == id);
    }
}