using Entities.AdminSingleTable;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Cleaner
{
    public class TimetableRepository : ITimetableRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public TimetableRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        public ValidationResult<List<TableTimetable>> SelectTimetable()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<TableTimetable>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableTimetable tableTimetable;



            ValidationResult<List<TableTimetable>> result = new ValidationResult<List<TableTimetable>>()
            {
                IsValid = true,
                ResultObject = new List<TableTimetable>()
            };

            try
            {
                string commPart = "SELECT f.\"Title\", ses.\"Date\", ses.\"Time\"+f.\"Duration\" as Time, ses.\"HallId\" FROM maindb.\"Staff\" as s INNER JOIN maindb.\"StaffHall\" as sh ON s.\"StaffId\" = sh.\"StaffId\" INNER JOIN maindb.\"Hall\" as h ON sh.\"HallId\" = h.\"HallId\" INNER JOIN maindb.\"Session\" as ses ON h.\"HallId\" = ses.\"HallId\" INNER JOIN maindb.\"Films\" as f ON ses.\"FilmId\" = f.\"FilmId\" WHERE s.login = 'cleaner2'";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableTimetable = new TableTimetable(

                        dbDataRecord["Title"].ToString(),
                        dbDataRecord["Date"].ToString(),
                        dbDataRecord["Time"].ToString(),
                        dbDataRecord["HallId"].ToString()
                        );
                    result.ResultObject.Add(tableTimetable);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableTimetable>>
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
    }
    }
