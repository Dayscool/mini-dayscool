using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BooksApi.Models
{
    public class Entrega
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("idUsuario")]
        [JsonProperty("idUsuario")]
        public string idUsuario{get;set;}

        [BsonElement("idActividad")]
        [JsonProperty("idActividad")]
        public string idActividad{get;set;}

        [BsonElement("Nombre")]
        [JsonProperty("Nombre")]
        public string Nombre{get;set;}

        [BsonElement("Fecha")]
        [JsonProperty("Fecha")]
        public string Fecha{get;set;}

        [BsonElement("Descripcion")]
        [JsonProperty("Descripcion")]
        public string Descripcion{get;set;}

        [BsonElement("Archivo")]
        [JsonProperty("Archivo")]
        public string Archivo{get;set;}

        [BsonElement("Calificacion")]
        [JsonProperty("Calificacion")]
        public string Calificacion{get;set;}

    }
}