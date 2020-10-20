using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Login.DomainObjects;
using BL.Login.Interface;
using Entities.AdminSingleTable;
using Entities.Security;
using Entities.Validation;

namespace CourseWork.Controllers.LoginController
{
    public class LoginPresenter
    {
        private string errorController = "Произошла ошибка на уровне контроллера";
        private string errorDataBase = "Произошла ошибка на уровне БД";
        private AuthForm _form2;

        private ILoginService _loginService;

        private Button _btnLogin;

        public string Login { get; set; }
        public string Vacant { get; set; }

        public LoginPresenter(AuthForm form2, ILoginService loginService)
        {
            _form2 = form2;
            _loginService = loginService;


            _btnLogin = _form2.login;
            _btnLogin.Click += Login_Click;
        }



        private void Login_Click(object sender, EventArgs e)
        {
            ValidationResult<List<TableLogin>> myResult = _loginService.LoginUser(new LoginMember
            {
                Login = _form2.userName,
                Password = MD5Encription.GetHashMD5(_form2.password)
            });
            if (myResult.ResultObject.Count != 0)
            {
                Vacant = myResult.ResultObject[0].Vacant;
                Login = myResult.ResultObject[0].Login;
                _form2.Close();

            }
            else
            {
                MessageBox.Show("Не верный логин или пароль");
            }
        }
    }
}
