using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cAirportProg
{
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Passenger { get; set; }
        public string FlightDest { get; set; }
        public string Date { get; set; }
        public Flight(string passenger, string flightDest, string date)
        {
            Passenger = passenger;
            FlightDest = flightDest;
            Date = date;
        }
    }
}
