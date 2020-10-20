using System.Collections.Generic;
using System.Data.Common;
using DAL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;
using DAL.Admin.DataAccesObjects;
using System;

namespace DAL.Admin.Repository
{
    public class StaffHallRepository :IStaffHallRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public StaffHallRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }
        #region Select
        public ValidationResult<List<TableStaffHall>> SelectStaffHall()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<TableStaffHall>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableStaffHall tableStaffHall;



            ValidationResult<List<TableStaffHall>> result = new ValidationResult<List<TableStaffHall>>()
            {
                IsValid = true,
                ResultObject = new List<TableStaffHall>()
            };

            try
            {
                string commPart = "SELECT sh.\"HallId\", s.\"StaffId\" || \'. \' || (\"FullName\").\"FirstName\" || \' \' || (\"FullName\").\"SecondName\" || \' \' || (\"FullName\").\"Patronymic\" as staff " +
                                  "FROM maindb.\"StaffHall\" as sh " +
                                  "INNER JOIN maindb.\"Staff\" as s " +
                                  "ON sh.\"StaffId\" = s.\"StaffId\" " +
                                  "ORDER BY sh.\"HallId\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaffHall = new TableStaffHall(

                        dbDataRecord["HallId"].ToString(),
                        dbDataRecord["staff"].ToString()
                        );
                    result.ResultObject.Add(tableStaffHall);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableStaffHall>>
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

        public bool InsertStaffHall(StaffHallMember staffhallMember)
        {
            var res = InsertStaffHalls(staffhallMember);
            return res.IsValid;
        }

        public ValidationResultString InsertStaffHalls(StaffHallMember staffhallMember)
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
                string commPart = "INSERT INTO maindb.\"StaffHall\" ( \"HallId\", \"StaffId\") VALUES " +
                                  " (@1, @2)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(staffhallMember.HallId));
                command.Parameters.AddWithValue("@2", Convert.ToInt32(staffhallMember.StaffId));


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

        public bool DeleteStaffHall(StaffHallMember staffhallMember)
        {
            var res = DeleteStaffHalls(staffhallMember);
            return res.IsValid;
        }

        public ValidationResultString DeleteStaffHalls(StaffHallMember staffhallMember)
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
                string commPart = "DELETE FROM maindb.\"StaffHall\" WHERE  \"HallId\" = @1 AND \"StaffId\"= @2";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(staffhallMember.HallId));
                command.Parameters.AddWithValue("@2", Convert.ToInt32(staffhallMember.StaffId));

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

        public bool UpdateStaffHall(StaffHallMember staffhallMember)
        {
            var res = UpdateStaffHalls(staffhallMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateStaffHalls(StaffHallMember staffhallMember)
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
                string commPart = " UPDATE maindb.\"StaffHall\" " +
                                  " SET \"HallId\" = @1"+
                                  " WHERE \"StaffId\" = @2";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(staffhallMember.HallId));
                command.Parameters.AddWithValue("@2", Convert.ToInt32(staffhallMember.StaffId));

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
