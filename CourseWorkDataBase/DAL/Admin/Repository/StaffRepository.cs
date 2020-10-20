using System.Collections.Generic;
using DAL.Admin.Interface;
using Entities.AdminSingleTable;
using Entities.SQLConnect;
using Entities.Validation;
using Npgsql;
using System.Data.Common;
using DAL.Admin.DataAccesObjects;
using System;
using System.Runtime.Remoting.Messaging;
using Entities.ComboBox;
using Entities.Security;

namespace DAL.Admin.Repository
{
    public class StaffRepository :IStaffRepository
    {
        private SqlConnect sqlConnect;
        private string _connectionString;

        public StaffRepository(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnect = new SqlConnect(new NpgsqlConnection(connectionString));
        }

        #region Select
        public ValidationResult<List<TableStaff>> SelectStaff()
        {
            var res = GetSingleTable();
            return res;
        }


        public ValidationResult<List<TableStaff>> GetSingleTable()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            TableStaff tableStaff;



            ValidationResult<List<TableStaff>> result = new ValidationResult<List<TableStaff>>()
            {
                IsValid = true,
                ResultObject = new List<TableStaff>()
            };

            try
            {
                string commPart = "SELECT \"StaffId\", (\"FullName\").\"FirstName\", (\"FullName\").\"SecondName\", (\"FullName\").\"Patronymic\", \"Position\", \"BirthDate\",\"EntryDate\", us.IDLogin, us.Vacant " +
                                  "FROM maindb.\"Staff\" as s " +
                                  "INNER JOIN login.userpass as us " +
                                  "ON s.login = us.IDLogin";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaff = new TableStaff(

                        dbDataRecord["StaffId"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Patronymic"].ToString(),
                        dbDataRecord["Position"].ToString(),
                        dbDataRecord["BirthDate"].ToString(),
                        dbDataRecord["EntryDate"].ToString(),
                        dbDataRecord["IDLogin"].ToString(),
                        dbDataRecord["Vacant"].ToString()
                        );
                    result.ResultObject.Add(tableStaff);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<TableStaff>>
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

        public bool InsertStaff(StaffMember staffMember)
        {
            var res = InsertStaffs(staffMember);
            return res.IsValid;
        }

        public ValidationResultString InsertStaffs(StaffMember staffMember)
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
                string commPart = "SELECT * FROM maindb.add_Staff_func(@1, @2, @3,@4,@5::DATE,@6::DATE,@7,@8,@9);";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToString(staffMember.FirstName));
                command.Parameters.AddWithValue("@2", Convert.ToString(staffMember.SecondName));
                command.Parameters.AddWithValue("@3", Convert.ToString(staffMember.Patronymic));
                command.Parameters.AddWithValue("@4", staffMember.Position);
                command.Parameters.AddWithValue("@5", Convert.ToDateTime(staffMember.BirthDate));
                command.Parameters.AddWithValue("@6", Convert.ToDateTime(staffMember.EntryDate));

                command.Parameters.AddWithValue("@7", staffMember.Login);
                command.Parameters.AddWithValue("@8", staffMember.Password);
                command.Parameters.AddWithValue("@9", staffMember.Role);

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

        public bool DeleteStaff(StaffMember staffMember)
        {
            var res = DeleteStaffs(staffMember);
            return res.IsValid;
        }

        

        public ValidationResultString DeleteStaffs(StaffMember staffMember)
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
                string commPart = "DELETE FROM login.\"userpass\" WHERE  \"idlogin\" = @1";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToString(staffMember.Login));

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

        public bool UpdateStaff(StaffMember staffMember)
        {
            var res = UpdateStaffs(staffMember);
            return res.IsValid;
        }

        public ValidationResultString UpdateStaffs(StaffMember staffMember)
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
                string commPart = "SELECT * FROM maindb.update_Staff_func(@1, @2, @3, @4, @5::DATE, @6:: DATE, @7, @8, @9);";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@1", Convert.ToString(staffMember.FirstName));
                command.Parameters.AddWithValue("@2", Convert.ToString(staffMember.SecondName));
                command.Parameters.AddWithValue("@3", Convert.ToString(staffMember.Patronymic));
                command.Parameters.AddWithValue("@4", staffMember.Position);
                command.Parameters.AddWithValue("@5", Convert.ToDateTime(staffMember.BirthDate));
                command.Parameters.AddWithValue("@6", Convert.ToDateTime(staffMember.EntryDate));

                command.Parameters.AddWithValue("@7", staffMember.Login);
                command.Parameters.AddWithValue("@8", staffMember.Password);
                command.Parameters.AddWithValue("@9", staffMember.Role);


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

        #region SELECT IDFullNameStaff
        //IDFullNameStaff

        public ValidationResult<List<IDFullNameStaff>> SelectIDFullName()
        {
            var res = GetFullName();
            return res;

        }
        public ValidationResult<List<IDFullNameStaff>> GetFullName()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            IDFullNameStaff nameStaff;



            ValidationResult<List<IDFullNameStaff>> result = new ValidationResult<List<IDFullNameStaff>>()
            {
                IsValid = true,
                ResultObject = new List<IDFullNameStaff>()
            };

            try
            {
                string commPart = "SELECT s.\"StaffId\" || \'. \' || (\"FullName\").\"FirstName\" || \' \' || (\"FullName\").\"SecondName\" || \' \' || (\"FullName\").\"Patronymic\" as staff " +
                                  "FROM  maindb.\"Staff\" as s " +
                                  "ORDER BY s.\"StaffId\";";


                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    nameStaff = new IDFullNameStaff(
                        dbDataRecord["staff"].ToString()
                    );
                    result.ResultObject.Add(nameStaff);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<IDFullNameStaff>>
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

        #region SELECT Role

        public ValidationResult<List<RolePosition>> SelectRole()
        {
            var res = GetRole();
            return res;
        }

        public ValidationResult<List<RolePosition>> GetRole()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            RolePosition rolePosition;



            ValidationResult<List<RolePosition>> result = new ValidationResult<List<RolePosition>>()
            {
                IsValid = true,
                ResultObject = new List<RolePosition>()
            };

            try
            {
                string commPart = "SELECT DISTINCT vacant FROM login.userpass WHERE vacant != 'admin'";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    rolePosition = new RolePosition(

                        dbDataRecord["vacant"].ToString());
                    result.ResultObject.Add(rolePosition);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<RolePosition>>
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

        #region SELECT Position

        public ValidationResult<List<RolePosition>> SelectPosition()
        {
            var res = GetPosition();
            return res;
        }

        public ValidationResult<List<RolePosition>> GetPosition()
        {
            if (sqlConnect.GetConnect)
            {
                sqlConnect.OpenConn();
            }

            RolePosition rolePosition;



            ValidationResult<List<RolePosition>> result = new ValidationResult<List<RolePosition>>()
            {
                IsValid = true,
                ResultObject = new List<RolePosition>()
            };

            try
            {
                string commPart = "SELECT DISTINCT \"Position\" FROM maindb.\"Staff\" WHERE \"Position\" != 'Управляющий'";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    rolePosition = new RolePosition(

                        dbDataRecord["Position"].ToString());
                    result.ResultObject.Add(rolePosition);
                }
                readerTable.Close();

            }
            catch (PostgresException exp)
            {
                result = new ValidationResult<List<RolePosition>>
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
