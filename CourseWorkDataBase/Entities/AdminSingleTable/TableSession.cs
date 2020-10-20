namespace Entities.AdminSingleTable
{
    public class TableSession
    {
        public string SessionId { private set; get; }
        public string FilmId { private set; get; }
        public string HallId { private set; get; }
        public string Date { private set; get; }
        public string Time { private set; get; }

        public TableSession()
        { }

        public TableSession(string SessionId, string FilmId, string Date, string Time, string HallId)
        {
            this.SessionId = SessionId;
            this.FilmId = FilmId;
            this.HallId = HallId;
            this.Date = Date;
            this.Time = Time;
        }
    }
}
