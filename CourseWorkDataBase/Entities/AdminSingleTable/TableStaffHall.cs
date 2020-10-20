namespace Entities.AdminSingleTable
{
    public class TableStaffHall
    {
        public string HallId { private set; get; }
        public string StaffId { private set; get; }

        public TableStaffHall(string HallId, string StaffId)
        {
            this.HallId = HallId;
            this.StaffId = StaffId;
        }

        public TableStaffHall()
        { }

    }
}
