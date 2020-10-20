namespace DAL.Admin.DataAccesObjects
{
    public class TicketsMember
    {
        public string TicketId {  set; get; }
        public string SessionId {  set; get; }
        public string Row {  set; get; }
        public string Seat {  set; get; }
        public string Zone {  set; get; }
        public bool Booking {  set; get; }
        public string Recall {  set; get; }
    }
}
