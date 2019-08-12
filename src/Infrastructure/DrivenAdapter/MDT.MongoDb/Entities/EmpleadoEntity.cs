using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MDT.MongoDb.Entities
{
    public class EmpleadoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}