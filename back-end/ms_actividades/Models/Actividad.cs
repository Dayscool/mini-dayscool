using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BooksApi.Models
{
    public class Actividad
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("idCurso")]
        [JsonProperty("idCurso")]
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string idCurso { get; set; }

        [BsonElement("Nombre")]
        [JsonProperty("Nombre")]
        public String Nombre{get;set;}

        [BsonElement("Fecha")]
        [JsonProperty("Fecha")]
        public String Fecha{get;set;}

        [BsonElement("FechaEntrega")]
        [JsonProperty("FechaEntrega")]
        public String FechaEntrega{get;set;}

        [BsonElement("Descripcion")]
        [JsonProperty("Descripcion")]
        public String Descripcion{get;set;}

        [BsonElement("Archivo")]
        [JsonProperty("Archivo")]
        public String Archivo{get;set;}
    }
}