using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin.DataAccesObjects
{
    public class StaffMember
    {
        public string StaffId { set; get; }

        public string FirstName {  set; get; }
        public string SecondName {  set; get; }
        public string Patronymic {  set; get; }

        public string Position {  set; get; }
        public string BirthDate {  set; get; }

        public string EntryDate {  set; get; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
