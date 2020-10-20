using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class CashierForm : Form
    {
        public CashierForm()
        {
            InitializeComponent();
        }

        #region Film


        #region DataGrid

        public DataGridView DataGridfilms => dataGridFilms;

        #endregion

        #endregion

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        #region Session

        #region DataGrid

                public DataGridView DataGridsession => dataGridSession;

        #endregion


        #endregion
        
        #region Tickets

        #region DataGrid

                public DataGridView DataGridtickets => dataGridTickets;
                public Button addTicket => AddTickets;
        #endregion

        #region Поля
        public string ticketsidsession
        {
            get { return TicketsIDSession.Text; }
            set
            {
                TicketsIDSession.Text = string.Empty;
                TicketsIDSession.Text = value;
            }
        }

        public string ticketsrow
        {
            get { return TicketsRow.Text; }
            set
            {
                TicketsRow.Text = string.Empty;
                TicketsRow.Text = value;
            }
        }

        public string ticketsseats
        {
            get { return TicketsSeats.Text; }
            set
            {
                TicketsSeats.Text = string.Empty;
                TicketsSeats.Text = value;
            }
        }

        public string ticketszone
        {
            get { return TicketsZone.Text; }
            set
            {
                TicketsZone.Text = string.Empty;
                TicketsZone.Text = value;
            }
        }

        public CheckBox ticketsbooking => TicketsBooking;



        public string ticketsrecall
        {
            get { return TicketsRecall.Text; }
            set
            {
                TicketsRecall.Text = string.Empty;
                TicketsRecall.Text = value;
            }
        }



        #endregion

        #endregion

        private void AddTickets_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
