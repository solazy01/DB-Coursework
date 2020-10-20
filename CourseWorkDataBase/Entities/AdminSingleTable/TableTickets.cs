namespace Entities.AdminSingleTable
{
    public class TableTickets
    {
        public string TicketId { private set; get; }
        public string SessionId { private set; get; }
        public string Row { private set; get; }
        public string Seat { private set; get; }
        public string Zone { private set; get; }
        public bool Booking { private set; get; }
        public string Recall { private set; get; }


        public TableTickets(string TicketId, string SessionId, string Row, string Seat, string Zone, bool Booking, string Recall)
        {
            this.TicketId = TicketId;
            this.SessionId = SessionId;
            this.Row = Row;
            this.Seat = Seat;
            this.Zone = Zone;
            this.Booking = Booking;
            this.Recall = Recall;
        }

        public TableTickets()
        { }
    }
}
