using System.Collections.Generic;
using Entities.AdminSingleTable;
using Entities.Validation;
using DAL.Admin.Interface;
using BL.Admin.Interface;
using BL.Admin.DomainObjects;
using SessionMemberDAO = DAL.Admin.DataAccesObjects.SessionMember;

namespace BL.Admin.Service
{
    public class SessionService : ISessionService
    {
        private ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }


        public bool InsertSessions(SessionMember sessionMember)
        {
            return _sessionRepository.InsertSession(new SessionMemberDAO
            {
                FilmId = sessionMember.FilmId,
                Date = sessionMember.Date,
                Time = sessionMember.Time,
                HallId = sessionMember.HallId
            });
        }


        public bool UpdateSessions(SessionMember sessionMember)
        {
            return _sessionRepository.UpdateSession(new SessionMemberDAO
            {
                FilmId = sessionMember.FilmId,
                Date = sessionMember.Date,
                Time = sessionMember.Time,
                HallId = sessionMember.HallId,
                SessionId = sessionMember.SessionId
            });
        }


        public bool DeleteSessions(SessionMember sessionMember)
        {
            return _sessionRepository.DeleteSession(new SessionMemberDAO
            {
                SessionId = sessionMember.SessionId
            });
        }



        public ValidationResult<List<TableSession>> SelectSession()
        {
            return _sessionRepository.SelectSession();
        }
    }
}
