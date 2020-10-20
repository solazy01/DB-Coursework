using System.Collections.Generic;
using DAL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;
using System.Data.Common;
using System;
using DAL.Admin.DataAccesObjects;

namespace DAL.Admin.Repository
{
    public class SessionRepository :ISessionRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public SessionRepository(string connectionString)
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
                string commPart = "SELECT s.\"SessionId\",f.\"FilmId\" || \'. \' ||  f.\"Title\" as film , s.\"Date\",s.\"Time\", s.\"HallId\" " +
                                  "FROM maindb.\"Session\" as s " +
                                  "INNER JOIN maindb.\"Films\" as f\r\nON s.\"FilmId\" = f.\"FilmId\" " +
                                  "ORDER BY s.\"SessionId\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableSession = new TableSession(

                        dbDataRecord["SessionId"].ToString(),
                        dbDataRecord["film"].ToString(),
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

        #region Insert

        public bool InsertSession(SessionMember sessionMember)
        {
            var res = InsertSessions(sessionMember);
            return res.IsValid;
        }

        public ValidationResultString InsertSessions(SessionMember sessionMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };

            try
            {
                string commPart = "INSERT INTO maindb.\"Session\" ( \"FilmId\", \"Date\",\"Time\", \"HallId\") VALUES " +
                                  " (@1, @2, @3::time without time zone, @4)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(sessionMember.FilmId));
                command.Parameters.AddWithValue("@2", Convert.ToDateTime(sessionMember.Date));
                command.Parameters.AddWithValue("@3", sessionMember.Time);
                command.Parameters.AddWithValue("@4", Convert.ToInt32(sessionMember.HallId));


                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();

            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
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

        #region Delete

        public bool DeleteSession(SessionMember sessionMember)
        {
            var res = DeleteSessions(sessionMember);
            return res.IsValid;
        }

        public ValidationResultString DeleteSessions(SessionMember sessionMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };

            try
            {
                string commPart = "DELETE FROM maindb.\"Session\" WHERE \"SessionId\"=@1";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(sessionMember.SessionId));

                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();

            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
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

        #region Update

        public bool UpdateSession(SessionMember sessionMember)
        {
            var res = UpdateSessions(sessionMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateSessions(SessionMember sessionMember)
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            ValidationResultString result = new ValidationResultString()
            {
                IsValid = true
            };

            try
            {
                string commPart = " UPDATE maindb.\"Session\" " +
                                  " SET \"FilmId\" = @1, \"Date\" = @2, \"Time\" = @3::time without time zone, \"HallId\" = @4 " +
                                  " WHERE \"SessionId\" = @5;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(sessionMember.FilmId));
                command.Parameters.AddWithValue("@2", Convert.ToDateTime(sessionMember.Date));
                command.Parameters.AddWithValue("@3", sessionMember.Time);
                command.Parameters.AddWithValue("@4", Convert.ToInt32(sessionMember.HallId));
                command.Parameters.AddWithValue("@5", Convert.ToInt32(sessionMember.SessionId));

                NpgsqlDataReader readerTable = command.ExecuteReader();
                readerTable.Close();

            }
            catch (Npgsql.PostgresException exp)
            {
                return new ValidationResultString
                {
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
