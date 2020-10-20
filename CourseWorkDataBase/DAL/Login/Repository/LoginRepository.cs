using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Login.DataAccesObjects;
using DAL.Login.Interface;
using Entities.AdminSingleTable;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;

namespace DAL.Login.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public LoginRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region Login

        public ValidationResult<List<TableLogin>> LoginUser(LoginMember loginMember)
        {
            var result = Authorization(loginMember);
            return result;
        }


        public ValidationResult<List<TableLogin>> Authorization(LoginMember loginMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }


            TableLogin tableLogin;

            ValidationResult<List<TableLogin>> result = new ValidationResult<List<TableLogin>>()
            {
                IsValid = true,
                ResultObject = new List<TableLogin>()
            };


            try
            {
                string commPart = "SELECT * " +
                                  "FROM login.UserPass " +
                                  "WHERE IDLogin = @1 AND Pass = @2";


                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToString(loginMember.Login));
                command.Parameters.AddWithValue("@2", Convert.ToString(loginMember.Password));

                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableLogin = new TableLogin(
                        dbDataRecord["IDLogin"].ToString(),
                        dbDataRecord["pass"].ToString(),
                        dbDataRecord["vacant"].ToString()
                    );
                    result.ResultObject.Add(tableLogin);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableLogin>>
                {
                    IsValid = false,
                    Errors = new List<string> { exp.SqlState }
                };
            }

            finally
            {
                if (!sqlConnect.GetConnect)
                {
                    sqlConnect.CloseConn();
                }
            }
            return result;

        }

        #endregion
    }
}
