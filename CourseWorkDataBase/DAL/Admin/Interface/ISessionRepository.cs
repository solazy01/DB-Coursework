using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using DAL.Admin.DataAccesObjects;

namespace DAL.Admin.Interface
{
    public interface ISessionRepository
    {
        ValidationResult<List<TableSession>> SelectSession();
        bool InsertSession(SessionMember sessionMember);
        bool UpdateSession(SessionMember sessionMember);
        bool DeleteSession(SessionMember sessionMember);
    }
}
