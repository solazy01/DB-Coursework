namespace Entities.AdminSingleTable
{
    public class TableStaff
    {
        public string StaffId { private set; get; }

        public string FirstName { private set; get; }
        public string SecondName { private set; get; }
        public string Patronymic { private set; get; }

        public string Position { private set; get; }
        public string BirthDate { private set; get; }

        public string EntryDate { private set; get; }

        public string Login { get; }
        public string Role { get; }

        public TableStaff (string StaffId, string FirstName, string SecondName, string Patronymic, string Position, string BirthDate, string EntryDate,
            string Login, string Role)
        {
            this.StaffId = StaffId;

            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Patronymic = Patronymic;

            this.Position = Position;
            this.BirthDate = BirthDate;

            this.EntryDate = EntryDate;
            this.Login = Login;
            this.Role = Role;
        }

        public TableStaff()
        { }
    }
}
