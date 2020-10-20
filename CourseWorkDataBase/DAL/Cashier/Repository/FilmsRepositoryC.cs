using DAL.Cashier.Interface;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Cashier.Repository
{
    public class FilmsRepositoryC : IFilmsRepositoryC
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public FilmsRepositoryC(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region Select

        public ValidationResult<List<Entities.AdminSingleTable.TableFilms>> SelectFilms()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<Entities.AdminSingleTable.TableFilms>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            Entities.AdminSingleTable.TableFilms tableFilms;



            ValidationResult<List<Entities.AdminSingleTable.TableFilms>> result = new ValidationResult<List<Entities.AdminSingleTable.TableFilms>>()
            {
                IsValid = true,
                ResultObject = new List<Entities.AdminSingleTable.TableFilms>()
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
                    tableFilms = new Entities.AdminSingleTable.TableFilms(

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
                result = new ValidationResult<List<Entities.AdminSingleTable.TableFilms>>
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
