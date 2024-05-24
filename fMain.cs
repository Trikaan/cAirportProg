using MongoDB.Driver;

namespace cAirportProg
{
    public partial class fMain : Form
    {
        int iter = 1;
        private void updateGrid()
        {
            var flights = Program.flightCollection.Find(_ => true).ToList();

            dGrid.DataSource = flights;
        }
        public fMain()
        {
            InitializeComponent();

            updateGrid();
            dGrid.Columns["Id"].Visible = false;
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addFlightForm = new fAdd();
            addFlightForm.ShowDialog();

            updateGrid();
        }
        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dGrid.CurrentRow.Selected = true;

            string item = dGrid.Rows[e.RowIndex].Cells["Passenger"].Value.ToString();
            string cust = dGrid.Rows[e.RowIndex].Cells["Flight"].Value.ToString();
            string date = dGrid.Rows[e.RowIndex].Cells["Date"].Value.ToString();

            string message, caption;

            switch (iter)
            {
                case 0:
                    message = "Are you sure you want to delete this flight?";
                    caption = "";
                    if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Program.flightCollection.DeleteOne(o => o.Passenger == item && o.FlightDest == cust && o.Date == date);

                        updateGrid();
                    }
                    break;
                case 1:
                    Flight newFlight = new Flight(item, cust, date);

                    message = "Are you sure you want to change this flight?";
                    caption = "";
                    if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var changeFlightForm = new fChange(newFlight);
                        changeFlightForm.ShowDialog();

                        updateGrid();
                    }
                    break;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iter = 0;
            toolStripTextBox2.Text = "Delete";
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iter = 1;
            toolStripTextBox2.Text = "Update";
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manualForm = new fManual();
            manualForm.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var findForm = new fFind();
            findForm.ShowDialog();

            findAndSet(findForm.filters);
        }
        public void findAndSet(string[] array)
        {
            if (array[0] != "" && array[1] != "" && array[2] != "")//1 2 3
            {
                var orders = Program.flightCollection.Find(o => o.Passenger == array[0] && o.FlightDest == array[1] && o.Date == array[2]).ToList();
                dGrid.DataSource = orders;
            }
            else if (array[0] != "" && array[1] != "" && array[2] == "")//1 2
            {
                var orders = Program.flightCollection.Find(o => o.Passenger == array[0] && o.FlightDest == array[1]).ToList();
                dGrid.DataSource = orders;
            }
            else if (array[0] != "" && array[1] == "" && array[2] == "")//1
            {
                var orders = Program.flightCollection.Find(o => o.Passenger == array[0]).ToList();
                dGrid.DataSource = orders;
            }
            else if (array[0] == "" && array[1] != "" && array[2] == "")//2
            {
                var orders = Program.flightCollection.Find(o => o.FlightDest == array[1]).ToList();
                dGrid.DataSource = orders;
            }
            else if (array[0] == "" && array[1] == "" && array[2] != "")//3
            {
                var orders = Program.flightCollection.Find(o => o.Date == array[2]).ToList();
                dGrid.DataSource = orders;
            }
            else if (array[0] == "" && array[1] != "" && array[2] != "")//2 3
            {
                var orders = Program.flightCollection.Find(o => o.FlightDest == array[1] && o.Date == array[2]).ToList();
                dGrid.DataSource = orders;
            }
            else if (array[0] != "" && array[1] == "" && array[2] != "")//1 3
            {
                var orders = Program.flightCollection.Find(o => o.Passenger == array[0] && o.Date == array[2]).ToList();
                dGrid.DataSource = orders;
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }
    }
}