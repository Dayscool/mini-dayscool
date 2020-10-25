using BooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
    public class ActividadService
    {
        private readonly IMongoCollection<Actividad> _actividad;

        public ActividadService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _actividad = database.GetCollection<Actividad>(settings.ActividadCollectionName);
        }

        public List<Actividad> Get() =>
            _actividad.Find(book => true).ToList();

        public Actividad Get(string id) =>
            _actividad.Find<Actividad>(book => book.Id == id).FirstOrDefault();
        
        public List<Actividad> Get2(string idcurso) =>
                _actividad.Find(book => book.idCurso == idcurso).ToList();
                
        public Actividad Create(Actividad book)
        {
            _actividad.InsertOne(book);
            return book;
        }

        public void Update(string id, Actividad bookIn) =>
            _actividad.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Actividad bookIn) =>
            _actividad.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) => 
            _actividad.DeleteOne(book => book.Id == id);
    }
}