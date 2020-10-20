namespace Entities.AdminSingleTable
{
    public class TableHall
    {
        public string HallId { private set; get; }

        public string Numbers_of_rows { private set; get; }
        public string Number_of_seats_in_a_row { private set; get; }

        public TableHall()
        { }

        public TableHall( string HallId, string Numbers_of_rows, string Number_of_seats_in_a_row)
        {
            this.HallId = HallId;

            this.Numbers_of_rows = Numbers_of_rows;
            this.Number_of_seats_in_a_row = Number_of_seats_in_a_row;
        }
    }
}
