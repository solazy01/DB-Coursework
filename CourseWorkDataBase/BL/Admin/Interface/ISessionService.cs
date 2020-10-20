using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using BL.Admin.DomainObjects;

namespace BL.Admin.Interface
{
    public interface ISessionService
    {
        ValidationResult<List<TableSession>> SelectSession();
        bool InsertSessions(SessionMember sessionMember);
        bool UpdateSessions(SessionMember sessionMember);
        bool DeleteSessions(SessionMember sessionMember);
    }
}
