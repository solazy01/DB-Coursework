using BL.Cashier.DomainObjects;
using BL.Cashier.Interface;
using DAL.Cashier.Interface;
using Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Cashier.Service
{
    public class SessionServiceC : ISessionServiceC
    {
        private ISessionRepositoryC _sessionRepository;

        public SessionServiceC(ISessionRepositoryC sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }


        public ValidationResult<List<Entities.AdminSingleTable.TableSession>> SelectSession()
        {
            return _sessionRepository.SelectSession();
        }
    }
}
