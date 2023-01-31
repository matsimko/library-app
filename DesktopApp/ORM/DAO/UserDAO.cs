using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace DesktopApp.ORM.DAO
{
    public class UserDAO : AbstractDAO<User>
    {
        private string selectFirstNamesSql;
        private string selectLastNamesSql;
        private string selectNationalIdNumsSql;

        public UserDAO()
        {
            //10.2 - Aktualizace uživatele
            updateSql = "UPDATE \"User\" SET first_name = @1, last_name = @2, national_id_num = @3," +
                        " home_addr = @4, email_addr = @5, super_user = @6, password = @7, last_login_datetime = @8, cannot_reserve_until_date = @9" +
                        " WHERE user_id = @10";
            //10.3 - Seznam uživatelů
            selectAllSql = "SELECT user_id, first_name, last_name, national_id_num, home_addr, email_addr," +
                            " super_user, password, last_login_datetime, cannot_reserve_until_date" +
                            " FROM \"User\"";
            //10.4 - Detail uživatele
            selectSql = "SELECT user_id, first_name, last_name, national_id_num, home_addr, email_addr," +
                            " super_user, password, last_login_datetime, cannot_reserve_until_date" +
                            " FROM \"User\"" +
                            " WHERE user_id = @1";
            //10.5 - Seznam jmen
            selectFirstNamesSql = "SELECT DISTINCT first_name FROM \"User\"" +
                                " WHERE first_name LIKE @1 + '%'"; //aktuálně musí první znak vstupu být velký 
            //10.6 - Seznam příjmení
            selectLastNamesSql = "SELECT DISTINCT last_name FROM \"User\"" +
                                 " WHERE last_name LIKE @1 + '%'";

            //10.7 - Seznam rodných čísel
            selectNationalIdNumsSql = "SELECT national_id_num FROM \"User\"" +
                                    " WHERE national_id_num LIKE @1 + '%'";
        }

        protected override int FillInsert(User obj, SqlParameterCollection parameters)
        {
            int i = 0;
            parameters.AddWithValue("@" + (++i), obj.FirstName);
            parameters.AddWithValue("@" + (++i), obj.LastName);
            parameters.AddWithValue("@" + (++i), obj.NationalIdNum);
            parameters.AddWithValue("@" + (++i), obj.HomeAddr);
            parameters.AddWithValue("@" + (++i), obj.EmailAddr);
            //Tady je (object) potreba (nebo nejake jine reseni), protoze SuperUser muze byt nula, coz by zavolalo SqlParameter(String, SqlDbType) misto SqlParameter(String, object).
            parameters.AddWithValue("@" + (++i), (object) obj.SuperUser); 
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.Password));
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.LastLoginDatetime));
            parameters.AddWithValue("@" + (++i), ObjOrDbNull(obj.CannotReserveUntilDate));
            return i;
        }

        protected override User LoadObject(SqlDataReader reader)
        {
            int i = -1;
            User user = new User
            {
                Key = new Key(reader.GetInt32(++i)),
                FirstName = reader.GetString(++i),
                LastName = reader.GetString(++i),
                NationalIdNum = reader.GetString(++i),
                HomeAddr = reader.GetString(++i),
                EmailAddr = reader.GetString(++i),
                SuperUser = reader.GetInt32(++i),
                Password = reader.GetString(++i),
            };
            if(!reader.IsDBNull(++i))
            {
                user.LastLoginDatetime = reader.GetDateTime(i);
            }
            if (!reader.IsDBNull(++i))
            {
                user.CannotReserveUntilDate = reader.GetDateTime(i);
            }

            return user;
        }

        //10.1 - Nový uživatel 
        public int NewUser(User user)
        {
            string[] paramNames = {"first_name", "last_name", "national_id_num",
                "home_addr", "email_addr", "super_user"};
            object[] paramValues = {user.FirstName, user.LastName, user.NationalIdNum,
                user.HomeAddr, user.EmailAddr, user.SuperUser};
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand("newUser");
            FillProcedureParams(paramNames, paramValues, command.Parameters);
            SqlParameter userIdParam = new SqlParameter
            {
                ParameterName = "@user_id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            command.Parameters.Add(userIdParam);
            SqlParameter passwordParam = new SqlParameter
            {
                ParameterName = "@password",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 60,
                Direction = System.Data.ParameterDirection.Output
            };
            command.Parameters.Add(passwordParam);
            db.ExecuteStoredProcedure(command);

            int id = 0;
            //set the key and password if the transaction was successful (checking for DBNull, because throwing exceptions in TRY CATCH block in SQL Server doesn't work as expected...)
            if (userIdParam.Value != DBNull.Value)
            {
                id = (int)userIdParam.Value;
                string password = (string)passwordParam.Value;
                //int id = (int) command.Parameters["@user_id"].Value;
                user.Key = new Key(id);
                user.Password = password;
            }
            


            db.Close();

            return id;
        }

        private string CustomLoad(SqlDataReader reader)
        {
            return reader.GetString(0);
        }


        //10.5 - Seznam jmen
        public Collection<string> SelectFirstNames(string firstName)
        {
            object[] fields = { firstName };
            return CustomSelect<string>(selectFirstNamesSql, fields, CustomLoad);
        }


        //10.6 - Seznam příjmení
        public Collection<string> SelectLastNames(string lastName)
        {
            object[] fields = { lastName };
            return CustomSelect<string>(selectLastNamesSql, fields, CustomLoad);
        }


        //10.7 - Seznam rodných čísel
        public Collection<string> SelectNationalIdNums(string nationalIdNum)
        {
            object[] fields = { nationalIdNum };
            return CustomSelect<string>(selectNationalIdNumsSql, fields, CustomLoad);
        }
    }
}
