using System.Collections.Generic;
using BL.Login.DomainObjects;
using Entities.AdminSingleTable;
using Entities.Validation;

namespace BL.Login.Interface
{
    public interface ILoginService
    {
        ValidationResult<List<TableLogin>> LoginUser(LoginMember loginMember);
    }
}
