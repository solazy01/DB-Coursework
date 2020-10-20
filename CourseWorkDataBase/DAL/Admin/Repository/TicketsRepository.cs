using DAL.Admin.DataAccesObjects;
using DAL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DAL.Admin.Repository
{
    public class TicketsRepository :ITicketsRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public TicketsRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region Select
        public ValidationResult<List<TableTickets>> SelectTickets()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<TableTickets>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableTickets tableTickets;



            ValidationResult<List<TableTickets>> result = new ValidationResult<List<TableTickets>>()
            {
                IsValid = true,
                ResultObject = new List<TableTickets>()
            };

            try
            {
                string commPart = "SELECT \"TicketID\", \"SessionId\", \"Row\",\"Seat\", \"Zone\", \"Booking\", \"Recall\"" +
                                  "FROM maindb.\"Tickets\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableTickets = new TableTickets(

                        dbDataRecord["TicketID"].ToString(),
                        dbDataRecord["SessionId"].ToString(),
                        dbDataRecord["Row"].ToString(),
                        dbDataRecord["Seat"].ToString(),
                        dbDataRecord["Zone"].ToString(),
                        (bool)dbDataRecord["Booking"],
                        dbDataRecord["Recall"].ToString()
                        );
                    result.ResultObject.Add(tableTickets);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableTickets>>
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

        public bool InsertTickets(TicketsMember ticketsMember)
        {
            var res = InsertTicketss(ticketsMember);
            return res.IsValid;
        }

        public ValidationResultString InsertTicketss(TicketsMember ticketsMember)
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
                string commPart = "INSERT INTO maindb.\"Tickets\" ( \"SessionId\", \"Row\", \"Seat\", \"Zone\", \"Booking\", \"Recall\") VALUES " +
                                  " (@1, @2, @3, @4, @5, @6)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(ticketsMember.SessionId));
                command.Parameters.AddWithValue("@2", Convert.ToInt32(ticketsMember.Row));
                command.Parameters.AddWithValue("@3", Convert.ToInt32(ticketsMember.Seat));
                command.Parameters.AddWithValue("@4", Convert.ToInt32(ticketsMember.Zone));
                command.Parameters.AddWithValue("@5", ticketsMember.Booking);
                command.Parameters.AddWithValue("@6", Convert.ToInt32(ticketsMember.Recall));

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

        public bool DeleteTickets(TicketsMember ticketsMember)
        {
            var res = DeleteTicketss(ticketsMember);
            return res.IsValid;
        }



        public ValidationResultString DeleteTicketss(TicketsMember ticketsMember)
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
                string commPart = "DELETE FROM maindb.\"Tickets\" WHERE \"TicketID\"=@1";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(ticketsMember.TicketId));

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

        public bool UpdateTickets(TicketsMember ticketsMember)
        {
            var res = UpdateTicketss(ticketsMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateTicketss(TicketsMember ticketsMember)
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
                string commPart = " UPDATE maindb.\"Tickets\" " +
                                  " SET \"SessionId\" = @1, \"Row\" = @2, " +
                                  "\"Seat\" = @3, \"Zone\" = @4, \"Booking\" = @5, \"Recall\" = @6 " +
                                  " WHERE \"TicketID\" = @8;";


                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(ticketsMember.SessionId));
                command.Parameters.AddWithValue("@2", Convert.ToInt32(ticketsMember.Row));
                command.Parameters.AddWithValue("@3", Convert.ToInt32(ticketsMember.Seat));
                command.Parameters.AddWithValue("@4", Convert.ToInt32(ticketsMember.Zone));
                command.Parameters.AddWithValue("@5", Convert.ToBoolean(ticketsMember.Booking));

                if (ticketsMember.Recall == String.Empty)
                {
                    command.Parameters.AddWithValue("@6", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@6", Convert.ToInt32(ticketsMember.Recall));
                }

               

                command.Parameters.AddWithValue("@7", Convert.ToInt32(ticketsMember.TicketId));

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
