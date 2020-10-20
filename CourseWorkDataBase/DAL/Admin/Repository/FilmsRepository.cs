using System;
using System.Collections.Generic;
using System.Data.Common;
using DAL.Admin.DataAccesObjects;
using DAL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.ComboBox;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;

namespace DAL.Admin.Repository
{
    public class FilmsRepository :IFilmsRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public FilmsRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region Select

        public ValidationResult<List<TableFilms>> SelectFilms()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<TableFilms>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableFilms tableFilms;



            ValidationResult<List<TableFilms>> result = new ValidationResult<List<TableFilms>>()
            {
                IsValid = true,
                ResultObject = new List<TableFilms>()
            };

            try
            {
                string commPart = "SELECT \"FilmId\", \"Title\", \"Country\",\"Producer\", \"Duration\", \"ReleaseDate\", \"Genre\", \"BasePrice\" " +
                                  "FROM maindb.\"Films\"" +
                                  "ORDER BY \"FilmId\"";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableFilms = new TableFilms(

                        dbDataRecord["FilmId"].ToString(),
                        dbDataRecord["Title"].ToString(),
                        dbDataRecord["Country"].ToString(),
                        dbDataRecord["Producer"].ToString(),
                        dbDataRecord["Duration"].ToString(),
                        dbDataRecord["ReleaseDate"].ToString(),
                        dbDataRecord["Genre"].ToString(),
                        dbDataRecord["BasePrice"].ToString()
                        );
                    result.ResultObject.Add(tableFilms);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableFilms>>
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

        public bool InsertFilm(FilmsMember filmsMember)
        {
            var res = InsertFilms(filmsMember);
            return res.IsValid;
        }

        public ValidationResultString InsertFilms(FilmsMember filmsMember)
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
                string commPart = "INSERT INTO maindb.\"Films\" ( \"BasePrice\", \"Country\", \"Duration\", \"Genre\", \"Producer\", \"ReleaseDate\", \"Title\") VALUES " +
                                  " (@1, @2, @3::interval, @4, @5, @6, @7)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToDouble(filmsMember.BasePrice));
                command.Parameters.AddWithValue("@2", Convert.ToString(filmsMember.Country));
                command.Parameters.AddWithValue("@3", filmsMember.Duration);
                command.Parameters.AddWithValue("@4", Convert.ToString(filmsMember.Genre));
                command.Parameters.AddWithValue("@5", Convert.ToString(filmsMember.Producer));
                command.Parameters.AddWithValue("@6", Convert.ToDateTime(filmsMember.ReleaseDate));
                command.Parameters.AddWithValue("@7", Convert.ToString(filmsMember.Title));

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

        public bool DeleteFilm(FilmsMember filmsMember)
        {
            var res = DeleteFilms(filmsMember);
            return res.IsValid;
        }

       

        public ValidationResultString DeleteFilms(FilmsMember filmsMember)
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
                string commPart = "DELETE FROM maindb.\"Films\" WHERE \"FilmId\"=@1";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToInt32(filmsMember.FilmId));

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

        public bool UpdateFilm(FilmsMember filmsMember)
        {
            var res = UpdateFilms(filmsMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateFilms(FilmsMember filmsMember)
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
                string commPart = " UPDATE maindb.\"Films\" " +
                                  " SET \"BasePrice\" = @1, \"Country\" = @2, " +
                                  "\"Duration\" = @3::interval, \"Genre\" = @4, \"Producer\" = @5, \"ReleaseDate\" = @6, \"Title\" = @7 " +
                                  " WHERE \"FilmId\" = @8;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToDouble(filmsMember.BasePrice));
                command.Parameters.AddWithValue("@2", Convert.ToString(filmsMember.Country));
                command.Parameters.AddWithValue("@3", filmsMember.Duration);
                command.Parameters.AddWithValue("@4", Convert.ToString(filmsMember.Genre));
                command.Parameters.AddWithValue("@5", Convert.ToString(filmsMember.Producer));
                command.Parameters.AddWithValue("@6", Convert.ToDateTime(filmsMember.ReleaseDate));
                command.Parameters.AddWithValue("@7", Convert.ToString(filmsMember.Title));
                command.Parameters.AddWithValue("@8", Convert.ToInt32(filmsMember.FilmId));

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

        #region SELECT FName

        public ValidationResult<List<FilmsName>> SelectFilmsName()
        {
            var res = GetFilmsName();
            return res;
        }

        public ValidationResult<List<FilmsName>> GetFilmsName()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            FilmsName filmsName;



            ValidationResult<List<FilmsName>> result = new ValidationResult<List<FilmsName>>()
            {
                IsValid = true,
                ResultObject = new List<FilmsName>()
            };

            try
            {
                string commPart = "SELECT f.\"FilmId\" || \'. \' ||  f.\"Title\" as film " +
                                  "FROM  maindb.\"Films\" as f " +
                                  "ORDER BY f.\"FilmId\"\r\n";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    filmsName = new FilmsName(

                        dbDataRecord["film"].ToString()
                    );
                    result.ResultObject.Add(filmsName);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<FilmsName>>
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
