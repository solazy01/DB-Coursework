using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Security;

namespace CourseWork
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        #region Film


        #region DataGrid

        public DataGridView DataGridfilms => dataGridFilms;

        #endregion

        #region Поля

        public string idfilm
        {
            get { return IDFilm.Text; }
            set
            {
                IDFilm.Text = string.Empty;
                IDFilm.Text = value;
            }
        }

        public string titlefilm
        {
            get { return TitleFilm.Text; }
            set
            {
                TitleFilm.Text = string.Empty;
                TitleFilm.Text = value;
            }
        }

        public string countryfilm
        {
            get { return CountryFilm.Text; }
            set
            {
                CountryFilm.Text = string.Empty;
                CountryFilm.Text = value;
            }
        }

        public string producerFilm
        {
            get { return ProducerFilm.Text; }
            set
            {
                ProducerFilm.Text = string.Empty;
                ProducerFilm.Text = value;
            }
        }

        public string durationFilm
        {
            get { return DurationFilm.Text; }
            set
            {
                DurationFilm.Text = string.Empty;
                DurationFilm.Text = value;
            }
        }

        public string dateFilm
        {
            get { return DateFilm.Text; }
            set
            {
                DateFilm.Text = string.Empty;
                DateFilm.Text = value;
            }
        }

        public string genreFilm
        {
            get { return GanreFilm.Text; }
            set
            {
                GanreFilm.Text = string.Empty;
                GanreFilm.Text = value;
            }
        }

        public string priceFilm
        {
            get { return PriceFilm.Text; }
            set
            {
                PriceFilm.Text = string.Empty;
                PriceFilm.Text = value;
            }
        }

        #endregion

        #region Кнопки

        public Button addFilm => AddFilm;
        public Button deleteFilm => DeleteFilm;
        public Button updateFilm => UpdateFilm;

        #endregion

        #region Обработчики
        private void dataGridFilms_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddFilm_Click(object sender, EventArgs e)
        {

        }

        private void DeleteFilm_Click(object sender, EventArgs e)
        {

        }

        private void UpdateFilm_Click(object sender, EventArgs e)
        {

        }


        #endregion



        #endregion

        #region Session

        #region DataGrid

        public DataGridView DataGridsession => dataGridSession;

        #endregion

        #region Поля

        public string idsession
        {
            get { return IDSession.Text; }
            set
            {
                IDSession.Text = string.Empty;
                IDSession.Text = value;
            }
        }

        public ComboBox sessionidfilm => SessionIDFilm;
        

        public string sessiondate
        {
            get { return SessionDate.Text; }
            set
            {
                SessionDate.Text = string.Empty;
                SessionDate.Text = value;
            }
        }

        public string sessiontime
        {
            get { return SessionTime.Text; }
            set
            {
                SessionTime.Text = string.Empty;
                SessionTime.Text = value;
            }
        }

        public string sessionidhall
        {
            get { return SessionIDHall.Text; }
            set
            {
                SessionIDHall.Text = string.Empty;
                SessionIDHall.Text = value;
            }
        }

        #endregion

        #region Кнопки

        public Button addSession => AddSession;
        public Button deleteSession => DeleteSession;
        public Button updateSession => UpdateSession;

        #endregion

        #region Обработчики
        private void dataGridSession_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddSession_Click(object sender, EventArgs e)
        {

        }

        private void DeleteSession_Click(object sender, EventArgs e)
        {

        }

        private void UpdateSession_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #endregion

        #region Tickets

        #region DataGrid

        public DataGridView DataGridtickets => dataGridTickets;

        #endregion

        #region Поля

        public string idticket
        {
            get { return IDTicket.Text; }
            set
            {
                IDTicket.Text = string.Empty;
                IDTicket.Text = value;
            }
        }

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

        #region Кнопки

        public Button addTicket => AddTickets;
        public Button deleteTicket => DeleteTickets;
        public Button updateTicket => UpdateTickets;

        #endregion

        #region Обработчики
        private void dataGridTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddTickets_Click(object sender, EventArgs e)
        {

        }

        private void DeleteTickets_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTickets_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #endregion

        #region Staff

        #region DataGrid

        public DataGridView DataGridstaff => dataGridStaff;

        #endregion

        #region Поля

        public string idstaff
        {
            get { return IDStaff.Text; }
            set
            {
                IDStaff.Text = string.Empty;
                IDStaff.Text = value;
            }
        }

        public string stafffname
        {
            get { return StaffFname.Text; }
            set
            {
                StaffFname.Text = string.Empty;
                StaffFname.Text = value;
            }
        }

        public string stafflname
        {
            get { return StaffLname.Text; }
            set
            {
                StaffLname.Text = string.Empty;
                StaffLname.Text = value;
            }
        }

        public string staffpatronymic
        {
            get { return StaffPatronymic.Text; }
            set
            {
                StaffPatronymic.Text = string.Empty;
                StaffPatronymic.Text = value;
            }
        }

        public string staffposition
        {
            get { return StaffPosition.Text; }
            set
            {
                StaffPosition.Text = string.Empty;
                StaffPosition.Text = value;
            }
        }

        public string staffbirth
        {
            get { return StaffBirth.Text; }
            set
            {
                StaffBirth.Text = string.Empty;
                StaffBirth.Text = value;
            }
        }

        public string staffentry
        {
            get { return StaffEntry.Text; }
            set
            {
                StaffEntry.Text = string.Empty;
                StaffEntry.Text = value;
            }
        }
        public string stafflogin
        {
            get { return StaffLogin.Text; }
            set
            {
                StaffLogin.Text = string.Empty;
                StaffLogin.Text = value;
            }
        }

        public string staffpass
        {
            get { return MD5Encription.GetHashMD5(StaffPass.Text);}
            set
            {
                StaffPass.Text = string.Empty;
                StaffPass.Text = value;
            }
        }

        public ComboBox staffvacant => StaffVacant;





        #endregion

        #region Кнопки

        public Button addStaff => AddStaff;
        public Button deleteStaff => DeleteStaff;
        public Button updateStaff => UpdateStaff;

        #endregion

        #region Обработчики

        private void dataGridStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddStaff_Click(object sender, EventArgs e)
        {

        }

        private void DeleteStaff_Click(object sender, EventArgs e)
        {

        }

        private void UpdateStaff_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ComboBox

        public ComboBox staffPosition => StaffPosition;
        public ComboBox staffVacant => StaffVacant;

        #endregion

        #endregion

        #region Hall

        #region DataGrid
        public DataGridView DataGridhall => dataGridHall;
        #endregion

        #region Поля

        public string idhall
        {
            get { return IDHall.Text; }
            set
            {
                IDHall.Text = string.Empty;
                IDHall.Text = value;
            }
        }

        public string rowshall
        {
            get { return RowsHall.Text; }
            set
            {
                RowsHall.Text = string.Empty;
                RowsHall.Text = value;
            }
        }

        public string seatshall
        {
            get { return SeatsHall.Text; }
            set
            {
                SeatsHall.Text = string.Empty;
                SeatsHall.Text = value;
            }
        }

        #endregion

        #region Кнопки

        public Button addHall => AddHall;
        public Button deleteHall => DeleteHall;
        public Button updateHall => UpdateHall;

        #endregion

        #region Обработчики
        private void dataGridHall_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddHall_Click(object sender, EventArgs e)
        {

        }

        private void DeleteHall_Click(object sender, EventArgs e)
        {

        }

        private void UpdateHall_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #endregion

        #region StaffHall

        #region DataGrid

        public DataGridView DataGridstaffhall => dataGridStaffHall;

        #endregion

        #region Поля

        public string staffhallhid //HallId in StaffHall table
        {
            get { return StaffHallHID.Text; }
            set
            {
                StaffHallHID.Text = string.Empty;
                StaffHallHID.Text = value;
            }
        }

        public ComboBox staffhallsid => StaffHallSID;


        #endregion

        #region Кнопки

        public Button addStaffHall => AddStaffHall;
        public Button deleteStaffHall => DeleteStaffHall;
        public Button updateStaffHall => UpdateStaffHall;

        #endregion

        #region Обработчики
        private void dataGridStaffHall_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddStaffHall_Click(object sender, EventArgs e)
        {

        }

        private void DeleteStaffHall_Click(object sender, EventArgs e)
        {

        }

        private void UpdateStaffHall_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void dataGridSession_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //ID и название фильма
        private void SessionIDFilm_Click(object sender, EventArgs e)
        {

        }

        // ID и ФИО сотрудника
        private void StaffHallSID_Click(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            StaffFname.Text = string.Empty;
            StaffLname.Text = string.Empty;
            StaffPatronymic.Text = string.Empty;
            StaffPosition.Text = string.Empty;
            StaffBirth.Text = string.Empty;
            StaffEntry.Text = string.Empty;
            IDStaff.Text = string.Empty;
            StaffLogin.Text = string.Empty;
            StaffVacant.Text = string.Empty;
        }

        private void FilmsClearFields_Click_1(object sender, EventArgs e)
        {
            IDFilm.Text = string.Empty;
            TitleFilm.Text = string.Empty;
            CountryFilm.Text = string.Empty;
            ProducerFilm.Text = string.Empty;
            DurationFilm.Text = string.Empty;
            DateFilm.Text = string.Empty;
            GanreFilm.Text = string.Empty;
            PriceFilm.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IDSession.Text = string.Empty;
            SessionDate.Text = string.Empty;
            SessionTime.Text = string.Empty;
            SessionIDHall.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IDTicket.Text = string.Empty;
            TicketsIDSession.Text = string.Empty;
            TicketsRow.Text = string.Empty;
            TicketsSeats.Text = string.Empty;
            TicketsZone.Text = string.Empty;
            TicketsRecall.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDHall.Text = string.Empty;
            RowsHall.Text = string.Empty;
            SeatsHall.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
