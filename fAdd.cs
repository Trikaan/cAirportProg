namespace cAirportProg
{
    public partial class fAdd : Form
    {
        public fAdd()
        {
            InitializeComponent();

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string item = tbItem.Text;
            string cust = tbCust.Text;
            string date = tbDate.Text;

            Flight newOrder = new Flight(item, cust, date);

            try
            {
                Program.flightCollection.InsertOne(newOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("The flight was inserted successfully!");
                Close();
            }
        }
    }
}
