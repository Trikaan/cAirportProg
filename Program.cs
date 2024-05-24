using MongoDB.Driver;

namespace cAirportProg
{
    internal static class Program
    {
        public static IMongoCollection<Flight> flightCollection;
        public static IMongoCollection<Staff> staffCollection;
        [STAThread]
        static void Main()
        {
            var conn = "mongodb+srv://trikaanthedevourer:RMnXiHRf6As9vpnp@cairport.0wzbacv.mongodb.net/?retryWrites=true&w=majority&appName=cAirport";
            var client = new MongoClient(conn);
            try
            {
                var database = client.GetDatabase("cAirportProg");

                flightCollection = database.GetCollection<Flight>("Flights");
                staffCollection = database.GetCollection<Staff>("Staff");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new fLogin());
        }
    }
}