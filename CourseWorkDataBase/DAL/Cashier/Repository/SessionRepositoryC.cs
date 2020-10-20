using DAL.Cashier.Interface;
using Entities.AdminSingleTable;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;
using System.Collections.Generic;
using System.Data.Common;


namespace DAL.Cashier.Repository
{
    public class SessionRepositoryC : ISessionRepositoryC
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public SessionRepositoryC(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region Select

        public ValidationResult<List<TableSession>> SelectSession()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<TableSession>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableSession tableSession;



            ValidationResult<List<TableSession>> result = new ValidationResult<List<TableSession>>()
            {
                IsValid = true,
                ResultObject = new List<TableSession>()
            };

            try
            {
                string commPart = "SELECT \"SessionId\", \"FilmId\", \"Date\",\"Time\", \"HallId\" " +
                                  "FROM maindb.\"Session\"" +
                                  "ORDER BY \"SessionId\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableSession = new TableSession(

                        dbDataRecord["SessionId"].ToString(),
                        dbDataRecord["FilmId"].ToString(),
                        dbDataRecord["Date"].ToString(),
                        dbDataRecord["Time"].ToString(),
                        dbDataRecord["HallId"].ToString()
                        );
                    result.ResultObject.Add(tableSession);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableSession>>
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
