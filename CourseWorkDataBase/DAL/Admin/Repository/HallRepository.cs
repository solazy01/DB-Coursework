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
    public class HallRepository :IHallRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public HallRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }
        #region Select
        public ValidationResult<List<TableHall>> SelectHall()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<TableHall>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableHall tableHall;



            ValidationResult<List<TableHall>> result = new ValidationResult<List<TableHall>>()
            {
                IsValid = true,
                ResultObject = new List<TableHall>()
            };

            try
            {
                string commPart = "SELECT \"HallId\", \"Numbers_of_rows\", \"Number_of_seats_in_a_row\"" +
                                  "FROM maindb.\"Hall\"" +
                                  "ORDER BY \"HallId\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableHall = new TableHall(

                        dbDataRecord["HallId"].ToString(),
                        dbDataRecord["Numbers_of_rows"].ToString(),
                        dbDataRecord["Number_of_seats_in_a_row"].ToString()
                        );
                    result.ResultObject.Add(tableHall);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableHall>>
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

        public bool InsertHall(HallMember hallMember)
        {
            var res = InsertHalls(hallMember);
            return res.IsValid;
        }

        public ValidationResultString InsertHalls(HallMember hallMember)
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
                string commPart = "INSERT INTO maindb.\"Hall\" ( \"Numbers_of_rows\", \"Number_of_seats_in_a_row\") VALUES " +
                                  " (@1, @2)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32 (hallMember.Numbers_of_rows));
                command.Parameters.AddWithValue("@2", Convert.ToInt32 (hallMember.Number_of_seats));
               

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

        public bool DeleteHall(HallMember hallMember)
        {
            var res = DeleteHalls(hallMember);
            return res.IsValid;
        }

        public ValidationResultString DeleteHalls(HallMember hallMember)
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
                string commPart = "DELETE FROM maindb.\"Hall\" WHERE \"HallId\"=@1";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(hallMember.HallId));

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

        public bool UpdateHall(HallMember hallMember)
        {
            var res = UpdateHalls(hallMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateHalls(HallMember hallMember)
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
                string commPart = " UPDATE maindb.\"Hall\" " +
                                  " SET \"Numbers_of_rows\" = @1, \"Number_of_seats_in_a_row\" = @2 " +
                                  " WHERE \"HallId\" = @3;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(hallMember.Numbers_of_rows));
                command.Parameters.AddWithValue("@2", Convert.ToInt32(hallMember.Number_of_seats));
                command.Parameters.AddWithValue("@3", Convert.ToInt32(hallMember.HallId));

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
