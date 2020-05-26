using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightAdmin.DAL.Entities
{
    public class DbFlight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FlightNumber { get; set; }
        public string DepartureCode { get; set; }
        public string DestinationCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public List<string> Remarks { get; set; }

        public DbFlight()
        {
            Remarks = new List<string>();
        }
    }
}