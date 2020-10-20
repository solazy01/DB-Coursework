using System.Collections.Generic;
using BL.Login.DomainObjects;
using BL.Login.Interface;
using DAL.Login.Interface;
using Entities.AdminSingleTable;
using Entities.Validation;
using LoginMemberDAO = DAL.Login.DataAccesObjects.LoginMember;

namespace BL.Login.Service
{
    public class LoginService : ILoginService
    {
        private ILoginRepository _loginRepository;


        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public ValidationResult<List<TableLogin>> LoginUser(LoginMember loginMember)
        {
            return _loginRepository.LoginUser(new LoginMemberDAO
            {
                Login = loginMember.Login,
                Password = loginMember.Password
            });
        }
    }
}
