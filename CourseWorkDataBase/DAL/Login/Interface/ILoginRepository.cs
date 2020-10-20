using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Login.DataAccesObjects;
using Entities.AdminSingleTable;
using Entities.Validation;

namespace DAL.Login.Interface
{
    public interface ILoginRepository
    {
        ValidationResult<List<TableLogin>> LoginUser(LoginMember loginMember);
    }
}
