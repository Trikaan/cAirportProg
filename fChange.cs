using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace cAirportProg
{
    public partial class fChange : Form
    {
        public Flight anOrder;
        public fChange(Flight flight = null)
        {
            InitializeComponent();
            tbItem.Text = flight.Passenger.ToString();
            tbCust.Text = flight.FlightDest.ToString();
            tbDate.Text = flight.Date.ToString();
            anOrder = flight;
        }

        private void bChange_Click(object sender, EventArgs e)
        {
            string new_Item = tbItem.Text;
            string new_Cust = tbCust.Text;
            string new_Date = tbDate.Text;

            var update1 = Builders<Flight>.Update.Set(o => o.Passenger, new_Item);
            var update2 = Builders<Flight>.Update.Set(o => o.FlightDest, new_Cust);
            var update3 = Builders<Flight>.Update.Set(o => o.Date, new_Date);

            Program.flightCollection.UpdateOne(o => o.Passenger == anOrder.Passenger && o.FlightDest == anOrder.FlightDest && o.Date == anOrder.Date, update1);
            Program.flightCollection.UpdateOne(o => o.Passenger == anOrder.Passenger && o.FlightDest == anOrder.FlightDest && o.Date == anOrder.Date, update2);
            Program.flightCollection.UpdateOne(o => o.Passenger == anOrder.Passenger && o.FlightDest == anOrder.FlightDest && o.Date == anOrder.Date, update3);
            
            Close();
        }
    }
}
